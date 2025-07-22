using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gril : MonoBehaviour
{
    // tqq
    private float _walkFactor;
    private void Update()
    {
        _walkFactor =  Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        
    }
}
