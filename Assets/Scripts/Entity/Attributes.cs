using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Store attributes for enitites



[ExecuteInEditMode]
public class Attributes : MonoBehaviour
{

    public class AttributeModifier
    {

        public string Attribute = "None";
        public float FlatMod = 0;
        public float AddMultMod = 0;
        public float MultMod = 1;
    
    }

    [System.Serializable]
    public struct DefaultValue
    {
        public string AttributeName;
        public float Value;

        public DefaultValue(string Name, float NewValue)
        {
            AttributeName = Name;
            Value = NewValue;
        }
    }
    [System.Serializable]
    public enum AttributePreset
    {
        None,
        Enemy,
        WorldObject,
        Projectile
    }

    private Dictionary<AttributePreset, List<DefaultValue>> PresetData = new Dictionary<AttributePreset, List<DefaultValue>>();

    [Header("Default")]
    public AttributePreset Preset = AttributePreset.None;
    [Header("Default")]
    public List<DefaultValue> DefaultAttributes;

    private List<AttributeModifier> AttributeModifiers = new List<AttributeModifier>();

    AttributeModifier AddAttributeModifier(string Attribute, float Flat = 0, float AddMult = 0, float Mult = 1)
    {
        AttributeModifier NewMod = new AttributeModifier();
        NewMod.Attribute = Attribute;
        NewMod.FlatMod = Flat;
        NewMod.AddMultMod = AddMult;
        NewMod.MultMod = Mult;
        AttributeModifiers.Add(NewMod);
        return NewMod;
    }

    void RemoveModifier(AttributeModifier ToRemove)
    {
        if(AttributeModifiers.Contains(ToRemove))
            AttributeModifiers.Remove(ToRemove);
    }

    float GetAttribute(string Attribute)
    {
        float Sum = 0;
        foreach (AttributeModifier Mod in AttributeModifiers)
        {
            Sum += Mod.FlatMod;
        }
        float AddMultMod = 1;
        foreach (AttributeModifier Mod in AttributeModifiers)
        {
            AddMultMod += Mod.AddMultMod;
        }
        Sum *= AddMultMod;
        foreach (AttributeModifier Mod in AttributeModifiers)
        {
            Sum *= Mod.MultMod;
        }
        return Sum;
        
    }

    void Start()
    {
        AddAttributeModifier("MaxHP", 0f, 0.2f, 0f);
    }

    void Update()
    {

        if (PresetData.Count == 0)
        {
            List<DefaultValue> EnemyDefaults = new List<DefaultValue>();
            EnemyDefaults.Add(new DefaultValue("MaxHP", 100f));
            PresetData.Add(AttributePreset.Enemy, EnemyDefaults);
            List<DefaultValue> ObjectDefaults = new List<DefaultValue>();
            ObjectDefaults.Add(new DefaultValue("MaxHP", 100f));
            PresetData.Add(AttributePreset.WorldObject, ObjectDefaults);
        }

        if (Preset != AttributePreset.None && DefaultAttributes.Count == 0)
        {
            DefaultAttributes.Clear();
            if (PresetData.ContainsKey(Preset))
            {
                foreach (DefaultValue Value in PresetData[Preset])
                {
                    DefaultAttributes.Add(Value);
                }
            }
        }
    }
}
