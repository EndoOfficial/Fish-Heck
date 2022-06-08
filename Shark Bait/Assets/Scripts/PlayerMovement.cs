using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//use events to access the touchinput and then use them to tigger vector 3 movement
public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    private Vector3 _direction;
    public Rigidbody _rigidbody;

    private void OnEnable()
    {
        GameEvents.OnSwipeMove += OnSwipeMove;
    }

    private void OnDisable()
    {
        GameEvents.OnSwipeMove -= OnSwipeMove;
    }
    private void OnSwipeMove(Vector2 MovePosition, Vector2 MoveDirestion, float MoveSpeed, int TouchCount)
    {
        _direction = Vector3.forward;
        Debug.Log("here");
    }

    private void FixedUpdate()
    {
        //gives the object speed
        if (_direction.sqrMagnitude != 0)
        {
            _rigidbody.AddForce(_direction * speed);
        }
    }
}