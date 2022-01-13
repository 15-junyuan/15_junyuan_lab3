using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BasketMovementScript : MonoBehaviour
{
    public float speed;
    int Score;

    public Text Scoretxt;
    
   
    // Start is called before the first frame update
    void Start()
    {
        Scoretxt.text = "Score: " + Score;
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

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Healthy")
        {
            Score =+ Score + 10;
            Scoretxt.text = "Score: " + Score;
            Destroy(other.gameObject);
        }
    }



}
