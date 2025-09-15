using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Camera _camera;

    [SerializeField] private float _mouseSpeedX = 2f;
    [SerializeField] private float _zoomMultiplier;

    private Vector3 _currentRot;

    

    Vector3 vel = Vector3.zero;
    float Xfloat;
    

    void LateUpdate()
    {
        float MouseX = Input.GetAxis("Mouse X") * _mouseSpeedX;
        float mouseScroll = Input.GetAxis("Mouse ScrollWheel");

        if (Input.GetMouseButton(1))
        {
            Xfloat += MouseX;

            Vector3 newRot = new(0f, Xfloat, 0f);
            _currentRot = Vector3.SmoothDamp(_currentRot, newRot, ref vel, 0.5f * Time.deltaTime);

            transform.localEulerAngles = _currentRot;
        }

        if (mouseScroll > 0f) // zoom in -2 +5 for clamp
        {
            _camera.transform.localPosition = new Vector3(
            Mathf.Clamp(_camera.transform.localPosition.x + _zoomMultiplier, -20f, -2f),
            Mathf.Clamp(_camera.transform.localPosition.y - _zoomMultiplier, 4f, 20f),
            _camera.transform.localPosition.z);
        }

        if (mouseScroll < 0f) // zoom out -14 +17 for clamp
        {
            _camera.transform.localPosition = new Vector3(
            Mathf.Clamp(_camera.transform.localPosition.x - _zoomMultiplier, -20f, -2f),
            Mathf.Clamp(_camera.transform.localPosition.y + _zoomMultiplier, 4f, 20f),
            _camera.transform.localPosition.z);
        }


        
        transform.position = Vector3.SmoothDamp(transform.position, _player.transform.position, ref vel, 0.5f * Time.deltaTime);
    }
}
