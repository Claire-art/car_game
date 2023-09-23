using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    // Main Scene로 넘어가기
    public void SceneChange()
    {
        SceneManager.LoadScene("MainScene");
    }
}
