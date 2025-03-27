using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeAbility : PlayerAbility
{
    // Start is called before the first frame update

    public override bool StartAbility()
    {
        if (!base.StartAbility())
            return false;

        EndAbility();

        return true;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
