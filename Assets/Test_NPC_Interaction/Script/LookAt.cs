using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    [SerializeField]
    public Camera _cameraToLookAt;
    

    // Start is called before the first frame update
    void Start()
    {

        _cameraToLookAt = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.LookAt(_cameraToLookAt.transform);
        transform.rotation = Quaternion.LookRotation(_cameraToLookAt.transform.forward);
    }
}
