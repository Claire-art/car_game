using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{

    // Scene ��ȯ ����, Main Scene�� �Ѿ��
    public void SceneChange() {
        SceneManager.LoadScene("MainScene");
    }
}
