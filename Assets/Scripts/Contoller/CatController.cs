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

    [SerializeField] private bool flip_01;
    [SerializeField] private bool flip_02;
    [SerializeField] private bool flip_03;
    [SerializeField] private bool flip_04;
    [SerializeField] private bool flip_05;
    [SerializeField] private bool flip_06;

    [SerializeField] private float timer_01;

    [SerializeField] private float timer_02;


    [SerializeField]private float timer_03;


    [SerializeField] private float timer_04;


    [SerializeField] private float timer_05;


    [SerializeField] private float timer_end;

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

        if (timer >= timer_01 & timer < timer_02)
        {
            animator.SetBool("AnimOn", true);

            if(flip_01 == true)
            {
                sprite.flipX = true;
            }
            else
            {
                sprite.flipX = false;
            }

            transform.position = Vector2.MoveTowards(transform.position, target_01.transform.position, 1.0f * Time.deltaTime);
        }

        if (timer >= timer_02 & timer < timer_03)
        {
            if (flip_02 == true)
            {
                sprite.flipX = true;
            }
            else
            {
                sprite.flipX = false;
            }
            //sprite.flipX = true;
            transform.position = Vector2.MoveTowards(transform.position, target_02.transform.position, 1.0f * Time.deltaTime);
        }
        if (timer >= timer_03 & timer < timer_04)
        {
            if (flip_03 == true)
            {
                sprite.flipX = true;
            }
            else
            {
                sprite.flipX = false;
            }

            transform.position = Vector2.MoveTowards(transform.position, target_03.transform.position, 1.0f * Time.deltaTime);
        }
        if (timer >= timer_04 & timer < timer_05)
        {
            if (flip_04 == true)
            {
                sprite.flipX = true;
            }
            else
            {
                sprite.flipX = false;
            }

            transform.position = Vector2.MoveTowards(transform.position, target_04.transform.position, 1.0f * Time.deltaTime);
        }
        if (timer >= timer_05 & timer < timer_end)
        {
            if (flip_05 == true)
            {
                sprite.flipX = true;
            }
            else
            {
                sprite.flipX = false;
            }

            transform.position = Vector2.MoveTowards(transform.position, target_05.transform.position, 1.0f * Time.deltaTime);
        }
        if (timer >= timer_end)
        {
            if (flip_06 == true)
            {
                sprite.flipX = true;
            }
            else
            {
                sprite.flipX = false;
            }

            timer = 0;
            //sprite.flipX = false;
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
