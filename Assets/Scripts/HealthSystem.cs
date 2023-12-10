using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] UnityEvent deathEvents;
    [SerializeField] private int health;
    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        
    }

    public void ChangeHealth(int value)
    {
        health += value;
        if(health > maxHealth) health = maxHealth;
        if(health <= 0)
        {
            health = 0;
            print("Смерть");
        }
        print($"Здоровье {gameObject.name} изменено на {health}");
    }
}
