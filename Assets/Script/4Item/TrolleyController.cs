using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VN
{
    public class TrolleyController : MonoBehaviour
    {
        [SerializeField]
        private Transform _Player;
        private CharacterController _PCharacterController;
        private Rigidbody _PRigibody;

        [SerializeField]
        private Animator _PlayerAnim;

        [SerializeField]
        private bool _trolleyActive;
        bool isInTransition;

        [SerializeField]
        private Transform _StandPoint;
        [SerializeField]
        private Vector3 _Standingoffset;
        [SerializeField]
        private Transform _ExitPoint;
        [SerializeField]
        public float _transitionSpeed = 0.2f;

        // Start is called before the first frame update
        void Start()
        {
            _PCharacterController = GetComponent<CharacterController>();
            _PRigibody = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            if (_trolleyActive && isInTransition) Exit();
            else if (!_trolleyActive && isInTransition) Enter();
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Press E");
                isInTransition = true;
            }

        }

        private void Enter()
        {
            //Disable Components
            _PCharacterController.enabled = false;
            _PRigibody.useGravity = false;

            //Move Player to designated stand point
            _Player.position = Vector3.Lerp(_Player.position, _StandPoint.position + _Standingoffset, _transitionSpeed);
            _Player.rotation = Quaternion.Slerp(_Player.rotation, _StandPoint.rotation, _transitionSpeed);

            //Set Player animation to standing
            Debug.Log("Standing Trolley");
            _PlayerAnim.SetBool("IsStand", true);

            //The Reset - Check
            if (_Player.position == _StandPoint.position + _Standingoffset)
            {
                isInTransition = false;
                _trolleyActive = true;
            }
        }
        private void Exit()
        {
            //Move Player to designated exit point
            _Player.position = Vector3.Lerp(_Player.position, _ExitPoint.position, _transitionSpeed);

            //Set Player animation idle
            Debug.Log("Walk Trolley");
            _PlayerAnim.SetBool("IsIdle", true);

            //The Reset - Check
            if (_Player.position == _ExitPoint.position)
            {
                isInTransition = false;
                _trolleyActive = true;
            }

            //Enable Components
            _PCharacterController.enabled = true;
            _PRigibody.useGravity = true;
        }
    }
}