using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse_aim : MonoBehaviour
{
    [SerializeField]
    private float sensitivity = 100f;

    private float xRotation = 0f;
    private float yRotation = 0f;

    //Orbit Camera
    [SerializeField]
    private Transform tformCamera;
    [SerializeField]
    private Transform tformParent;
    [SerializeField]
    private float orbSensitivity = 100f;

    private Vector3 localRotation;

    [SerializeField]
    private float orbitDistance = 10f;

    //Tell if I am in FPS or Orbit
    bool fstPerson = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    private void LateUpdate()
    {
        localRotation.x += Input.GetAxis("Mouse X") * orbSensitivity;
        localRotation.y -= Input.GetAxis("Mouse Y") * orbSensitivity;
        localRotation.y = Mathf.Clamp(localRotation.y, 0f, 90f);

        Quaternion QT = Quaternion.Euler(localRotation.y, localRotation.x, 0);
        tformParent.rotation = Quaternion.Lerp(tformParent.rotation, QT, Time.deltaTime * 3f);
        tformCamera.localPosition = new Vector3(0f, 0f, Mathf.Lerp(tformCamera.localPosition.z, orbitDistance * -1f, Time.deltaTime));
    }
}
