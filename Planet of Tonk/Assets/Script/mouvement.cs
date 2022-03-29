using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouvement : MonoBehaviour
{
    public float enginePower = 150.0f;
    private float power = 0.0f;
    private float brake = 0.0f;
    private float steer = 0.0f;
    public float maxSteer = 25.0f;
    public float maxSpeed = 40f;
    public WheelCollider FrontLeft;
    public WheelCollider FrontRight;
    public WheelCollider CenterLeft;
    public WheelCollider CenterRight;
    public WheelCollider RearLeft;
    public WheelCollider RearRight;

    void Start()
    {
        gameObject.GetComponent<Rigidbody>().centerOfMass = new Vector3(0f, -0.5f, 0.3f);
    }

    void Update()
    {

        power = Input.GetAxis("Vertical") * enginePower * Time.deltaTime * 250.0f;
        steer = Mathf.Abs(Input.GetAxis("Horizontal")) * Mathf.Sign(Input.GetAxis("Vertical")) * enginePower * Time.deltaTime * 200.0f;
        brake = Input.GetKey("space") ? gameObject.GetComponent<Rigidbody>() .mass * 10f : 0.0f;

        if (brake > 0.0)
        {
            FrontLeft.brakeTorque = brake;
            FrontRight.brakeTorque = brake;
            RearLeft.brakeTorque = brake;
            RearRight.brakeTorque = brake;
            CenterLeft.brakeTorque = brake;
            CenterRight.brakeTorque = brake;
            RearLeft.motorTorque = 0.0f;
            RearRight.motorTorque = 0.0f;
            FrontLeft.motorTorque = 0.0f;
            FrontRight.motorTorque = 0.0f;
            CenterLeft.motorTorque = 0.0f;
            CenterRight.motorTorque = 0.0f;
        }
        else
        {
            FrontLeft.brakeTorque = 0f;
            FrontRight.brakeTorque = 0f;
            RearLeft.brakeTorque = 0f;
            RearRight.brakeTorque = 0f;
            CenterLeft.brakeTorque = 0f;
            CenterRight.brakeTorque = 0f;
            FrontLeft.motorTorque = power;
            FrontRight.motorTorque = power;
            RearLeft.motorTorque = power;
            RearRight.motorTorque = power;
            CenterLeft.motorTorque = power;
            CenterRight.motorTorque = power;
        }

        if (steer != 0f)
        {
            if (Input.GetAxis("Horizontal") > 0.0f)
            {
                FrontLeft.brakeTorque = 0f;
                FrontRight.brakeTorque = 0f;
                RearLeft.brakeTorque = 0f;
                RearRight.brakeTorque = 0f;
                CenterLeft.brakeTorque = 0f;
                CenterRight.brakeTorque = 0f;
                RearLeft.motorTorque = steer * 1.8f;
                FrontLeft.motorTorque = steer * 1.8f;
                CenterLeft.motorTorque = steer * 1.8f;
                RearRight.motorTorque = 0.2f * steer;
                FrontRight.motorTorque = 0.2f * steer;
                CenterRight.motorTorque = 0.2f * steer;
            }
            else
            {
                FrontLeft.brakeTorque = 0f;
                FrontRight.brakeTorque = 0f;
                RearLeft.brakeTorque = 0f;
                RearRight.brakeTorque = 0f;
                CenterLeft.brakeTorque = 0f;
                CenterRight.brakeTorque = 0f;
                RearRight.motorTorque = steer * 1.8f;
                FrontRight.motorTorque = steer * 1.8f;
                CenterRight.motorTorque = steer * 1.8f;
                RearLeft.motorTorque = 0.2f * steer;
                FrontLeft.motorTorque = 0.2f * steer;
                CenterLeft.motorTorque = 0.2f * steer;
            }
        }

        gameObject.GetComponent<Rigidbody>().velocity = Vector3.ClampMagnitude(gameObject.GetComponent<Rigidbody>().velocity, maxSpeed);
    }
}
