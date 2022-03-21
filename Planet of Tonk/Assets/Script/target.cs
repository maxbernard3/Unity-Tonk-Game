using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    static public float point = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && gameObject.GetComponent<Animator>().GetBool("is fallen"))
        {
            gameObject.GetComponent<Animator>().SetBool("is fallen", false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "shell")
        {
            gameObject.GetComponent<Animator>().SetBool("is fallen", true);

            point += 1;
        }
    }
}
