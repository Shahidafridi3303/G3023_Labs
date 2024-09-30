using UnityEngine;

public abstract class Effect: ScriptableObject
{
    public abstract void ApplyTo(BattleCharacter character);
}
