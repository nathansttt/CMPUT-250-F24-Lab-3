using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DVDLogo : MonoBehaviour
{
    //Speed it moves at
    public float speed = 2;
    public float speed_increase = 2;

    //Bounds of the screen (could get these with camera bounds but we can do this since it's a fixed camera)
    public float X_Max = 5, Y_Max = 4;

    //Current direction
    private Vector3 direction;

    // color of the sprite
    SpriteRenderer sprite; // to be able to change the color of the sprite

    public Color flashColor = Color.red; // The sprite with flash red
    public float flashDuration = 0.01f;  // How long to show the change of color
    public int flashCount = 1;          // How many times to flash
    private Color originalColor;        // will store the original color

    // Start is called before the first frame update
    void Start()
    {
        //Randomly initialize direction
        direction = new Vector3(Random.Range(-1f,1f), Random.Range(-1f,1f));
        direction.Normalize();
        sprite = GetComponent<SpriteRenderer>(); // creates game object to be able to change color of sprite
        originalColor = sprite.color; // here actually stores the original color of the sprite

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

    private IEnumerator Flashing() // function to be able to flash the color of the sprite
                                   // IEnumerator supports interation without affecting game play
                                   // here stops and resumes over multiple frames without affecting the main game
                                   // help from chatgpt
    {

        for (int i = 0; i < flashCount; i++) // for loop that changes back and forth from flash color back to original color
        {
            sprite.color = flashColor; // Change to the flash color
            yield return new WaitForSeconds(flashDuration); // pauses for the flash duration
            sprite.color = originalColor; // Change back to the original color
            yield return new WaitForSeconds(flashDuration); // Wait before flashing again

        }
    }
// Update is called once per frame
void Update()
    {
        //Move in direction unless we'd go out of bounds, if so bounce with some randomness

        Vector3 newPosition = transform.position + direction*Time.deltaTime*(speed* speed_increase);
        
        //See if a bounce needs to happen before moving
        if (newPosition.x>X_Max){
            StartCoroutine(Flashing());
            FlipDirectionX();
        }
        else if (newPosition.x<-1*X_Max){
            StartCoroutine(Flashing());
            FlipDirectionX();
        }

        if (newPosition.y>Y_Max){
            StartCoroutine(Flashing());
            FlipDirectionY();
        }
        else if (newPosition.y<-1*Y_Max){
            StartCoroutine(Flashing());
            FlipDirectionY();
        }

        transform.position += direction*Time.deltaTime*(speed* speed_increase);
    }
}
