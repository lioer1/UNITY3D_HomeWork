using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public class Player_Capsule : MonoBehaviour
{

    public float moveSpeed = 1500;
    public float rotationSpeed = 100;
    public float maxDistance = 10;
    public GameObject door;
    public float raycastHeight = 0;

 
    private CharacterController cc;
    private Vector3 move;
    private bool isOpen=true;
    private AudioSource audioSource;
 
    private void Awake()
    {
      
        cc = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
      
        
        if (!Camera.IsFree)
        {

            //移动
            move = Input.GetAxis("Horizontal") * this.transform.right +
                   Input.GetAxis("Vertical") * this.transform.forward;
            cc.SimpleMove(move * Time.deltaTime * moveSpeed);
      
            //旋转

            this.transform.Rotate(Input.GetAxis("Mouse X") * Vector3.up * rotationSpeed * Time.deltaTime);

            if (Input.GetMouseButtonDown(0))
            {
                RayCast();
                audioSource.Play();
            }
        }


    }

    private void RayCast()
    {
        
        Debug.Log("RayCast");
        //RaycastHit[] hits = Physics.RaycastAll(this.transform.position+new Vector3(0,raycastHeight,0), this.transform.forward, maxDistance);
        RaycastHit[] hits = Physics.RaycastAll(this.transform.position+new Vector3(0,raycastHeight,0), -this.transform.up, maxDistance);
        Debug.DrawRay(this.transform.position + new Vector3(0, raycastHeight, 0), -this.transform.up * maxDistance, Color.red, 2);
        
        foreach (var hit in hits)
        {
            Debug.Log(hit.collider.name);
            if (hit.collider.CompareTag("RaycastTarget"))
            {
               ActiveAll( GetAllChild(hit.collider.gameObject)); 
                
            }
        }
    }


    private List<GameObject> GetAllChild(GameObject parent)
    {
        List<GameObject> list = new List<GameObject>();
       
        for (int i = 0; i <parent.transform.childCount; i++)
        {
            if (parent.transform.GetChild(i).childCount > 0)
            {
                GetAllChild(parent.transform.GetChild(i).gameObject); 
            }
           list.Add(parent.transform.GetChild(i).gameObject);
        }

        return list;
    }

    private void ActiveAll(List<GameObject> list)
    {
        foreach (var obj in list)
        {
           obj.SetActive(true);
        }
    }

}