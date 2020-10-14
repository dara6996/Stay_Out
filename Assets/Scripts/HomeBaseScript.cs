using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeBaseScript : MonoBehaviour
{
    public float health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health < 0)
        {
            GameManagerScript.S.GameOver();
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("enemy hit the base");
            Destroy(other.gameObject);
            health -= .2f;
        }
        
        if (other.gameObject.tag == "Projectile")
        {
            Debug.Log("player hit the base");
            Destroy(other.gameObject);
            health -= .2f;
        }
    }
}
