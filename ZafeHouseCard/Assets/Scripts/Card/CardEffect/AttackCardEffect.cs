using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card Effects/Attack Card Effect")]
public class AttackCardEffect : CardEffectStrategy
{
    public int dmgAmt;
    public override void Execute(CardContext context)
    {
        context._target.TakeDamage(dmgAmt);

        // Notify observers
        CardEvents.DamageDealt(context._target, dmgAmt);
    }
}
