using UnityEngine;

public class CardPlayManager : MonoBehaviour
{
    public static CardPlayManager Instance;

    private void Awake() => Instance = this;

    public void PlayCard(CardInstance card, CharacterInstance source, CharacterInstance target, BattleManager battleManager)
    {
       
        card.PlayCard(source, target, battleManager);

        Debug.Log($"{source.name} played {card._data.cardName} on {target.name}");
    }

  
}