using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VN
{
    public class P_MovementController : MonoBehaviour
    {
        [SerializeField]
        private CharacterController _Player;

        [SerializeField]
        private Transform _cam;

        [SerializeField]
        private float _speed = 4f;

        [SerializeField]
        private float _turnSmoothTime = 0.1f;

        [SerializeField]
        private float _turnSmoothVelocity;

        [SerializeField]
        private Transform _groundCheck;
        [SerializeField]
        private float _groundDistance = 0.4f;
        [SerializeField]
        private LayerMask _groundMask;

        [SerializeField]
        private float _gravity = -9.81f;
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
            IsGrounded = Physics.CheckSphere(_groundCheck.position, _groundDistance, _groundMask);
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

            if (direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + _cam.eulerAngles.y; // Tính Toán cho Hướng cái đầu mới xoay
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, _turnSmoothTime); // Làm cho xoay góc nhìn mướt hơn góc nhìn, Update cách mỗi 0.1s làm cho dễ hơn,
                transform.rotation = Quaternion.Euler(0f, angle, 0f); //Cho phép nguyên cái nhân vậy xoay luôn

                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward; // Bắt đầu nó lấy hướng di chuyển

                _Player.Move(moveDir.normalized * _speed * Time.deltaTime); // Đưa vào cho character controller
            }

            if (IsGrounded && _velocity.y < 0)
            {
                _velocity.y = -2f;
            }
            _velocity.y += _gravity * Time.deltaTime;
        }
    }
}