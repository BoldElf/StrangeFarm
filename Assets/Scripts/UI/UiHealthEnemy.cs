using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiHealthEnemy : MonoBehaviour
{
    [SerializeField] private GameObject[] health;

    private Enemy enemy;

    private void Start()
    {
        enemy = gameObject.GetComponentInParent<Enemy>();
        enemy.EnemyDamage += ResetEnemyHealth;
        drowEnemyHealth();
    }

    private void drowEnemyHealth()
    {
        for (int i = 0; i < enemy.EnemyHealth; i++)
        {
            health[i].SetActive(true);
        }
    }

    private void ResetEnemyHealth()
    {
        DestroyEnemyHealth();
        drowEnemyHealth();
    }

    private void DestroyEnemyHealth()
    {
        for (int i = 0; i < health.Length; i++)
        {
            health[i].SetActive(false);
        }
    }
}
