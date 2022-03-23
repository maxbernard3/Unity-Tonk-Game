using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shell : MonoBehaviour
{

    [SerializeField]
    public GameObject explosionSFX;

    private float gravity = 0f; 
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        Instantiate(explosionSFX, collision.GetContact(0).point , Quaternion.identity);
    }
}
