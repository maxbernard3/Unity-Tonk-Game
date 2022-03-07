using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shell : MonoBehaviour
{
    [SerializeField]
    private float Shell_speed = 60;

    [SerializeField]
    public GameObject explosionSFX;

    private double startTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.realtimeSinceStartupAsDouble;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * Shell_speed);
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
