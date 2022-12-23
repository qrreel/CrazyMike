using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Security.Cryptography;

public class Pig : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Bomb bombPrefab;

    static readonly int IsAttacking = Animator.StringToHash("isAttacking");
    static readonly int IsPicking = Animator.StringToHash("isPicking");
    static readonly int IsDead = Animator.StringToHash("isDead");

    void Start()
    {
        float attackRate = UnityEngine.Random.Range(2f, 5f);
        InvokeRepeating(nameof(Attack), attackRate, attackRate);
    }

    void Idle()
    {
        animator.SetBool(IsPicking, false);
    }

    void Attack()
    {
        if (!this.gameObject.activeInHierarchy) return;
        animator.SetBool(IsAttacking, true);
    }

    void Throw()
    {
        animator.SetBool(IsAttacking, false);
        Instantiate(bombPrefab, transform.position, Quaternion.identity);
        animator.SetBool(IsPicking, true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Hammer"))
        {
            animator.SetBool(IsDead, true);
        }
    }
}
