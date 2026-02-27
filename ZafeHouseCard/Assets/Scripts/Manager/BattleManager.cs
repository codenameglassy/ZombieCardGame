using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance;

    [Header("Battle")]
    public CharacterInstance _currentPlayerInstance;
    public CharacterInstance _currentZombieInstance;

    private void Awake()
    {
        Instance = this;
    }




    

}
