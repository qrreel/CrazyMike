using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] public Animator animator;

    static readonly int IsRunning = Animator.StringToHash("isRunning");
    public readonly int IsAttacking = Animator.StringToHash("isAttacking");
    static readonly int IsHit = Animator.StringToHash("isHit");
    static readonly int IsDead = Animator.StringToHash("isDead");
    static readonly int IsWinning = Animator.StringToHash("isWinning");

    float _currentVelocity;
    Rigidbody2D _rigidbody;

    Door Door;
    EndGame EndGame;
    Health Health;

    bool isAlive = true;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        Door = FindObjectOfType<Door>();
        EndGame = FindObjectOfType<EndGame>();
        Health = FindObjectOfType<Health>();
    }

    void Update()
    {
        if (isAlive)
        {
            _rigidbody.velocity = new Vector2(_currentVelocity, _rigidbody.velocity.y);
            Jump();
        }
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        if(isAlive)
        {
            _currentVelocity = ctx.ReadValue<float>() * speed;

            if (animator)
            {
                Vector3 localScale = transform.localScale;
                if (_currentVelocity > 0) localScale = new Vector3(1, localScale.y, localScale.z);
                if (_currentVelocity < 0) localScale = new Vector3(-1, localScale.y, localScale.z);

                transform.localScale = localScale;

                if (Mathf.Abs(_currentVelocity) > 0f) animator.SetBool(IsRunning, true);
                if (Mathf.Abs(_currentVelocity) == 0f) animator.SetBool(IsRunning, false);
            }
        }
    }

    void Idle()
    {
        animator.SetBool(IsAttacking, false);
        animator.SetBool(IsHit, false);
    }

    void Jump()
    {
        bool isJumping = Input.GetButtonDown("Jump");

        if(isJumping)
        {
            Vector2 jump = new Vector2(_rigidbody.velocity.x, jumpSpeed);
            _rigidbody.velocity = jump;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.layer == LayerMask.NameToLayer("Bomb"))
        {
            Health.livesNum -= 1;
            Health.UpdateLives();

            if(Health.livesNum == 0)
            {
                animator.SetBool(IsDead, true);
                isAlive = false;
                EndGame.GameOver();
            }
            else
            {
                animator.SetBool(IsHit, true);
            }
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Door") && Door.isOpen)
        {
            animator.SetBool(IsWinning, true);
            EndGame.GameOver();
        }
    }
}
