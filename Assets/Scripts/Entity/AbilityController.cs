using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityController : MonoBehaviour
{

    public Entity OwnerEntity;
    public List<Ability> Abilities;

    [Header("Default")]
    public Ability DeathAbility;
    [Header("Default")]
    public Ability GroundMove;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Ability Ab in Abilities)
        {
            Ab.Tick(Time.deltaTime);
        }
    }
}
