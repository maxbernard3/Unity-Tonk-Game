using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sniperControler : MonoBehaviour
{
    [SerializeField]
    private GameObject mainCamera;
    [SerializeField]
    private GameObject sniperCamera;

    private float xRotation = 0f;
    private float yRotation = 0f;

    [SerializeField]
    private float maxElevation = 30;
    [SerializeField]
    private float maxDepresion = -20;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (CameraControler.sniper == false)
            {
                sniperCamera.SetActive(true);
                mainCamera.SetActive(false);
                CameraControler.sniper = true;
            }
            else
            {
                sniperCamera.SetActive(false);
                mainCamera.SetActive(true);
                CameraControler.sniper = false;
            }
        }

        if (CameraControler.sniper)
        {
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

            float mouseX = Input.GetAxis("Mouse X") * 50 * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * 50 * Time.deltaTime;

            xRotation -= mouseY;
            yRotation += mouseX;

            xRotation = Mathf.Clamp(xRotation, maxDepresion, maxElevation);

            transform.parent.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            transform.parent.parent.localRotation = Quaternion.Euler(0f, yRotation, 0f);
        }
    }
}
