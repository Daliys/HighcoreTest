using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // horizontal rotation speed
    public float horizontalSpeed = 1f;
    // vertical rotation speed
    public float verticalSpeed = 1f;
    private float xRotation = 0.0f;
    private float yRotation = 0.0f;
    private Camera cam;
    [SerializeField] private GameObject player;
 
    void Start()
    {
        cam = Camera.main;
        
    }
 
    void Update()
    {
        float mouseX = Input.GetAxis("MouseX") * horizontalSpeed;
        float mouseY = Input.GetAxis("MouseY") * verticalSpeed;
 
        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);
 
        cam.transform.eulerAngles = new Vector3(xRotation, cam.transform.eulerAngles.y, 0.0f);
        player.transform.eulerAngles = new Vector3(0, yRotation, 0);
    }
}
