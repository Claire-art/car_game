using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    // Main Scene�� �Ѿ��
    public void SceneChange()
    {
        SceneManager.LoadScene("MainScene");
    }
}
