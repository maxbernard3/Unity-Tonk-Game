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
    public static float maxElevation = 30;
    [SerializeField]
    public static float maxDepresion = -10;

    [SerializeField]
    public static float rotationSpeed = 30f;
    [SerializeField]
    public static float elevationSpeed = 30f;

    public float gunAlignment = 1000f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray;
        ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        Vector3 aimpoint = ray.GetPoint(gunAlignment);

        Plane rot = new Plane(transform.right, transform.position);
        if (Mathf.Abs(rot.GetDistanceToPoint(aimpoint)) < 0.01f)
        {
            if (rot.GetSide(aimpoint))
                Rotate(0.1f); //right
            else
                Rotate(-0.1f); //left
        }
        else
        {
            if (rot.GetSide(aimpoint))
                Rotate(1); //right
            else
                Rotate(-1); //left
        }


        Plane elev = new Plane(transform.GetChild(0).up, transform.GetChild(0).position);
        if (Mathf.Abs(elev.GetDistanceToPoint(aimpoint)) < 0.01f)
        {
            if (elev.GetSide(aimpoint))
                Elevate(0.1f); //up
            else
                Elevate(-0.1f); //down
        }
        else
        {
            if (elev.GetSide(aimpoint))
                Elevate(1); //up
            else
                Elevate(-1); //down
        }

    }

    public virtual void Elevate(float direction)
    {
        direction = Mathf.Clamp(-direction, -1f, 1f);

        float angle = transform.GetChild(0).localEulerAngles.x + direction * elevationSpeed * Time.deltaTime;
        if (angle > 180)
            angle -= 360;

        angle = Mathf.Clamp(angle, -maxElevation, -maxDepresion);

        transform.GetChild(0).localEulerAngles = new Vector3(angle, transform.GetChild(0).localEulerAngles.y, transform.GetChild(0).localEulerAngles.z);
    }

    public virtual void Rotate(float direction)
    {
        direction = Mathf.Clamp(direction, -1f, 1f);

        float angle = transform.localEulerAngles.y + direction * rotationSpeed * Time.deltaTime;
        if (angle > 180)
            angle -= 360;

        //if (Mathf.Abs(minRotation) + Mathf.Abs(maxRotation) > 0)
        //    angle = Mathf.Clamp(angle, minRotation, maxRotation);

        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, angle, transform.localEulerAngles.z);
    }
}