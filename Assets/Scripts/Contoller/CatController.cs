using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigid;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Animator animator;

    [SerializeField] private Transform target_01;
    [SerializeField] private Transform target_02;
    [SerializeField] private Transform target_03;
    [SerializeField] private Transform target_04;
    [SerializeField] private Transform target_05;

    float timer;
    Vector3 startPosition;

    private void Start()
    {
        animator.SetBool("AnimOn", false);
    }

    private void Update()
    {
        timer +=  Time.deltaTime;

        Move();
    }

    private void Move()
    {
        startPosition = transform.position;

        if (timer >= 6 & timer < 10)
        {
            animator.SetBool("AnimOn", true);
            transform.position = Vector2.MoveTowards(transform.position, target_01.transform.position, 1.0f * Time.deltaTime);
        }

        if (timer >= 10 & timer < 15)
        {
            sprite.flipX = true;
            transform.position = Vector2.MoveTowards(transform.position, target_02.transform.position, 1.0f * Time.deltaTime);
        }
        if (timer >= 15 & timer < 20)
        {
            transform.position = Vector2.MoveTowards(transform.position, target_03.transform.position, 1.0f * Time.deltaTime);
        }
        if (timer >= 25 & timer < 30)
        {
            transform.position = Vector2.MoveTowards(transform.position, target_04.transform.position, 1.0f * Time.deltaTime);
        }
        if (timer >= 30 & timer < 35)
        {
            transform.position = Vector2.MoveTowards(transform.position, target_05.transform.position, 1.0f * Time.deltaTime);
        }
        if (timer >= 35)
        {
            timer = 0;
            sprite.flipX = false;
        }

        if (startPosition == transform.position)
        {
            animator.SetBool("AnimOn", false);
        }
        else
        {
            animator.SetBool("AnimOn", true);
        }
    }
}
