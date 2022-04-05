using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sniperControler : MonoBehaviour
{
    [SerializeField]
    private GameObject mainCamera;
    [SerializeField]
    private GameObject sniperCamera;

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
    }

    private void LateUpdate()
    {
        
    }
}
