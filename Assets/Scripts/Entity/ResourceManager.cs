using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{

    public enum Resource
    { 
        Move,
        Jump,
        Attack,
        Dodge,
        Heal
    }

    private struct ResourceLock 
    {
        public Resource LockedResource;
        public Ability LockingAbility;

        public ResourceLock(Resource Res, Ability Locker)
        {
            LockedResource = Res;
            LockingAbility = Locker;
        }
    }

    private List<ResourceLock> ResourceLocks = new List<ResourceLock>();


    public Ability GetLockingAbility(Resource Res)
    {
        foreach (ResourceLock Lock in ResourceLocks)
        {
            if (Lock.LockedResource == Res)
                return Lock.LockingAbility;
        }
        return null;
    }
    public bool IsResourceLocked(Resource Res)
    {
        foreach (ResourceLock Lock in ResourceLocks)
        {
            if (Lock.LockedResource == Res)
                return true;
        }
        return false;
    }
    public void LockResource(Resource Res, Ability Locker)
    {
        ResourceLocks.Add(new ResourceLock(Res, Locker));
    }
    public void UnlockResource(Resource Res, Ability Locker)
    {
        List<ResourceLock> Locks = ResourceLocks;
        for (int i = Locks.Count - 1; i >= 0; --i)
        {
            ResourceLock Lock = ResourceLocks[i];
            if (Lock.LockedResource == Res && Lock.LockingAbility == Locker)
                ResourceLocks.RemoveAt(i);
        }
    }

    private void LogResources()
    {
        Debug.ClearDeveloperConsole();
        foreach(Resource res in Resource.GetValues(typeof(Resource)))
        {
            Debug.Log(res.ToString() + " " + IsResourceLocked(res));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //LogResources();
    }
}
