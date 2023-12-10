using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : MonoBehaviour
{
    [SerializeField] private int damage = 10;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(collision.gameObject.TryGetComponent<HealthSystem>(out healthSystem))
            {
                HealthSystem healthSystem = 
                collision.gameObject.GetComponent<HealthSystem>();
                healthSystem.ChangeHealth(-damage);
            }
        }
    }
}
