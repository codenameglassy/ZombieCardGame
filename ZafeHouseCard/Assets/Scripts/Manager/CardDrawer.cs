using System.Collections.Generic;
using UnityEngine;

public class CardDrawer : MonoBehaviour
{
    [Header("Card Prefab & Hand")]
    public GameObject cardPrefab; // The CardInstance prefab
    public Transform handParent;  // Where cards will be spawned

    [Header("Deck Settings")]
    public List<CardData> deck = new List<CardData>(); // List of all available cards
    public int drawCount = 5; // How many cards to draw per turn

    [HideInInspector]
    public List<CardInstance> hand = new List<CardInstance>(); // Current cards in hand

    [Header("References")]
    public CharacterInstance player;
    public CharacterInstance[] possibleTargets;
    public BattleManager battleManager;

    /// <summary>
    /// Draws cards from the deck and spawns them into the hand
    /// </summary>
    public void DrawCards()
    {
        ClearHand(); // Optional: clear previous cards

        for (int i = 0; i < drawCount; i++)
        {
            if (deck.Count == 0) break; // No more cards in deck

            // Pick random card from deck
            int randomIndex = Random.Range(0, deck.Count);
            CardData cardData = deck[randomIndex];

            SpawnCard(cardData);
        }
    }

    /// <summary>
    /// Spawns a card prefab and sets it up
    /// </summary>
    private void SpawnCard(CardData cardData)
    {
        float spacing = 4f;
        int totalCards = drawCount;
        float offset = (hand.Count - (totalCards - 1) / 2f) * spacing;

        Vector3 spawnPosition = handParent.position + new Vector3(offset, 0, 0);

        GameObject cardGO = Instantiate(cardPrefab, spawnPosition, Quaternion.identity, handParent);
        CardInstance cardInstance = cardGO.GetComponent<CardInstance>();

        cardInstance._data = cardData;
    

        hand.Add(cardInstance);
    }

    /// <summary>
    /// Clears the current hand
    /// </summary>
    public void ClearHand()
    {
        foreach (var card in hand)
        {
            if (card != null) Destroy(card.gameObject);
        }

        hand.Clear();
    }
}