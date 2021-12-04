using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//The prefix "I" stands for "Interface" which implies it must be used in an inheritance heirarchy.
//You cannot instantiate an ICharacter (base class), but you can create child classes of it and instantiate those
//Technically, it is not quite an interface as it already inherits from another class, but we are using it like one
//C# has an interface keyword specifically for that
public abstract class ICharacter : MonoBehaviour
{
    [SerializeField] 
    protected Ability[] abilities;
    private EncounterInstance encounter;
    //caster, opponent
    //public UnityEvent<Ability,ICharacter, ICharacter> onAbilityCast;
    public UnityEvent<Ability> onAbilityCast;
    public void CastAbility(int abilitySlot,ICharacter self, ICharacter opponent)
    {
        abilities[abilitySlot].Cast(self, opponent);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public abstract void TakeTurn(EncounterInstance encounter);
}
