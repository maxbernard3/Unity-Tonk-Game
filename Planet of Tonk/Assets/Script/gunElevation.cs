using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunElevation : MonoBehaviour
{
    [SerializeField]
    private GameObject Camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float elevation = Camera.transform.localEulerAngles.x;
        elevation = Mathf.Clamp(elevation, -10f, 20f);
        gameObject.transform.localRotation = Quaternion.Euler(elevation, 0, 0);
    }
}
