using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private CharacterController _cCtrler;

    [SerializeField]
    private float _speed = 12f;
    [SerializeField]
    private float _gravity = -9.81f;
    [SerializeField]
    private float _jumpHeight = 3f;


    [SerializeField]
    private Transform _groundCheck;
    [SerializeField]
    private float _groundDistance = 0.4f;

    [SerializeField]
    private LayerMask _groundMask;


    [SerializeField]
    Vector3 _velocity;
    [SerializeField]
    bool IsGrounded;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        IsGrounded = Physics.CheckSphere(_groundCheck.position, _groundDistance, _groundMask); // Điều kiện check layer đặt đúng ý mình chưa

        if (IsGrounded && _velocity.y < 0) // Check có chạm vào mặt đất
        {
            _velocity.y = -2f; // Vận tốc giữ
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        _cCtrler.Move(move * _speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && IsGrounded)
        {
            _velocity.y = Mathf.Sqrt(_jumpHeight * -2f * _gravity);
        }

        _velocity.y += _gravity * Time.deltaTime;// ko phải tiếp tục update

        _cCtrler.Move(_velocity * Time.deltaTime); 
    }
}
