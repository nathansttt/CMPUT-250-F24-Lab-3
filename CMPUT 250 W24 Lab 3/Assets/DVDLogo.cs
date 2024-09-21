using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DVDLogo : MonoBehaviour
{
    //Speed it moves at
    public float speed = 3;

    //Bounds of the screen
    public float X_Max = 5, Y_Max = 4;

    //Current direction
    private Vector3 direction;

    // Resize Parameters
    public Vector3 minScale = new Vector3(0.8f, 0.8f, 1f); // Minimum size
    public Vector3 maxScale = new Vector3(1.2f, 1.2f, 1f); // Maximum size
    public float resizeSpeed = 0.1f;  // How quickly the size changes

    // Start is called before the first frame update
    void Start()
    {
        // Randomly initialize direction
        direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        direction.Normalize();
    }

    private void FlipDirectionX()
    {
        direction.x *= -1;
        direction.x += Random.Range(-0.1f, 0.1f);
        direction.y += Random.Range(-0.1f, 0.1f);
        direction.Normalize();
    }

    private void FlipDirectionY()
    {
        direction.y *= -1;
        direction.x += Random.Range(-0.1f, 0.1f);
        direction.y += Random.Range(-0.1f, 0.1f);
        direction.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        // Move in direction unless we'd go out of bounds
        Vector3 newPosition = transform.position + direction * Time.deltaTime * speed;

        // Bounce off walls
        if (newPosition.x > X_Max || newPosition.x < -X_Max)
        {
            FlipDirectionX();
        }

        if (newPosition.y > Y_Max || newPosition.y < -Y_Max)
        {
            FlipDirectionY();
        }

        transform.position += direction * Time.deltaTime * speed;

        // random size change
        ChangeSize();
    }

    // framely size change
    void ChangeSize()
    {
        Vector3 randomChange = new Vector3(
            Random.Range(-resizeSpeed, resizeSpeed),
            Random.Range(-resizeSpeed, resizeSpeed),
            0);

        transform.localScale += randomChange;

        // min/max limits
        transform.localScale = new Vector3(
            Mathf.Clamp(transform.localScale.x, minScale.x, maxScale.x),
            Mathf.Clamp(transform.localScale.y, minScale.y, maxScale.y),
            transform.localScale.z);
    }
}