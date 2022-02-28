using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controles : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject chargedbullet;
    [SerializeField] float speed;
    float disparosrestantes = 4;
    float minx,maxx,miny,maxy;
    public float shotcold =0.3f;
    float lastshot = 0;
   
    float mododisparo = 1;
    float tiempocarga = 0f;
    float disparocargado = 0;


    // Start is called before the first frame update
    private void LateUpdate()
    {
        
    }
    void Start()
    {
     Vector2 esqinfiz=(Camera.main).ViewportToWorldPoint(new Vector2(0,0));
     Vector2 esqsupdere=(Camera.main).ViewportToWorldPoint(new Vector2(1,1));
        minx = esqinfiz.x;
        maxx = esqsupdere.x;
        miny = esqinfiz.y;
        maxy = esqsupdere.y;
       

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x, minx + 0.8f, maxx - 0.8f),
            Mathf.Clamp(transform.position.y, miny + 0.8f, maxy - 0.8f)
            );

        transform.rotation = new Quaternion(
            transform.rotation.x, transform.rotation.y, Mathf.Clamp(transform.rotation.z, -0.1f, 0.1f), transform.rotation.w
            );



        float movH = Input.GetAxis("Horizontal");
        float movV = Input.GetAxis("Vertical");
        float rot = transform.rotation.z;
        transform.Translate(new Vector2(movH * speed * Time.deltaTime, movV * speed * Time.deltaTime));


        transform.Rotate(new Vector3(transform.rotation.x,
            transform.rotation.y,
            movH * 5f * Time.deltaTime));
        if (movH * speed == 0)
        {
            transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 0f, transform.rotation.w);
        }


        if (Input.GetKeyDown(KeyCode.Z))
        {
            mododisparo = -mododisparo;
            Debug.Log("modo de disparo " + mododisparo);
        }

        if (mododisparo == 1)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                shot();
            }
        }
        else
        if (mododisparo == -1)
        { 
          
                chargedshot();
            Debug.Log("disparo cargado"+disparocargado);
            Debug.Log("disparos restantes" + disparosrestantes);
      }
    
            
 

    }
    void shot()
    {
        if (Time.time - lastshot > shotcold)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            lastshot = Time.time;
        }
       
    }
    void chargedshot()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            tiempocarga += 1 * Time.deltaTime;
            if (tiempocarga >= 3)
            {
                disparocargado = 1;
            }


        }            
        if (Input.GetKeyUp(KeyCode.Space))
            {
                if (disparocargado == 1 && disparosrestantes!=0)
                {
                    Instantiate(chargedbullet, transform.position, transform.rotation);
                    disparocargado = 0;
                    tiempocarga = 0;
                disparosrestantes -= 1;
                }
            else
            {
                tiempocarga = 0;
            }
            }
            
        
    }
}
