using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public bool isStageClear_1;
    public bool isStageClear_2;
    public bool isStageClear_3;

    public bool isStageLocked_1;
    public bool isStageLocked_2;

    public Text text1;
    public Text text2;
    public Text text3;
    
    private void Update()
    {
        
        if (isStageClear_1) text1.text = 1 + " ����";
        else text1.text = 1 + "";

        if (isStageClear_2) text2.text = 2 + " ����";
        else if (!isStageClear_1) text2.text = 2 + "���";
        else text2.text = 2 + "";

        if (isStageClear_3) text2.text = 3 + " ����";
        else if (!isStageClear_2) text3.text = 3 + "���";
        else text3.text = 3 + "";
    }
}
