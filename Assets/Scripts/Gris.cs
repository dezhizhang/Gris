using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class Gris : MonoBehaviour
{
    // tqq
    private float _moveFactor;

    // 移动速度
    private float _moveSpeed;

    // 刚体组件
    private Rigidbody2D _rb;

    // 动画组件
    private Animator _animator;

    // 精灵渲染组件
    private SpriteRenderer _spriteRenderer;
    public float jumpForce;

    private void Start()
    {
        _moveSpeed = 5.0f;
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _moveFactor = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
           // _rb.AddForce(new Vector2(0, _moveSpeed)); 
           _rb.AddForce(Vector2.up * jumpForce);
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (_moveFactor > 0)
        {
            _spriteRenderer.flipX = true;
        }
        else if (_moveFactor < 0)
        {
            _spriteRenderer.flipX = false;
        }

        // 移动的方向
        Vector2 moveDir = Vector2.right * _moveFactor;
        // 移动的速度
        Vector2 moveVelocity = moveDir * _moveSpeed;
        Vector2 jumpVelocity = new Vector2(0, _rb.velocity.y);
        _rb.velocity = moveVelocity + jumpVelocity;
        // 设置动画的值
        _animator.SetFloat("MoveX", Mathf.Abs(_rb.velocity.x));
    }
}