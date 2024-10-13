using UnityEngine;

[CreateAssetMenu(fileName = "DamageEffect", menuName = "Effects/Damage")]
public class HPModifier : Effect
{
    public int attackValue = 1;

    public override void Apply(BattleCharacter caster, BattleCharacter target)
    {
        target.TakeAttack(attackValue);
    }
}