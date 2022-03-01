using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    public GameObject prefab;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        for (int i = 0; i < 5; i++)
        {
            Vector3 position = new Vector3(Random.Range(transform.position.x - 30.0f, transform.position.x + 30.0f), 30, Random.Range(transform.position.z - 30.0f, transform.position.z + 30.0f));
            Instantiate(prefab, position, Quaternion.identity);
        }
    }
}
