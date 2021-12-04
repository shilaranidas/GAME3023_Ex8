using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : ICharacter
{
    [SerializeField]
    private EncounterInstance myEncounter;
    public void CastAbility(int slot)
    {
        CastAbility(slot, this, myEncounter.enemy);
    }
    public override void TakeTurn(EncounterInstance encounter)
    {
        myEncounter = encounter;
        //encounter.AdvancedTurns();
        //throw new System.NotImplementedException();
    }
}
