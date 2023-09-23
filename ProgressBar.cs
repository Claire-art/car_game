using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    // ProgressBar�� ǥ���� �ؽ���
    public Texture foregroundTexture;
    public Texture backgroundTexture;

    // �÷��̾� ü���� ������ �� �ؽ���
    public Texture2D damageTexture;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnGUI()
    {
        // ProgressBar�� �׸� �簢���� ��ġ�� ũ�⸦ ����
        Rect rect = new Rect(10, 6, Screen.width / 2 - 20, backgroundTexture.height);

        // ��� �ؽ��� �׸���
        GUI.DrawTexture(rect, backgroundTexture);

        // Player�� ü�� ��������
        float health = Player.health;

        //health�� ���� �ʺ� ����
        rect.width *= health;

        // ü���� ������ �� �ؽ����� ������ �����Ͽ� ����
        GUI.color = damageTexture.GetPixelBilinear(health, 0.5f);
        GUI.DrawTexture(rect, foregroundTexture);

        GUI.color = Color.white;
    }
}
