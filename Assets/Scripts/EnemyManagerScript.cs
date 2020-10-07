using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagerScript : MonoBehaviour
{
    public Transform enemy;

    public float speed = .5f;

    private float xPos = 6;
    private float yPos = 5;
    
    public float amplitude = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        //spawn enemy (time based)
        InvokeRepeating("Spawn", 6f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        //make enemy attack base/player
        Debug.Log(transform.position.x + " + " + transform.position.y);
        float offset = Mathf.Sin(Time.time * speed) * amplitude / 2;
        if (transform.position.x > 0f && transform.position.y > 0f)
        { 
            //top right
            transform.position = new Vector2(offset, transform.position.y - speed);
        } 
        else if (transform.position.x < 0f && transform.position.y > 0f)
        {
            //top left
            transform.position = new Vector2(transform.position.x - speed, transform.position.y - speed);
        }
        else if (transform.position.x > 0f && transform.position.y < 0f)
        {
            //bottom right
            transform.position = new Vector2(transform.position.x - speed, transform.position.y - speed);
        }
        else if (transform.position.x < 0f && transform.position.y < 0f)
        {
            //bottom left
            transform.position = new Vector2(transform.position.x - speed, transform.position.y - speed);
        }
    }

    private void Spawn()
    {
        Vector2 loc;
        Transform go = Instantiate(enemy);
        go.transform.parent = this.transform;
        int i = Random.Range(0,100);
        if (i < 25)
        {
            loc = new Vector2(xPos, yPos);
        }
        else if (i < 50)
        {
            loc = new Vector2(xPos, -yPos);
        }
        else if (i < 75)
        {
            loc = new Vector2(-xPos, yPos);
        }
        else
        {
            loc = new Vector2(-xPos, -yPos);
        }
        go.transform.position = loc;
        SpriteRenderer sr = go.GetComponent<SpriteRenderer>();
    }
    
}
