using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Items/New Item")]
public class Item : ScriptableObject
{
    public Sprite sprite;
    public string description = "";
    public int value = 0;
    public List<Effect> effects;

    public virtual void Use(BattleCharacter target) //(BattleCharacter useOn)
    {
        Debug.Log("Used: " + name + " " + description);

        //foreach (Effect effect in effects)
        //{
        //    effect.ApplyTo(useOn);
        //}
    }
}
