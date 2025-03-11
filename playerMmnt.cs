using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class playerMmnt : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float speed = 5;
    public float maxX = 7.5f;
    float movement_horizontal;
    
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
        movement_horizontal = Input.GetAxis("Horizontal");

        if((movement_horizontal > 0 && transform.position.x < maxX) || (movement_horizontal < 0 && transform.position.x > -maxX))
        {
            transform.position += Vector3.right * movement_horizontal * speed * Time.deltaTime;
        }

    }
}
