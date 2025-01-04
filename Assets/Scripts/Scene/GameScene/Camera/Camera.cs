using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    //摄像机对目标对象 在xyz上的偏移位置
    public Vector3 offsetPos;

    //看向位置的y偏移值
    public float bodyHeight;
   
    //移动速度
    public float moveSpeed=10;
    
    //旋转速度
    public float rotationSpeed=50;

    
    
    private static bool isFree=false;
    public static bool IsFree => isFree;
    
    private Vector3 targetPos;
    private Quaternion targetRotation;
    
    public Transform targetTransform;


    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    // Update is called once per frame
    void LateUpdate()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            isFree=!isFree;
        }

        if (!isFree)
        {
            FollowTarget();
        }
        else
        {
            FreeCamera();
        }
        
        
    }


    public void FollowTarget()
    {
        if(targetTransform == null)
            return;
        //根据目标对象计算摄像机的目标和角度  
        
        targetPos=targetTransform.position + 
                  targetTransform.forward * offsetPos.z + 
                  targetTransform.right * offsetPos.x + 
                  Vector3.up * offsetPos.y;
        
        
        //差值运算 让摄像机不停向目标点靠拢
        this.transform.position = Vector3.Lerp(this.transform.position, targetPos, moveSpeed * Time.deltaTime);
        
        //旋转的计算
        targetRotation = Quaternion.LookRotation((targetTransform.position+ Vector3.up * bodyHeight ) - this.transform.position );
        
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    private void FreeCamera()
    {
        
        //移动
        this.transform.Translate(Input.GetAxis("Horizontal") * Vector3.right* moveSpeed * Time.deltaTime);
        this.transform.Translate(Input.GetAxis("Vertical") * Vector3.forward * moveSpeed * Time.deltaTime);
        //旋转
        this.transform.Rotate(Input.GetAxis("Mouse Y") * Vector3.left * rotationSpeed * Time.deltaTime);
        this.transform.Rotate(Input.GetAxis("Mouse X") * Vector3.up * rotationSpeed * Time.deltaTime);
    }


   
}

  

