using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    GameObject attackArea;

    bool isAttacking = false;
    float timeToAttack = 0.25f;
    float timer = 0f;

    Player Anim;

    void Awake()
    {
        Anim = FindObjectOfType<Player>();
    }

    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
        attackArea.SetActive(isAttacking);
    }

    void Update()
    {
        bool isHiting = Input.GetButtonDown("Fire1");
        if(isHiting) Attack();

        if(isAttacking)
        {
            timer += Time.deltaTime;
            if(timer >= timeToAttack)
            {
                timer = 0f;
                isAttacking = false;
                attackArea.SetActive(isAttacking);
            }
        }
    }

    void Attack()
    {
        isAttacking = true;
        Anim.animator.SetBool(Anim.IsAttacking, true);
        attackArea.SetActive(isAttacking);
    }
}
