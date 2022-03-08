using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    [SerializeField]
    private float maxElevation;
    [SerializeField]
    private float maxDepresion;

    private float alignment = 500f;
    [SerializeField]
    private float rotationSpeed = 10f;
    [SerializeField]
    private float elevationSpeed = 10f;

    static public float gunAlignment = 500f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Dollar) && alignment < 2000)
        {
            alignment -= 100;
        }
        if (Input.GetKeyDown(KeyCode.Minus) && alignment > 200)
        {
            alignment += 100;
        }

        gunAlignment = alignment;

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        Vector3 aimpoint = ray.GetPoint(alignment);

        float turretAngle = Mathf.Atan2((aimpoint.x - transform.position.x) , (aimpoint.z - transform.position.z))*(180/Mathf.PI);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, turretAngle, 0), Time.deltaTime * rotationSpeed);

        float gunElevation;

        gunElevation = Mathf.Asin((aimpoint.y - transform.position.y) / alignment) * (180 / Mathf.PI);
        gunElevation = Mathf.Clamp(gunElevation, maxDepresion, maxElevation);

        transform.GetChild(0).localRotation = Quaternion.RotateTowards(transform.GetChild(0).localRotation
            , Quaternion.Euler(gunElevation * -1, 0, 0), Time.deltaTime * elevationSpeed);
    }
}
