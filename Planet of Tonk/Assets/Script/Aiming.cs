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

    [SerializeField]
    private float rotationSpeed = 10f;
    [SerializeField]
    private float elevationSpeed = 10f;

    public float gunAlignment = 500f;

    private Vector3 savedElev = new Vector3(0, 0, 0);
    private Vector3 savedRot = new Vector3(0, 0, 0);

    static public float GunElevation = 0f;
    static public float TuretAngle = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray;
        if (CameraControler.sniper)
        {

        }
        else
        {
            ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            Vector3 aimpoint = ray.GetPoint(gunAlignment);

            Plane rot = new Plane(transform.right, transform.position);
            if (Mathf.Abs(rot.GetDistanceToPoint(aimpoint)) < 0)
                return;

            if (rot.GetSide(aimpoint))
                Rotate(1.0f); //right
            else
                Rotate(-1.0f); //left


            Plane elev = new Plane(transform.GetChild(0).up, transform.GetChild(0).position);
            if (Mathf.Abs(elev.GetDistanceToPoint(aimpoint)) < 0)
                return;

            if (elev.GetSide(aimpoint))
                Elevate(1.0f); //up
            else
                Elevate(-1.0f); //down

            TuretAngle = transform.rotation.y;
            GunElevation = transform.GetChild(0).localRotation.x;
        }
    }

    public virtual void Elevate(float direction)
    {
        direction = Mathf.Clamp(-direction, -1.0f, 1.0f);

        float angle = transform.GetChild(0).localEulerAngles.x + direction * elevationSpeed * Time.deltaTime;
        if (angle > 180)
            angle -= 360;

        angle = Mathf.Clamp(angle, -maxElevation, -maxDepresion);

        transform.GetChild(0).localEulerAngles = new Vector3(angle, transform.GetChild(0).localEulerAngles.y, transform.GetChild(0).localEulerAngles.z);
    }

    public virtual void Rotate(float direction)
    {
        direction = Mathf.Clamp(direction, -1.0f, 1.0f);

        float angle = transform.localEulerAngles.y + direction * rotationSpeed * Time.deltaTime;
        if (angle > 180)
            angle -= 360;

        //if (Mathf.Abs(minRotation) + Mathf.Abs(maxRotation) > 0)
        //    angle = Mathf.Clamp(angle, minRotation, maxRotation);

        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, angle, transform.localEulerAngles.z);
    }

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            transform.localEulerAngles = savedRot;
            transform.GetChild(0).localEulerAngles = savedElev;
        }
        else
        {
            savedRot = transform.localEulerAngles;
            savedElev = transform.GetChild(0).localEulerAngles;
        }
    }
}