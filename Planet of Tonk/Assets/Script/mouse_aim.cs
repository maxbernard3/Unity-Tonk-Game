using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse_aim : MonoBehaviour
{
    [SerializeField]
	private GameObject FP;
    
    [SerializeField]
	private GameObject TP;

    [SerializeField]
    private Transform player;

    [SerializeField]
    private float sensitivity = 100f;

    private float xRotation = 0f;
    private float yRotation = 0f;

    bool fstPerson = true;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; 
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        if(Input.GetKeyDown("v") == true)
        {
            if(fstPerson == false)
            {
                fstPerson = true;
                FP.SetActive(true);
                TP.SetActive(false);
            }
            else
            {
                fstPerson = false;
                FP.SetActive(false);
                TP.SetActive(true);
            }
        }

        if(fstPerson == true)
        {
            xRotation -= mouseY;
            yRotation += mouseX;
            xRotation = Mathf.Clamp(xRotation, -80f, 80f);

            transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
        }
        else
        {
            xRotation -= mouseY;
            yRotation += mouseX;
            xRotation = Mathf.Clamp(xRotation, -80f, 80f);  

            transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
        }
    }
}
