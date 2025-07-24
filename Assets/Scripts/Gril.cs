using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gril : MonoBehaviour
{
    // tqq
    private float _moveFactor;

    // 移动速度
    private float _moveSpeed;

    // 刚体组件
    private Rigidbody2D _rb;

    private void Start()
    {
        _moveSpeed = 5.0f;
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _moveFactor = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        // 移动的方向
        Vector2 moveDir = Vector2.right * _moveFactor;
        // 移动的速度
        Vector2 moveVelocity = moveDir * _moveSpeed;
        Vector2 jumpVelocity = new Vector2(0, _rb.velocity.y);
        _rb.velocity = moveVelocity + jumpVelocity;
    }
}