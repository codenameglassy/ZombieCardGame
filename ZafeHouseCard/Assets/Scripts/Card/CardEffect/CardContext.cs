using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardContext 
{
    //source
    public CharacterInstance _source;
    //target
    public CharacterInstance _target;
    //instance
    public CardInstance _cardInstance;
    //manager
    public BattleManager _battleManager;

    //constructor
    public CardContext(CharacterInstance source, CharacterInstance target, CardInstance card, BattleManager battleManager)
    {
        _source = source;
        _target = target;
        _cardInstance = card;
        _battleManager = battleManager;
    }
}
