using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    //source: https://docs.unity3d.com/ScriptReference/Vector2.MoveTowards.html
    
    private float speed = 0.8f;
    private Vector2 target;
    private Vector2 position;
    
    // Start is called before the first frame update
    void Start()
    {
        target = new Vector2(0.0f, 0.0f);
        position = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;

        // move sprite towards the target location
        transform.position = Vector2.MoveTowards(transform.position, target, step);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }

        if(other.gameObject.tag == "HomeBase")
        {
            Destroy(this.gameObject);
        }
		
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
        
        if(other.gameObject.tag == "HomeBase")
        {
            Destroy(this.gameObject);
        }
		
    }
}
