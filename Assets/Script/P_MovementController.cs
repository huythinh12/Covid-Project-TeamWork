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

        // Update is called once per frame
        void Update()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

            if ( direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + _cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, _turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward ;

                _Player.Move(moveDir.normalized * _speed * Time.deltaTime);
            }


        }
    }
}