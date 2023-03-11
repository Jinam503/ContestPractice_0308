using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    

    public bool isStageLocked_2;
    public bool isStageLocked_3;

    public Text text1;
    public Text text2;
    public Text text3;
    public void MS(int a)
    {
        GameManager.Instance.MoveScene(a);
    }
    private void Update()
    {
        
        if (GameManager.Instance.isStageClear_1) text1.text = 1 + " Clear";
        else text1.text = 1 + "";

        if (GameManager.Instance.isStageClear_2) text2.text = 2 + " Clear";
        else if (!GameManager.Instance.isStageClear_1) text2.text = 2 + " Locked";
        else text2.text = 2 + "";

        if (GameManager.Instance.isStageClear_3) text2.text = 3 + " Clear";
        else if (!GameManager.Instance.isStageClear_2) text3.text = 3 + "Locked";
        else text3.text = 3 + "";
    }
}
