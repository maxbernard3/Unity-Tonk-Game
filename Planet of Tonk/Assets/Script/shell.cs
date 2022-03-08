using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shell : MonoBehaviour
{
    [SerializeField]
    private float Shell_speed = 60;

    [SerializeField]
    public GameObject explosionSFX;

    private Quaternion trajectory;
    private float startTime;

    [SerializeField]
    private bool calibrationLog = false;

    private bool once1 = true;
    private bool once2 = true;

    private float a, b;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.realtimeSinceStartup;
        trajectory = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * Shell_speed);
        trajectory.x += Time.deltaTime * 0.05f;
        transform.localRotation = trajectory;

        if (calibrationLog)
        {
            if ((Time.realtimeSinceStartup - startTime) > 0.1 && once1)
            {
                a = trajectory.x * (180 / Mathf.PI);
                once1 = false;
            }

            if ((Time.realtimeSinceStartup - startTime) > 1.1 && once2)
            {
                b = trajectory.x * (180 / Mathf.PI);
                once2 = false;
                Debug.Log(b - a);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(Time.realtimeSinceStartupAsDouble - startTime > 0.1)
        {
            Destroy(gameObject);
            Instantiate(explosionSFX, collision.contacts[0].point, Quaternion.identity);
        }
    }
}
