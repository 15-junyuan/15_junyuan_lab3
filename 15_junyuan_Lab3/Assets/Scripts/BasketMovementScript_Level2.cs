using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BasketMovementScript_Level2 : MonoBehaviour
{
    //player speed//
    public float speed;

    //Score//
    int Score;

    //Text//
    public Text Scoretxt;
    public Text Timetxt;

    public float time;
    public bool timerisrunning = false;

    // Start is called before the first frame update
    void Start()
    {
        //scoretxt//
        Scoretxt.text = "Score: " + Score;

        //timer
        timerisrunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        float horizontalInput = Input.GetAxis("Horizontal");

        transform.position = transform.position + new Vector3(horizontalInput * speed * Time.deltaTime, 0, 0);

        //borderlimt
        if (transform.position.x <= -7.09f)
        {
            transform.position = new Vector3(-7.09f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x >= 7.069f)
        {
            transform.position = new Vector3(7.069f, transform.position.y, transform.position.z);
        }

        if (timerisrunning)
        {
            if(time > 0)
            {
                time -= Time.deltaTime;
                DisplayTime(time);
            }
            else
            {
                SceneManager.LoadScene("WinScene");
            }
        }

    }
    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        Timetxt.text = string.Format("Time: {0:00}:{1:00}", minutes, seconds);
    }
    

    private void OnCollisionEnter(Collision other)
    {
        //collision with healthy food
        if (other.gameObject.tag == "Healthy")
        {
            Score = +Score + 10;
            Scoretxt.text = "Score: " + Score;
            Destroy(other.gameObject);
        }

        //collision with Unhealthy food
        if (other.gameObject.tag == "Unhealthy")
        {
            SceneManager.LoadScene("LoseScene");
        }
    }
}
