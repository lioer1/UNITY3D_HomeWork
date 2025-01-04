using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float moveSpeed = 1500;
    public float rotationSpeed = 100;
    public float maxDistance = 10;
    public GameObject door;
    public float raycastHeight = 0;
    
    private Animator animator;
    private CharacterController cc;
    private Vector3 move;
    private bool isOpen=true;
    private AudioSource audioSource;
 
    private void Awake()
    {
        animator = GetComponent<Animator>();

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
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                animator.SetBool("Walk", true);
            }
            else
            {
                animator.SetBool("Walk", false);
            }
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
        RaycastHit[] hits = Physics.RaycastAll(this.transform.position+new Vector3(0,raycastHeight,0), this.transform.forward, maxDistance);
        foreach (var hit in hits)
        {
            Debug.Log(hit.collider.name);
            if (hit.collider.CompareTag("RaycastTarget"))
            {
                
               hit.collider.gameObject.SetActive(true);
            }
        }
    }

   
}