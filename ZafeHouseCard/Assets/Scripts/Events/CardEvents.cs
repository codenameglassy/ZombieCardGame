using System;
using UnityEngine;

/// <summary>
/// Centralized events for card gameplay.
/// Use these to subscribe to card actions (played, damage dealt, healed, etc.).
/// </summary>
public static class CardEvents
{
    /// <summary>
    /// Triggered when a card is played.
    /// Parameters: CardInstance, Source Character, Target Character
    /// </summary>
    public static event Action<CardInstance, CharacterInstance, CharacterInstance> OnCardPlayed;

    /// <summary>
    /// Triggered when damage is dealt to a character.
    /// Parameters: Target Character, Damage Amount
    /// </summary>
    public static event Action<CharacterInstance, int> OnDamageDealt;

    /// <summary>
    /// Triggered when a character is healed.
    /// Parameters: Target Character, Heal Amount
    /// </summary>
    public static event Action<CharacterInstance, int> OnHealed;

    /// <summary>
    /// Call this when a card is played
    /// </summary>
    public static void CardPlayed(CardInstance card, CharacterInstance source, CharacterInstance target)
    {
        OnCardPlayed?.Invoke(card, source, target);
    }

    /// <summary>
    /// Call this when damage is applied
    /// </summary>
    public static void DamageDealt(CharacterInstance target, int amount)
    {
        OnDamageDealt?.Invoke(target, amount);
    }

    /// <summary>
    /// Call this when healing is applied
    /// </summary>
    public static void Healed(CharacterInstance target, int amount)
    {
        OnHealed?.Invoke(target, amount);
    }
}