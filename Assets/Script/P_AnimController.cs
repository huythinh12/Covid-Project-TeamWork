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
        private int _IsRunningHash;
        private int _IsJackingHash;

        // Start is called before the first frame update
        void Start()
        {
            _Panim = GetComponent<Animator>();
            _IsWalkingHash = Animator.StringToHash("IsWalk");
            _IsRunningHash = Animator.StringToHash("IsRun");
            _IsJackingHash = Animator.StringToHash("IsJack");

        }

        // Update is called once per frame
        void Update()
        {
            PMovement();
        }

        private void PMovement()
        {
            bool _JackPress = Input.GetKey("space");

            if (_JackPress)
            {
                _Panim.SetBool(_IsJackingHash, true);
            }
            if (!_JackPress)
            {
                _Panim.SetBool(_IsJackingHash, false);
            }



            bool _IsWalk = _Panim.GetBool("IsWalk");
            bool _IsRun = _Panim.GetBool("IsRun");
            bool _forwardPressed = Input.GetKey("w");
            bool _runPressed = Input.GetKey("left shift");

            if (!_IsWalk && _forwardPressed)
            {
                _Panim.SetBool(_IsWalkingHash, true);
            }
            if (_IsWalk && !_forwardPressed)
            {
                _Panim.SetBool(_IsWalkingHash, false);
            }

            if (!_IsRun && (_forwardPressed && _runPressed))
            {
                _Panim.SetBool(_IsRunningHash, true);
            }
            if (_IsRun && (!_forwardPressed || !_runPressed))
            {
                _Panim.SetBool(_IsRunningHash, false);
            }
        }
    }
}