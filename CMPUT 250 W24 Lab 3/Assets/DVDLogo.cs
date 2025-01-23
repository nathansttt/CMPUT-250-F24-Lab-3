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
    SpriteRenderer sprite;

    public Color flashColor = Color.red; // The color to flash (red in this case)
    public float flashDuration = 0.01f;  // How long to display the flash color
    public int flashCount = 1;          // How many times to flash
    private Color originalColor;

    // Start is called before the first frame update
    void Start()
    {
        //Randomly initialize direction
        direction = new Vector3(Random.Range(-1f,1f), Random.Range(-1f,1f));
        direction.Normalize();
        sprite = GetComponent<SpriteRenderer>();
        originalColor = sprite.color; // Store the original color of the sprite

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

    private IEnumerator Flashing()
    {

        for (int i = 0; i < flashCount; i++)
        {
            sprite.color = flashColor; // Change to the flash color
            yield return new WaitForSeconds(flashDuration); // Wait for the flash duration
            sprite.color = originalColor; // Change back to the original color
            yield return new WaitForSeconds(flashDuration); // Wait before flashing again

        }
    }
// Update is called once per frame
void Update()
    {
        //Move in direction unless we'd go out of bounds, if so bounce with some randomness

        //Vector3 newPosition = transform.position + direction*Time.deltaTime*(speed* speed_increase);
        Vector3 newPosition = transform.position + direction * Time.deltaTime * speed;
        //See if a bounce needs to happen before moving
        if (newPosition.x>X_Max){
            //sprite.color = new Color(1, 0, 0, 1);
            //Debug.Log(sprite.color);
            Debug.Log(sprite.color);
            StartCoroutine(Flashing());
            Debug.Log(sprite.color);
            FlipDirectionX();
            //sprite.color = new Color(1, 1, 1, 1);
            //Debug.Log(sprite.color);
        }
        else if (newPosition.x<-1*X_Max){
            //sprite.color = new Color(1, 1, 1, 1);
            StartCoroutine(Flashing());
            FlipDirectionX();
        }

        if (newPosition.y>Y_Max){
            //sprite.color = new Color(1, 1, 1, 1);
            StartCoroutine(Flashing());
            FlipDirectionY();
        }
        else if (newPosition.y<-1*Y_Max){
            //sprite.color = new Color(1, 1, 1, 1);
            StartCoroutine(Flashing());
            FlipDirectionY();
        }

        //transform.position += direction*Time.deltaTime*(speed* speed_increase);
        transform.position += direction * Time.deltaTime * speed;
    }
}
