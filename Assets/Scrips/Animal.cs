using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    new Rigidbody2D mybody;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject chargedbullet;
    [SerializeField] float speed;
    float minx, maxx, miny, maxy;
    uint i=0;
    [SerializeField] int life = 6;

    // Start is called before the first frame update
    void Start()
    {
        mybody = GetComponent<Rigidbody2D>();
        Vector2 esqinfiz = (Camera.main).ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 esqsupdere = (Camera.main).ViewportToWorldPoint(new Vector2(1, 1));
        minx = esqinfiz.x;
        maxx = esqsupdere.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(
           Mathf.Clamp(transform.position.x, minx + 0.8f, maxx - 0.8f),
           transform.position.y
           );
        if (transform.position.x>maxx-1f && i!=1)
        {
            speed = -speed;
            i = 1;
        }
        else
            if(transform.position.x<minx+1f && i!=0)
            {
            speed = -speed;
            i = 0;
        }

    }
    private void FixedUpdate()
    {
     
        mybody.velocity = new Vector2(speed, mybody.velocity.y);
    }
  
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="bullet")
        {
            life = life - 1;
        }
        if (collision.gameObject.tag == "chargedbullet")
        {
            life = 0;
        }
        if (life == 0)
        {
            Destroy(gameObject);
        }
    

    }
       

   
    
}
