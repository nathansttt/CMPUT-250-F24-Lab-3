﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DVDLogo : MonoBehaviour
{
    //Speed it moves at
    public float speed = 3;

    //Bounds of the screen (could get these with camera bounds but we can do this since it's a fixed camera)
    public float X_Max = 5, Y_Max = 4;

    //Current direction
    private Vector3 direction;

    // Scaling variables for growing and shrinking
    public float scaleSpeed = 2.0f;  
    public float minScale = 0.5f;  
    public float maxScale = 1.5f; 
    private bool growing = true;    

    // Start is called before the first frame update
    void Start()
    {
        //Randomly initialize direction
        direction = new Vector3(Random.Range(-1f,1f), Random.Range(-1f,1f));
        direction.Normalize();

    }

    private void FlipDirectionX(){
        direction.x*=-1;
        direction.x+= Random.Range(-0.1f,0.1f);
        direction.y+= Random.Range(-0.1f,0.1f);
        direction.Normalize();
    }

    private void FlipDirectionY(){
        direction.y*=-1;
        direction.x+= Random.Range(-0.1f,0.1f);
        direction.y+= Random.Range(-0.1f,0.1f);
        direction.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        //Move in direction unless we'd go out of bounds, if so bounce with some randomness

        Vector3 newPosition = transform.position + direction*Time.deltaTime*speed;

        //See if a bounce needs to happen before moving
        if (newPosition.x>X_Max){
            FlipDirectionX();
            
        }
        else if (newPosition.x<-1*X_Max){
            FlipDirectionX();
        }

        if (newPosition.y>Y_Max){
            FlipDirectionY();
        }
        else if (newPosition.y<-1*Y_Max){
            FlipDirectionY();
        }

        transform.position += direction * Time.deltaTime * speed;

        Vector3 scale = transform.localScale;
        if (growing)
        {
            scale += Vector3.one * scaleSpeed * Time.deltaTime;
            if (scale.x >= maxScale)
            {
                growing = false;
            }
        }
        else
        {
            scale -= Vector3.one * scaleSpeed * Time.deltaTime;
            if (scale.x <= minScale)
            {
                growing = true;
            }
        }
        transform.localScale = scale;  // Apply the scaling change
    }
}
