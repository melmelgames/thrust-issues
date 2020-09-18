using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Health
{
    private static int health;
    private static int maxHealth = 100;

    public static int GetHealth()
    {
        return health;
    }

    public static int GetMaxHealth()
    {
        return maxHealth;
    }

    public static void AddHealth(int value)
    {
        health += value;
        if(health > maxHealth)
        {
            health = maxHealth;
        }
    }

    public static void SubtractHealth(int damage)
    {
        health -= damage;
    }

    public static void InitializeStatic()
    {
        health = maxHealth;
    }
}
