using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAbility", menuName = "AbilitySystem/Ability")]
public class Ability : ScriptableObject
{
    [SerializeField]
    private new string name;

    [SerializeField]
    private string description;

    [SerializeField] 
    private IEffect[] effects;

    public void Cast(ICharacter self, ICharacter other)
    {
        Debug.Log("cast " + name);
        foreach (IEffect effect in effects)
        {
            effect.ApplyEffect(self, other);
        }
        self.onAbilityCast.Invoke(this);
        
    }

}
