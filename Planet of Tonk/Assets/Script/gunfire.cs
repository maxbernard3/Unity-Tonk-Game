using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunfire : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Quaternion rot = transform.parent.rotation;
            Instantiate(prefab, transform.position, rot);
        }
    }
}
