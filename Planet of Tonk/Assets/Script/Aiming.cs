using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour
{
    [SerializeField]
    private GameObject mainCamera;
    [SerializeField]
    private GameObject sniperCamera;

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
        Ray ray;
        if (CameraControler.sniper)
        {

        }
        else
        {
            ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            Plane rot = new Plane(transform.right, transform.position);
            Vector3 aimpoint = ray.GetPoint(alignment);


            float direction = 0f;

            if (rot.GetSide(aimpoint))
                direction = 1f;
            else
                direction = -1f;

            float angle = transform.localEulerAngles.y + direction * rotationSpeed * Time.deltaTime;
            if (angle > 180)
                angle -= 360;

            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, angle, transform.localEulerAngles.z);

            float gunElevation;

            gunElevation = Mathf.Asin((aimpoint.y - transform.position.y) / alignment) * (180 / Mathf.PI);
            gunElevation = Mathf.Clamp(gunElevation, maxDepresion, maxElevation);

            transform.GetChild(0).localRotation = Quaternion.RotateTowards(transform.GetChild(0).localRotation
                , Quaternion.Euler(gunElevation * -1, 0, 0), Time.deltaTime * elevationSpeed);
        }
    }
}