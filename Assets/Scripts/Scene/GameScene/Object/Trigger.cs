using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trigger : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
   {
      if(other.CompareTag("Player"))
      {
         if (SceneManager.GetAllScenes().Length -1> SceneManager.GetActiveScene().buildIndex)
         {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
         }
         else
         {
           Application.Quit();
         }
         
      }
   }
}
