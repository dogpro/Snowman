using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    [SerializeField] private Transform _player;
    [Header ("Limits")]
    [SerializeField] private float _upLimitAngleY; 
    [SerializeField] private float _downLimitAngleY;
    [Header("Zoom")]
    [SerializeField] private float _zoomSpeed; 
    [SerializeField] private float _zoomMax; 
    [SerializeField] private float _zoomMin;
    [Header("Cam Rotation")]
    [SerializeField] private float _mouseSensitivity;
    [Header("Occlusion")]
    [SerializeField] private LayerMask _camOcclusion;
    
    private float _axisX, _axisY = -35f;
    private RaycastHit _wallHit = new RaycastHit();
    private Vector3 _offset;


    void Start()
    {
        _offset = new Vector3(_offset.x, _offset.y, -_zoomMax);
        transform.position = _player.position + _offset;
    }

    void Update()
    {
        CameraZoom();
        CameraRotation();
        transform.position = transform.rotation * _offset + _player.position;
        CameraOcclusion();
    }

    private void CameraZoom()
    {
        if (Input.GetAxis(GlobalConst.MouseScrollWheel) > 0) _offset.z += _zoomSpeed;
        else if (Input.GetAxis(GlobalConst.MouseScrollWheel) < 0) _offset.z -= _zoomSpeed;
        _offset.z = Mathf.Clamp(_offset.z, -_zoomMax, -_zoomMin);
    }
    private void CameraRotation()
    {
        if (Input.GetAxis(GlobalConst.RMB) > 0)
        {
            _axisX = transform.localEulerAngles.y + Input.GetAxis(GlobalConst.MouseAxisX) * _mouseSensitivity;
            _axisY += Input.GetAxis(GlobalConst.MouseAxisY) * _mouseSensitivity;
            _axisY = Mathf.Clamp(_axisY, -_upLimitAngleY, -_downLimitAngleY);
        }
        transform.localEulerAngles = new Vector3(-_axisY, _axisX, 0);
    }
    private void CameraOcclusion()
    {
        if (Physics.Linecast(_player.position, transform.position, out _wallHit, _camOcclusion))
            transform.position = new Vector3(_wallHit.point.x + _wallHit.normal.x * 0.5f, _wallHit.point.y + _wallHit.normal.y * 0.5f, _wallHit.point.z + _wallHit.normal.z * 0.5f);
    }
}
