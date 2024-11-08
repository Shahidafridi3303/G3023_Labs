using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.TextCore.Text;

public class BattleSystem : MonoBehaviour
{
    private static BattleSystem instance;
    public static BattleSystem Instance { get {
            if (instance == null)
                instance = FindFirstObjectByType<BattleSystem>();
            return instance;
        } private set { instance = value; } }

    public event Action<BattleSystem, BattleCharacter, BattleCharacter, Attack> OnAttack;
    public event Action<BattleSystem, BattleCharacter, BattleCharacter, Effect> OnEffect; 
    public event Action<BattleSystem, BattleCharacter, BattleCharacter, Item> OnItemUse;
    public UnityEvent<BattleCharacter> onTurnEnd;
    public UnityEvent<BattleCharacter> onTurnBegin;

    public void BeginTurn(BattleCharacter character)
    {
        foreach (var effect in character.statusEffects)
        {
            if (effect.Value <= 0)
            {
                character.statusEffects.Remove(effect.Key);
            }
            else
            {
                effect.Key.Apply(character, character);
                character.statusEffects[effect.Key] = effect.Value - 1;
            }
        }
    }

    public void UseItem(Item item, BattleCharacter caster, BattleCharacter target)
    {
        OnItemUse.Invoke(this, caster, target, item);
        Debug.Log("Used: " + name + " on " + target.name + "\n" + item.description);

        foreach (Effect effect in item.effects)
        {
            Attack asAttack = effect as Attack;
            if (asAttack != null)
            {
                OnAttack.Invoke(this, caster, target, asAttack);
            }

            OnEffect.Invoke(this, caster,target, asAttack);
            effect.Apply(caster, target); 
        }
    }

    public static float GetDefenseScalar(BattleCharacter defender)
    {
        return (1.0f - (1.0f / Mathf.Max(1, defender.defense)));
    }
}
