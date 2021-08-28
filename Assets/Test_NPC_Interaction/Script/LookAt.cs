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
        //Hướng camera để nhìn 
        //"main" được tag là main-camera trong unity
        _cameraToLookAt = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //"transform" vị trí của object
        //Hướng xoay chuyển tới vị trị đích 
        transform.LookAt(_cameraToLookAt.transform);
        //Tạo ra vật lý xoay chuyển với hướng thẳng và chính diện
        //"forward" để trả về pháp tuyến với vector y 
        transform.rotation = Quaternion.LookRotation(_cameraToLookAt.transform.forward);
    }
}
