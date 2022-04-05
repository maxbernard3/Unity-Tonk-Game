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
    private float sensitivity = 100f;

    //Orbit Camera
    [SerializeField]
    private Transform tformCamera;
    [SerializeField]

    private float orbSensitivity = 100f;

    static public Vector3 cameraAngle;

    [SerializeField]
    private float orbitDistance = 10f;

    static public bool sniper = false;

    //I'm starting to think I could reduce the number variable input here

    static public Quaternion cameraRotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        if (sniper == false)
        {
            mainCamera.SetActive(true);
        }
        else
        {
            mainCamera.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (sniper == false)
            {
                sniper = true;
                fstPerson = false;
                mainCamera.GetComponent<Camera>().fieldOfView = 5f;
                tformCamera.transform.localPosition = new Vector3(0, 0, 0);
                tformCamera.transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                sniper = false;
                fstPerson = false;
                mainCamera.GetComponent<Camera>().fieldOfView = 60f;
                tformCamera.transform.localPosition = new Vector3(0, 0, 0);
                tformCamera.transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
        }

        Ray ray2;

        if (Input.GetKeyDown(KeyCode.R))
        {
            RaycastHit hit;
            ray2 = gameObject.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray2, out hit))
            {
                UI.range = ((ushort)hit.distance).ToString();
            }
            else
            {
                UI.range = "10000";
            }
        }

        if (sniper == false)
        {

            if (Input.GetKeyDown("v") == true)
            {
                if (fstPerson == false)
                {
                    fstPerson = true;
                    tformCamera.transform.localPosition = new Vector3(0, 0, 0);
                    tformCamera.transform.localRotation = Quaternion.Euler(0, 0, 0);
                }
                else
                {
                    fstPerson = false;
                    tformCamera.transform.localPosition = new Vector3(0, 0, 0);
                    tformCamera.transform.localRotation = Quaternion.Euler(0, 0, 0);
                }
            }

            if (fstPerson == true)
            {
                cameraAngle.y -= Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
                cameraAngle.x += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
                cameraAngle.y = Mathf.Clamp(cameraAngle.y, -80f, 80f);

                transform.parent.rotation = Quaternion.Euler(cameraAngle.y,cameraAngle.x, 0f);
            }
        }

        if (sniper == true)
        {
            cameraAngle.y -= Input.GetAxis("Mouse Y") * Aiming.rotationSpeed * 2 * Time.deltaTime;
            cameraAngle.x += Input.GetAxis("Mouse X") * Aiming.elevationSpeed * 2 * Time.deltaTime;

            transform.parent.rotation = Quaternion.Euler(cameraAngle.y, cameraAngle.x, 0f);
            transform.position = transform.parent.parent.GetChild(1).position;

            if (Mathf.Abs(transform.rotation.y - transform.parent.parent.GetChild(1).GetChild(0).rotation.y) > 0.01f ||
                Mathf.Abs(transform.rotation.x - transform.parent.parent.GetChild(1).GetChild(0).rotation.x) > 0.01f)
            {
                transform.rotation = transform.parent.parent.GetChild(1).GetChild(0).rotation;
            }

            transform.Translate(Vector3.up * 0.5f);
            transform.Translate(Vector3.left * 0.7f);
            transform.Translate(Vector3.forward * 1.6f);
        }

    }
    private void LateUpdate()
    {
        if(sniper == false)
        {
            if (fstPerson == false)
            {
                cameraAngle.x += Input.GetAxis("Mouse X") * orbSensitivity;
                cameraAngle.y -= Input.GetAxis("Mouse Y") * orbSensitivity;
                cameraAngle.y = Mathf.Clamp(cameraAngle.y, -30, 80);

                Quaternion QT = Quaternion.Euler(cameraAngle.y, cameraAngle.x, 0);
                transform.parent.rotation = Quaternion.Lerp(transform.parent.rotation, QT, Time.deltaTime * 5f);
                tformCamera.localPosition = new Vector3(0f, 0f, orbitDistance * -1f);
            }
        }
    }
}
