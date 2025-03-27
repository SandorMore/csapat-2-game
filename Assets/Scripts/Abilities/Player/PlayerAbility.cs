using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility : Ability
{

    public List<ResourceManager.Resource> RequiredResources;
    public List<ResourceManager.Resource> LockedResources;

    public Player GetPlayer()
    {
        return gameObject.GetComponent<Player>();
    }
    public ResourceManager GetResourceManager()
    {
        return gameObject.GetComponent<ResourceManager>();
    }

    public override bool CanStart() 
    {
        if (!base.CanStart())
            return false;

        if (!HasResources())
            return false;

        return true;
    }

    bool HasResources()
    {
        foreach (ResourceManager.Resource Res in RequiredResources)
        {
            if (GetResourceManager().IsResourceLocked(Res))
                return false;
        }
        return true;
    }

    void LockResources()
    {
        foreach (ResourceManager.Resource Res in LockedResources)
        {
            GetResourceManager().LockResource(Res, this);
        }
    }
    void UnlockResources()
    {
        foreach (ResourceManager.Resource Res in LockedResources)
        {
            GetResourceManager().UnlockResource(Res, this);
        }
    }

    public override bool StartAbility()
    {
        if (!base.StartAbility())
            return false;

        LockResources();

        return true;
    }
    public override bool EndAbility()
    {
        if (!base.EndAbility())
            return false;

        UnlockResources();

        return true;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
