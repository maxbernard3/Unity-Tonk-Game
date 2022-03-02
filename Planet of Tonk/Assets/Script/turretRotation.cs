using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretRotation : MonoBehaviour
{
    [SerializeField]
    private GameObject Camera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        gameObject.transform.localRotation = Quaternion.Euler(0, Camera.transform.localEulerAngles.y, 0);
    }
}
