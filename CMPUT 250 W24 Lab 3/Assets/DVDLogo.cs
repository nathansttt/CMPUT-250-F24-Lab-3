using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DVDLogo : MonoBehaviour
{
    //Speed it moves at
    public float speed = 3;

    //Bounds of the screen (could get these with camera bounds but we can do this since it's a fixed camera)
    public float X_Max = 5, Y_Max = 4;

    //Scale change variables
    public float scaleChangeRate = 0.5f;
    private bool isShrinking = true; // Starts by shrinking

    //Current direction
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        //Randomly initialize direction
        direction = new Vector3(Random.Range(-1f,1f), Random.Range(-1f,1f));
        direction.Normalize();
    }

    private void FlipDirectionX(){
        direction.x *= -1;
        direction.x += Random.Range(-0.1f,0.1f);
        direction.y += Random.Range(-0.1f,0.1f);
        direction.Normalize();
        ToggleShrinking(); // Toggle shrinking/growing on bounce
    }

    private void FlipDirectionY(){
        direction.y *= -1;
        direction.x += Random.Range(-0.1f,0.1f);
        direction.y += Random.Range(-0.1f,0.1f);
        direction.Normalize();
        ToggleShrinking(); // Toggle shrinking/growing on bounce
    }

    private void ToggleShrinking() {
        isShrinking = !isShrinking;
    }

    // Update is called once per frame
    void Update()
    {
        //Move in direction unless we'd go out of bounds, if so bounce with some randomness
        Vector3 newPosition = transform.position + direction * Time.deltaTime * speed;

        //See if a bounce needs to happen before moving
        if (newPosition.x > X_Max || newPosition.x < -1 * X_Max)
        {
            FlipDirectionX();
        }

        if (newPosition.y > Y_Max || newPosition.y < -1 * Y_Max)
        {
            FlipDirectionY();
        }

        // Apply the movement
        transform.position += direction * Time.deltaTime * speed;

        // Handle shrinking or growing
        if (isShrinking)
        {
            transform.localScale -= Vector3.one * scaleChangeRate * Time.deltaTime;
        }
        else
        {
            transform.localScale += Vector3.one * scaleChangeRate * Time.deltaTime;
        }

        // Ensure the object doesn't shrink too much
        transform.localScale = Vector3.Max(transform.localScale, Vector3.one * 0.1f); // Minimum scale
    }
}
