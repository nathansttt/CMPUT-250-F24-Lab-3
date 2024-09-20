using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiggerAndSmaller : MonoBehaviour
{
    public Vector3 intensity = new Vector3(2f, 2f, 1f);
    private Vector3 original;
    public float maxScale = 5f;
    public float minScale = 1f; 
    private bool is_growing = true;
    // Start is called before the first frame update
    void Start()
    {
        original = transform.localScale;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 scaleChange = intensity*Time.deltaTime;
        Vector3 newScale = transform.localScale;

        if (is_growing){
            newScale += scaleChange;

            if (newScale.x >= maxScale || newScale.y >= maxScale){
                newScale = new Vector3(maxScale, maxScale, 1);
                is_growing = false;
            }
        }
        else{
            newScale -= scaleChange;

            if (newScale.x <= minScale || newScale.y <= minScale){
                newScale = new Vector3(minScale, minScale, 1);
                is_growing = true;
            }
        }
        transform.localScale = newScale;
    }
}
