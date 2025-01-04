using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene2Trigger : MonoBehaviour
{
    public GameObject door;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            door.GetComponent<Animator>().SetBool("Open",true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            door.GetComponent<Animator>().SetBool("Open",false);
        }
    }
}
