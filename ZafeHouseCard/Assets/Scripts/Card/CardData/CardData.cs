using UnityEngine;

[CreateAssetMenu(menuName = "Card/Card Data")]
public class CardData : ScriptableObject
{
    public string cardName;
    public Sprite icon;

    public CardEffectStrategy effect;
}