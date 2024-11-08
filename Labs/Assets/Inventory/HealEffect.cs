using UnityEngine;

[CreateAssetMenu(fileName = "HealEffect", menuName = "Effects/Heal")]
public class HealEffect : Effect
{
    public int healValue = 1;

    public override void Apply(BattleCharacter caster, BattleCharacter target)
    {
        target.TakeHealing(healValue);
    }
}