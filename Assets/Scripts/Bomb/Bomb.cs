using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Bomb : MonoBehaviour
{
    [SerializeField] Vector3 diection;
    [SerializeField] float speed = 5.0f;
    [SerializeField] Animator animator;

    public GameObject explosion;
    public Action onDestroyed;

    void Update()
    {
        transform.position += diection * (speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        onDestroyed?.Invoke();
        Instantiate(explosion, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
