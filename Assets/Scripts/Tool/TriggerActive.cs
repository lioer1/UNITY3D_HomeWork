using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerActive : MonoBehaviour
{
    
    public GameObject[] objs;

    private void OnTriggerEnter(Collider other)
    {
    
        if (other.CompareTag("Player"))
        {
            
            foreach (var obj in objs)
            {
                obj.SetActive(true);
              
            }
        }
    }
}
