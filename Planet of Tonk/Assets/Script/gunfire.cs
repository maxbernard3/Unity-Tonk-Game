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

    [SerializeField]
    private float speed = 100f;
    // Start is called before the first frame update
    void Start()
    {
    }

    void Fire()
    {
        Quaternion rot = transform.parent.rotation;
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.3f);
        GameObject newShell = Instantiate(prefab, pos, rot);
        newShell.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, speed*30));
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
            Fire();
            Instantiate(musleFlash, transform.position, rot);
            timeSinceLastFired = 0;
            canFire = false;
        }
    }
}
