using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    public void MoveScene(int a)
    {
        switch (a)
        {
            case 0:
                SceneManager.LoadScene("PickStage");
                break;
            case 1:
                SceneManager.LoadScene("Stage 1");
                break;
            case 2:
                SceneManager.LoadScene("Stage 2");
                break;
            case 3:
                SceneManager.LoadScene("Stage 3");
                break;
            case 10:
                SceneManager.LoadScene("Main Menu");
                break;
        }
        
    }

}
