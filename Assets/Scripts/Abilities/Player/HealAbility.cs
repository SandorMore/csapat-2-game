using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealAbility : PlayerAbility
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override bool StartAbility() 
    {
        if (!base.StartAbility())
            return false;

        return true;
    }
}
