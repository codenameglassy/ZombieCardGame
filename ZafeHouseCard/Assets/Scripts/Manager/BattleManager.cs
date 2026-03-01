using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance;

    [Header("Battle")]
    public CharacterInstance _currentPlayerInstance;
    public CharacterInstance _currentZombieInstance;

    [Header("Card System")]
    public CardInstance[] PlayerHand; // Cards in player hand

    [Header("Card Drawer")]
    public CardDrawer cardDrawer;

    public bool IsPlayerTurn { get; private set; } = true;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        StartPlayerTurn();
    }

    #region Player Turn

    public void StartPlayerTurn()
    {
        IsPlayerTurn = true;
        Debug.Log("Player's Turn");

        // Draw/refresh hand
        DrawCardsForPlayer();
    }

    public void PlayerPlaysCard(CardInstance card)
    {
        if (!IsPlayerTurn)
        {
            Debug.LogWarning("Not your turn!");
            return;
        }

        // Play card
        card.PlayCard(_currentPlayerInstance, _currentZombieInstance, this);

        // Remove card from hand list
        RemoveCardFromHand(card);

        // Destroy the card GameObject
        if (card != null)
        {
            Destroy(card.gameObject);
        }

        // Check if player ran out of cards
        if (PlayerHand.Length == 0)
        {
            EndPlayerTurn();
        }
    }

    private void DrawCardsForPlayer()
    {
        if (cardDrawer == null)
        {
            Debug.LogWarning("CardDrawer is not assigned!");
            return;
        }

        // Draw cards using CardDrawer
        cardDrawer.DrawCards();

        // Set PlayerHand to the spawned cards
        PlayerHand = cardDrawer.hand.ToArray();

        Debug.Log("Player hand drawn: " + PlayerHand.Length + " cards");
    }

    private void RemoveCardFromHand(CardInstance card)
    {
        var handList = new List<CardInstance>(PlayerHand);
        handList.Remove(card);
        PlayerHand = handList.ToArray();

        if (cardDrawer != null && cardDrawer.hand.Contains(card))
        {
            cardDrawer.hand.Remove(card);
        }
    }

    public void EndPlayerTurn()
    {
        Debug.Log("Player turn ended");
        IsPlayerTurn = false;
        StartCoroutine(ZombieTurn());
    }

    #endregion

    #region Zombie Turn

    private IEnumerator ZombieTurn()
    {
        Debug.Log("Zombie's Turn");

        // Example: Zombie waits 1 second per action
        yield return new WaitForSeconds(1f);

        // Zombie attacks player
        ZombieAttack();

        yield return new WaitForSeconds(1f);

        // After Zombie turn ends
        StartPlayerTurn();
    }

    private void ZombieAttack()
    {
        int damage = Random.Range(3, 8);
        _currentPlayerInstance.TakeDamage(damage);

        // Notify observers
        CardEvents.DamageDealt(_currentPlayerInstance, damage);

        Debug.Log($"Zombie attacks Player for {damage} damage");
    }

    #endregion






}
