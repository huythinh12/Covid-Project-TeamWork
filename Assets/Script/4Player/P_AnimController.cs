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

            bool _IsWalk = _Panim.GetBool("IsWalk");

            bool _forwardPressed = Input.GetKey("w");

            bool _IsLeftPressed = Input.GetKey("a");

            bool _DancePress = Input.GetKey("space");

            bool _IsRightPressed = Input.GetKey("d");

            bool _IsRun = _Panim.GetBool("IsRun");
            bool _runPressed = Input.GetKey("left shift");




            if (_DancePress)
            {
                _Panim.SetBool(_IsDancingHash, true);
            }
            if (!_DancePress)
            {
                _Panim.SetBool(_IsDancingHash, false);
            }


           

            if (!_IsWalk && _forwardPressed)
                
            {
                _Panim.SetBool(_IsWalkingHash, true);
            }
            else
            if (_IsWalk && !_forwardPressed)
            {
                _Panim.SetBool(_IsWalkingHash, false);
            }
            //bool _IsWalkLeft = _Panim.GetBool("IsWalkLeft");
            else
            if (_IsLeftPressed || _forwardPressed && _IsLeftPressed)
            {
                _Panim.SetBool(_IsWalkLeftHash, true);
            }
            else
            if (!_IsLeftPressed)
            {
                _Panim.SetBool(_IsWalkLeftHash, false);
            }
            //bool _IsWalkRight = _Panim.GetBool("IsWalkRight");
            
            if ( _IsRightPressed || _forwardPressed && _IsRightPressed)
            {
                Debug.Log("Right");
                _Panim.SetBool(_IsWalkRightHash, true);
                
            }
            else
            if (!_IsRightPressed)
            {
                _Panim.SetBool(_IsWalkRightHash, false);
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