using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//abstract keyword makes it an "Interface", which is like pure virtual in C++
//In C++, you could declare something like virtual void handleUserInput() = 0;
//In C#, we use the abstract keyword instead of virtual and = 0
public abstract class IEffect : ScriptableObject
{
    //Every child class of IEffect MUST implement an override for the method ApplyEffect
    public abstract void ApplyEffect(ICharacter self, ICharacter other);
}
