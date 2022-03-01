using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raindrop : MonoBehaviour
{
    [SerializeField]
    public GameObject prefab;

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        Instantiate(prefab, collision.contacts[0].point, Quaternion.identity);
    }
}
