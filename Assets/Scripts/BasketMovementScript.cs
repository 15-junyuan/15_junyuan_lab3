using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BasketMovementScript : MonoBehaviour
{
    //player speed//
    public float speed;
    //Score//
    int Score;

    //Text
    public Text Scoretxt;

    //Audio//
    public AudioSource audioSource;
    public AudioClip audioclip;

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
        //collision with healthy food
        if (other.gameObject.tag == "Healthy")
        {
            audioSource.PlayOneShot(audioclip);
            Score =+ Score + 10;
            Scoretxt.text = "Score: " + Score;
            Destroy(other.gameObject);

            if(Score >= 150)
            {
                SceneManager.LoadScene("GamePlay_Level 2");
            }
        }

        //collision with Unhealthy food
        if(other.gameObject.tag == "Unhealthy")
        {
            audioSource.PlayOneShot(audioclip);
            SceneManager.LoadScene("LoseScene");
        }
    }



}
