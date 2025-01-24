using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bounceCount : MonoBehaviour
{
    // Keep Bounce Count
    public static bounceCount instance;
    int bounce = 0;
    public Text bounceText;

    private void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        bounceText.text = bounce.ToString()+ " Bounces";
    }

    public void Addpoint() {
        bounce += 1;
        
        if (bounce <= 100)
        {
            bounceText.text = bounce.ToString()+ " Bounces";
        } else
        {
            bounceText.text = "Oh God Bounces";
        }
    }
}
