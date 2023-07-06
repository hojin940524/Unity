using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   [SerializeField]
   private float moveSpeed;

   [SerializeField]
   private GameObject weapon;

   [SerializeField]
   private Transform shootTransform;
   
   [SerializeField]
    private float shootInterval = 0.05f; //미사일 간격
    private float lastShotTime = 0f;  //최근에 쏜 미사일의 시간

    // Update is called once per frame 
    void Update()
    {
        //키보드로 움직이기
        /*
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        //float verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 moveTo = new Vector3(horizontalInput, 0f, 0f);
        transform.position += moveTo * moveSpeed * Time.deltaTime;
        */ 

        //마우스로 움직이기
        //Debug.Log(Input.mousePosition);
    
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float toX = Mathf.Clamp(mousePos.x, -2.4f, 2.4f);
        transform.position = new Vector3(toX, transform.position.y, transform.position.z);
        if(Input.GetMouseButtonDown(0)){
            Shoot();    
        }
        

    }
    void Shoot(){
        
        if(Time.time - lastShotTime > shootInterval) {
            Instantiate(weapon, shootTransform.position, Quaternion.identity);
            lastShotTime = Time.time;
        }
    }
}

