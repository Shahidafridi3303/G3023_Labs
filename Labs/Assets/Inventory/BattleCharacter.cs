using UnityEngine;

public class BattleCharacter : MonoBehaviour
{
    private int hitPoints = 1;
    public int HitPoints { get { return hitPoints; } private set { hitPoints = value; } }

    public void TakeAttack(int attackValue)
    {
        HitPoints -= attackValue;
    }
}
