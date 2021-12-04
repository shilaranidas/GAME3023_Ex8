using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICharacter : ICharacter
{
    public override void TakeTurn(EncounterInstance encounter)
    {
        //have ai choose and perform an action!
        //do ablility
        //subscribe to onablilityfinished event
        //when ability is done, advance turns on the encounter
        Debug.Log("AI turn");
        //encounter.AdvancedTurns();
        CastAbility(Random.Range(0,abilities.Length), this, encounter.player);
    }

    
}
