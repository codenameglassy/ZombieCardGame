using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CardInstance : MonoBehaviour
{
    [Header("Data")]
    public CardData _data;

    // Called by CardPlayManager or click
    public void PlayCard(CharacterInstance source, CharacterInstance target, BattleManager battleManager)
    {
        CardContext context = new CardContext(source, target, this, battleManager);

        _data.effect.Execute(context);

        // Notify observers
        CardEvents.CardPlayed(this, source, target);

        // Example: If effect is DamageEffect
        if (_data.effect is AttackCardEffect dmgEffect)
        {
            CardEvents.DamageDealt(target, dmgEffect.dmgAmt);
        }

    
    }

    private void OnMouseDown()
    {
        // Let CardPlayManager handle auto-selection and observers
        if (BattleManager.Instance == null) return;

        CardPlayManager.Instance.PlayCard(this,BattleManager.Instance._currentPlayerInstance, BattleManager.Instance._currentZombieInstance, BattleManager.Instance);
    }

}
