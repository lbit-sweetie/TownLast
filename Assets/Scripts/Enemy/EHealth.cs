using System;
using UnityEngine;

public class EHealth : MonoBehaviour
{
    private float health;

    public void TakeDamage(float amount = 1)
    {
        health -= amount;
        if(health <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        Debug.Log("Enemy Dead!!!");
        Destroy(gameObject);
    }
}