using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    // ProgressBar에 표시할 텍스쳐
    public Texture foregroundTexture;
    public Texture backgroundTexture;

    // 플레이어 체력이 감소할 때 텍스쳐
    public Texture2D damageTexture;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnGUI()
    {
        // ProgressBar를 그릴 사각형의 위치와 크기를 설정
        Rect rect = new Rect(10, 6, Screen.width / 2 - 20, backgroundTexture.height);

        // 배경 텍스쳐 그리기
        GUI.DrawTexture(rect, backgroundTexture);

        // Player의 체력 가져오기
        float health = Player.health;

        //health에 따라 너비 조정
        rect.width *= health;

        // 체력이 감소할 때 텍스쳐의 색상을 설정하여 적용
        GUI.color = damageTexture.GetPixelBilinear(health, 0.5f);
        GUI.DrawTexture(rect, foregroundTexture);

        GUI.color = Color.white;
    }
}
