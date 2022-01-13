using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketMovementScript : MonoBehaviour
{
    public float speed;

    
    
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

      float horizontalInput = Input.GetAxis("Horizontal");

      transform.position = transform.position + new Vector3(horizontalInput * speed * Time.deltaTime, 0, 0);

      //borderlimt
      if(transform.position.x <= -7.09f)
        {
            transform.position = new Vector3(-7.09f, transform.position.y, transform.position.z);
        }
       else if (transform.position.x >= 7.069f)
        {
            transform.position = new Vector3(7.069f, transform.position.y, transform.position.z);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }



}
