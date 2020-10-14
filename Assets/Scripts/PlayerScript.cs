using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private float xPos, yPos;
    public float speed = 1f;
    public float leftWall, rightWall, topWall, bottomWall;

    public GameObject projectile;
    public GameObject projectileSpawner;
    public KeyCode fireKey;
    public float health;

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
        
        
        
        //if (Input.GetKeyDown(fireKey))
        //{
        //    Instantiate(projectile, new Vector2(transform.position.x, transform.position.y + 0.5f), Quaternion.identity);
        //}
        
        //if (Input.GetKeyDown(fireKey)) {
        //    Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    Vector2 dir = mousePos - (new Vector2(transform.position.x, transform.position.y));
        //    dir.Normalize ();
        //    GameObject proj = Instantiate (projectile, transform.position, Quaternion.identity)as GameObject;
        //    proj.GetComponent<Rigidbody2D> ().velocity = dir * speed; 
        //}



        transform.localPosition = new Vector3(xPos, yPos, 0);
        
        //attempts to make player look at mouse
        //source: https://answers.unity.com/questions/879839/moving-in-the-direction-of-mouse.html
        //Quaternion newRotation = transform.LookAt(Input.mousePosition); //establish a new rotation
        //transform.rotation = newRotation; //kinda works but doesn't because it rotates the y instead of just the x
        //ransform.rotation.x = Input.mousePosition.x; //rotate the player to the quaternion
        //this.transform.LookAt(Input.mousePosition, Vector3.up);
        
        //source: https://www.youtube.com/watch?v=Geb_PnF1wOk
        
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rot = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rot; 
            

        //if (Input.GetKeyDown(fireKey))
        //{
            //Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Vector2 dir2 = mousePos - (new Vector2(transform.position.x, transform.position.y));
            //dir2.Normalize ();
        //    GameObject proj = Instantiate(projectile, projectileSpawner.transform.position, transform.rotation) as GameObject;
        //    proj.transform.rotation = rot;
        //}
        
        // source: https://answers.unity.com/questions/736511/shoot-towards-mouse-in-unity2d.html
        
        if (Input.GetKeyDown(fireKey)) {
            Vector2 target = Camera.main.ScreenToWorldPoint( new Vector2(Input.mousePosition.x,  Input.mousePosition.y) );
            Vector2 myPos = new Vector2(transform.position.x,transform.position.y);
            Vector2 direction = target - myPos;
            direction.Normalize();
            Quaternion rotation = Quaternion.Euler( 0, 0, Mathf.Atan2 ( direction.y, direction.x ) * Mathf.Rad2Deg - 90 );
            GameObject proj = (GameObject) Instantiate( projectile, myPos, rotation);
            proj.GetComponent<Rigidbody2D>().velocity = direction * speed;
        }

        if (health < 0)
        {
            GameManagerScript.S.GameOver();
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("enemy hit the player");
            Destroy(other.gameObject);
            health -= .2f;
        }
    }
}
