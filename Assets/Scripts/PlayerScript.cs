using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private float xPos, yPos;
    public float speed = 1f;
    public float leftWall, rightWall, topWall, bottomWall;

    // Start is called before the first frame update
    void Start()
    {
        yPos = 1;
    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetKey(KeyCode.A)) {
            if (xPos > leftWall) {
                xPos -= speed;
            }
        }

        if (Input.GetKey(KeyCode.D)) {
            if (xPos < rightWall) {
                xPos += speed;
            }
        }
        
        if (Input.GetKey(KeyCode.S)) {
            if (yPos > bottomWall) {
                yPos -= speed;
            }
        }

        if (Input.GetKey(KeyCode.W)) {
            if (yPos < topWall) {
                yPos += speed;
            }
        }
        
        transform.localPosition = new Vector3(xPos, yPos, 0);
    }
}
