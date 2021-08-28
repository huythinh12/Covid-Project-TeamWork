using UnityEngine;

public class Mouse_Look : MonoBehaviour
{
    [SerializeField]
    private float _mouseSense = 100f;

    [SerializeField]
    private Transform _playerBody;

    [SerializeField]
    private float _xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        MouseRotation();
    }

    private void MouseRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * _mouseSense * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSense * Time.deltaTime;

        _xRotation -= mouseY;

        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);

        _playerBody.Rotate(Vector3.up * mouseX);
    }
}
