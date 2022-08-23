using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public float mouseSensitivity;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        Vector3 fromRotCamera = transform.rotation.eulerAngles;
        Vector3 fromRotPlayer = transform.parent.rotation.eulerAngles;

        fromRotCamera.x -= mouseY * mouseSensitivity;
        fromRotPlayer.y += mouseX * mouseSensitivity;

        transform.rotation = Quaternion.Euler(fromRotCamera);
        transform.parent.rotation = Quaternion.Euler(fromRotPlayer);


    }
}
