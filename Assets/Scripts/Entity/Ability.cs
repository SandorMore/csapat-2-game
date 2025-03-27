using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{

    public AbilityController Controller { get; }

    protected bool bIsRunning = false;

    public virtual bool CanStart()
    {
        if (bIsRunning)
            return false;

        return true;
    }
    public virtual void Added()
    {
        
    }
    public virtual void Removed()
    {
        
    }
    public virtual bool StartAbility()
    {
        if (!CanStart())
            return false;

        Debug.Log("Started " + this);
        bIsRunning = true;

        return true;
    }

    public virtual void InputRelease()
    {
        EndAbility();
    }
    public virtual bool EndAbility()
    {
        if (!bIsRunning)
            return false;

        bIsRunning = false;
        Debug.Log("Ended " + this);

        return true;
    }

    public virtual void Tick(float DeltaTime)
    { 
    
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
