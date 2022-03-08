using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    //Tell if I am in FPS or Orbit
    [SerializeField]
    bool fstPerson = true;

    //Comander Camera
    [SerializeField]
	private GameObject mainCamera;

    [SerializeField]
    private Transform player;

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

    private short sniper = 0;
    private Quaternion lastRotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;


        //if (Input.GetKeyDown(KeyCode.LeftShift))
        //{
        //    if (sniper == 0)
        //    {
        //        var cam = mainCamera.
        //        sniper = 1;
        //    }
        //    else
        //    {

        //        sniper = 0;
        //    }
        //}

        if (Input.GetKeyDown("v") == true)
        {
            lastRotation = Quaternion.Euler(tformParent.transform.localEulerAngles.x, tformParent.transform.localEulerAngles.y, 0);
            if (fstPerson == false)
            {
                fstPerson = true;
                tformCamera.transform.localPosition = new Vector3(0, 0, 0);
                tformCamera.transform.localRotation = Quaternion.Euler(0, 0, 0);
                tformParent.transform.localRotation = lastRotation;
            }
            else
            {
                fstPerson = false;
                tformCamera.transform.localPosition = new Vector3(0, 0, 0);
                tformCamera.transform.localRotation = Quaternion.Euler(0, 0, 0);
                tformParent.transform.localRotation = lastRotation;
            }
        }

        if(fstPerson == true)
        {
            xRotation -= mouseY;
            yRotation += mouseX;
            xRotation = Mathf.Clamp(xRotation, -80f, 80f);

            tformParent.transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
        }
    }
    private void LateUpdate()
    {
        if (fstPerson == false)
        {
            localRotation.x += Input.GetAxis("Mouse X") * orbSensitivity;
            localRotation.y -= Input.GetAxis("Mouse Y") * orbSensitivity;
            localRotation.y = Mathf.Clamp(localRotation.y, -30f, 70f);

            Quaternion QT = Quaternion.Euler(localRotation.y, localRotation.x, 0);
            tformParent.rotation = Quaternion.Lerp(tformParent.rotation, QT, Time.deltaTime*5f);
            tformCamera.localPosition = new Vector3(0f, 0f, Mathf.Lerp(tformCamera.localPosition.z, orbitDistance * -1f, Time.deltaTime));
        }
    }
}
