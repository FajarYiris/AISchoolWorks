using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 6.0f;
    Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector2 inputMove = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        inputMove.Normalize();

        Vector3 movement = new Vector3(inputMove.x, 0, inputMove.y) * _moveSpeed;
        movement.y = _rb.velocity.y;

        _rb.velocity = transform.TransformDirection(movement);
    }
}
