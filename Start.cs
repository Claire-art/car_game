using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{

    // Scene 전환 구현, Main Scene로 넘어가기
    public void SceneChange() {
        SceneManager.LoadScene("MainScene");
    }
}
