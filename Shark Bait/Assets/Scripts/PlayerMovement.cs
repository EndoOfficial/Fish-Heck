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
    private Vector2 startPosition;
    private Vector2 endPosition;

    private void OnEnable()
    {
        GameEvents.OnSwipeMove += OnSwipeMove;
        GameEvents.OnSwipeEnd += OnSwipeEnd;
    }

    private void OnDisable()
    {
        GameEvents.OnSwipeMove -= OnSwipeMove;
        GameEvents.OnSwipeEnd -= OnSwipeEnd;
    }

    private void OnSwipeMove(Vector2 MovePosition, Vector2 MoveDirestion, float MoveSpeed, int TouchCount)
    {
        startPosition = MovePosition;
    }
    private void OnSwipeEnd(Vector2 MovePosition, Vector2 MoveDirestion, float MoveSpeed, int TouchCount)
    {
        endPosition = MovePosition;
        if (Vector2.Distance(startPosition, endPosition) > 0)
        {
            MoveRight();
        }
        if (Vector2.Distance(startPosition, endPosition) < 0)
        {
            MoveLeft();
        }
    }
    private void MoveRight()
    { //send the ball diagonally right up, then fall
        _direction = new Vector3(1, 0, 1);
        StartCoroutine(FallTimer());
    }
    private void MoveLeft()
    { //send the ball diagonally left up, then fall
        _direction = new Vector3(-1, 0, 1);
        StartCoroutine(FallTimer());
    }
    private void FixedUpdate()
    {
        //gives the object speed
        if (_direction.sqrMagnitude != 0)
        {
            _rigidbody.AddForce(_direction * speed);
        }
    }
    private IEnumerator FallTimer()
    { //timer to fall
        yield return new WaitForSeconds(0.5f);
        _rigidbody.AddForce(_direction * speed * 0);
        _direction = new Vector3(0,0,-2);
    }
}