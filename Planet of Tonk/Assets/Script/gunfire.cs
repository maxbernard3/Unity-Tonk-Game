using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunfire : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    public GameObject musleFlash;

    private float timeSinceLastFired = 0;

    public static bool canFire = false;

    [SerializeField]
    private float reloadTime = 5;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastFired += Time.deltaTime;
        if (timeSinceLastFired >= reloadTime)
        {
            canFire = true;
        }
        if (Input.GetMouseButtonDown(0) && timeSinceLastFired >= reloadTime)
        {
            Quaternion rot = transform.parent.rotation;
            Instantiate(prefab, transform.position, rot);
            Instantiate(musleFlash, transform.position, rot);
            timeSinceLastFired = 0;
            canFire = false;
        }
    }
}
