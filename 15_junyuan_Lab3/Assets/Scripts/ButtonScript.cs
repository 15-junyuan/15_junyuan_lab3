using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    //restart button
    public void RestartBtn()
    {
       
         SceneManager.LoadScene("GamePlay_Level 1");
        
    }
}
