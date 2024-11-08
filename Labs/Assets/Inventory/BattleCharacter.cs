using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCharacter : MonoBehaviour
{
    private int hitPoints = 1;
    public int HitPoints { get { return hitPoints; } private set { hitPoints = value; } }

    [Range(0, 1000)]
    public int defense = 1;
    public int strength = 0;
    public int dexterity = 0;
    public int intelligence = 0;

    public Dictionary<StatusInstance, int> statusEffects = new Dictionary<StatusInstance, int>();

    public void TakeAttack(int attackValue)
    {
        HitPoints -= attackValue;
    }

    public void TakeHealing(int healValue)
    {
        HitPoints += healValue;
    }

    public void TakeDamage(int ceilToInt)
    {
        throw new System.NotImplementedException();
    }
}
