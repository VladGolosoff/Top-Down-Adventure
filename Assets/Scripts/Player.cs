using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    
    [SerializeField] private float movingSpeed = 5f;
    

    private void Awake()
    {
        
        _rigidbody = GetComponent<Rigidbody2D>();
        
    }

   
    private void FixedUpdate()
    {
        Vector2 inputVector = GameInput.Instance.GetMovementVector();
        
 
        inputVector = inputVector.normalized;
        
        _rigidbody.MovePosition(_rigidbody.position + inputVector * (movingSpeed * Time.fixedDeltaTime));
    }
}
