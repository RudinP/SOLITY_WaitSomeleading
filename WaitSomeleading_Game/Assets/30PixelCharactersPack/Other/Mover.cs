using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private Animator _animator;
    private Vector2 _pos;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            _pos.x = Input.GetAxisRaw("Horizontal");
            _pos.y = 0;
            _animator.SetLayerWeight(0, 0);
            _animator.SetLayerWeight(1, 1);
        }
        else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            _pos.x = 0;
            _pos.y = Input.GetAxisRaw("Vertical");
            _animator.SetLayerWeight(0, 0);
            _animator.SetLayerWeight(1, 1);
        }
        else
        {
            _animator.SetLayerWeight(0, 1);
            _animator.SetLayerWeight(1, 0);
        }

        _animator.SetFloat("x", _pos.x);
        _animator.SetFloat("y", _pos.y);
    }
}
