using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VN
{
    public class P_AnimController : MonoBehaviour
    {
        [SerializeField]
        private Animator _Panim;

        private int _IsWalkingHash;

        private int _IsWalkLeftHash;
        private int _IsWalkRightHash;

        private int _IsRunningHash;
        private int _IsDancingHash;



        // Start is called before the first frame update
        void Start()
        {
            _Panim = GetComponent<Animator>();

            _IsWalkingHash = Animator.StringToHash("IsWalk");
            _IsWalkLeftHash = Animator.StringToHash("IsWalkLeft");
            _IsWalkRightHash = Animator.StringToHash("IsWalkRight");
            _IsRunningHash = Animator.StringToHash("IsRun");
            _IsDancingHash = Animator.StringToHash("IsDance");
        }

        // Update is called once per frame
        void Update()
        {
            PMovement();
        }

        private void PMovement()
        {
            // get action input 
            bool _forwardPressed = Input.GetKey("w") || Input.GetKey("s") || Input.GetKey("a") || Input.GetKey("d");
            bool _DancePress = Input.GetKey("space");
            bool _runPressed = Input.GetKey("left shift");

            // set animation for action 
            _Panim.SetBool(_IsDancingHash, _DancePress);
            _Panim.SetBool(_IsWalkingHash, _forwardPressed);

            // running animation base on conditional
            if (_forwardPressed && _runPressed)
            {
                _Panim.SetBool(_IsRunningHash, true);
            }
            if (!_forwardPressed || !_runPressed)
            {
                _Panim.SetBool(_IsRunningHash, false);
            }
        }
    }
}