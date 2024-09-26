using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    private Rigidbody2D _rigidbody;
    private float minMovingSpeed = 0.1f;
    private bool isRunning = false;
    [SerializeField] private float movingSpeed = 5f;
    

    private void Awake()
    {
        Instance = this;
        _rigidbody = GetComponent<Rigidbody2D>();
        
    }

   
    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        Vector2 inputVector = GameInput.Instance.GetMovementVector();
        inputVector = inputVector.normalized;
        _rigidbody.MovePosition(_rigidbody.position + inputVector * (movingSpeed * Time.fixedDeltaTime));

        if (Mathf.Abs(inputVector.x) > minMovingSpeed || Mathf.Abs(inputVector.y) > minMovingSpeed)
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
    }

    public bool IsRunning()
    {
        return isRunning;
    }
}
