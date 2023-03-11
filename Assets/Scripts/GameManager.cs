using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool isStageClear_1;
    public bool isStageClear_2;
    public bool isStageClear_3;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {

  
        if (Input.GetKeyDown(KeyCode.F1))
        {
            Scene scene = SceneManager.GetActiveScene();
            if (scene.name == "PickStage" || scene.name == "Main Menu") return;
            DestroyAllEnemy();
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            Scene scene = SceneManager.GetActiveScene();
            if (scene.name == "PickStage" || scene.name == "Main Menu") return;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().CurBulletLvl = 8;
        }
        
        if (Input.GetKeyDown(KeyCode.F4))
        {
            Scene scene = SceneManager.GetActiveScene();
            if (scene.name == "PickStage" || scene.name == "Main Menu") return;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().hp = 10;
        }
        if (Input.GetKeyDown(KeyCode.F5))
        {
            Scene scene = SceneManager.GetActiveScene();
            if (scene.name == "PickStage" || scene.name == "Main Menu") return;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().gas = 100;
        }
        if (Input.GetKeyDown(KeyCode.F6))
        {
            Scene scene = SceneManager.GetActiveScene();
            switch (scene.name)
            {
                case "Stage 1":
                        MoveScene(2);
                    break;
                case "Stage 2":
                        MoveScene(3);
                        break;
                case "Stage 3":
                        MoveScene(1);
                        break;
                default:
                    break;
                }
        }
        
    }
    private void DestroyAllEnemy()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject g in gameObjects)
        {
            Destroy(g);
        }
    }
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
