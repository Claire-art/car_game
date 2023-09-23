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
        // Static을 활용하여 Main Scene에서 Player의 Meter 받아오고 Gameover Scene에서 출력
        guiMeter.text = GameGUI.meter + " Meters";
    }
}
