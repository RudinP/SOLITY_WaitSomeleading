using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private Animator _animator;
    private Vector2 _pos;

    public bool notMove = false;
    public bool eventOn = false;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(!notMove)
        {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            {
                _pos.x = Input.GetAxisRaw("Horizontal");
                _pos.y = 0;

                _animator.SetBool("Walking", true);
            }
            else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
            {
                _pos.x = 0;
                _pos.y = Input.GetAxisRaw("Vertical");

                _animator.SetBool("Walking", true);
            }
            else
            {
                _animator.SetBool("Walking", false);
            }

            _animator.SetFloat("x", _pos.x);
            _animator.SetFloat("y", _pos.y);
        }
        else
        {
            if(!eventOn)
            {
                _animator.SetBool("Walking", false);
            }
        }
    }
}
