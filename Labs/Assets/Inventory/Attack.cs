using UnityEngine;

[CreateAssetMenu(fileName = "DamageEffect", menuName = "Effects/Damage")]
public class Attack : Effect
{
    public int basePower = 1;
    public float strScalar = 1;
    public float dexScalar = 0;
    public float intScalar = 0;

    public override void Apply(BattleCharacter caster, BattleCharacter target)
    {
        float baseAttack = basePower;
        float scaledAttack = baseAttack
            + strScalar * caster.strength
            + dexScalar * caster.dexterity
            + intScalar * caster.intelligence;

        float defenseMitigation = BattleSystem.GetDefenseScalar(target);

        scaledAttack *= defenseMitigation;

        target.TakeDamage(Mathf.CeilToInt(scaledAttack));
    }
}