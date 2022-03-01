using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriger : MonoBehaviour
{
    [SerializeField]
    private Animator doorAnimator;

    private void OnTriggerEnter(Collider other)
    {
        doorAnimator.SetBool("Door Open", true);
    }

    private void OnTriggerExit(Collider other)
    {
        doorAnimator.SetBool("Door Open", false);
    }
}
