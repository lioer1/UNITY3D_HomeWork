using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.GameObject());
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            this.GetComponent<AudioSource>().volume += 0.1f;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            this.GetComponent<AudioSource>().volume -= 0.1f;
        }
    }
}
