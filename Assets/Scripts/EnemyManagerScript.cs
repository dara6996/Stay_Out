using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagerScript : MonoBehaviour
{
    public Transform enemy;

    public float speed = .5f;

    private float xPos = 6;
    private float yPos = 5;

    // Start is called before the first frame update
    void Start()
    {
        //spawn enemy (time based)
        InvokeRepeating("Spawn", 5f, .7f);
    }

    // Update is called once per frame
    void Update()
    {
        //make enemy attack base/player
        
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
