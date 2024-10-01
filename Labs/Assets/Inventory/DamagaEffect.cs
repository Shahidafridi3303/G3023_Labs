using UnityEngine;

[CreateAssetMenu(fileName = "NewDamageEffect", menuName = "Effects/Damage")]
public class DamagaEffect : Effect
{
    public int attackValue = 1;

    public override void ApplyTo(BattleCharacter character)
    {
        character.TakeAttack(attackValue);
    }
}