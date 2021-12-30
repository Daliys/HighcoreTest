using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    
    private Camera _mainCamera;
    private Vector3 _currentMovement;
    private CharacterController _characterController;
    [SerializeField] private PlayerInfo playerInfo;

    
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _mainCamera = Camera.main;
    }


    private void Update()
    {
      _currentMovement.x = Input.GetAxis("Horizontal");
      _currentMovement.z = Input.GetAxis("Vertical");
      
        if (_currentMovement.magnitude >= 0.05f)
        {
            Vector3 moveDirection = Vector3.zero;
            transform.eulerAngles = new Vector3(0, _mainCamera.transform.eulerAngles.y, 0);
            float targetAngle = Mathf.Atan2(_currentMovement.x, _currentMovement.z) * Mathf.Rad2Deg +
                                _mainCamera.transform.eulerAngles.y;
            moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            _characterController.Move(moveDirection * (Time.deltaTime * playerInfo.speed));
        }
    }

    
}
