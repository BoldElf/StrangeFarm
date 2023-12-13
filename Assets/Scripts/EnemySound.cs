using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySound : MonoBehaviour
{
    [SerializeField] private AudioSource hitSound;

    private Enemy enemy;

    private void Start()
    {
        enemy = gameObject.GetComponent<Enemy>();
        enemy.EnemyHitSound += SoundPlay;
    }
    private void OnDestroy()
    {
        //enemy.EnemyHitSound -= SoundPlay;
    }

    private void SoundPlay()
    {
        hitSound.Play();
    }
}
