using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInstance : MonoBehaviour
{
    public int Health;

    public void TakeDamage(int amount)
    {
        Health -= amount;
        Debug.Log(name + " took damage: " + amount);
    }

    public void Heal(int amount)
    {
        Health += amount;
        Debug.Log(name + " healed: " + amount);
    }
}
