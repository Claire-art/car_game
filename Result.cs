using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{

    public Text guiMeter;
    public static int meter;

    void Start()
    {
        
    }

    void Update()
    {
        // Static�� Ȱ���Ͽ� Main Scene���� Player�� Meter �޾ƿ��� Gameover Scene���� ���
        guiMeter.text = GameGUI.meter + " Meters";
    }
}
