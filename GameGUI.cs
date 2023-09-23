using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameGUI : MonoBehaviour
{

    // 화면에 meter를 표시할 text
    public Text guiMeter;

    // meter의 현재 값, static으로 정의 되어 다른 스크립트에서 접근 가능
    // Scene간의 활용도 증가
    public static int meter;
    public float timePrev;

    // 아이템에 대한 텍스쳐들
    public Texture OilTexture;
    public Texture ReverseTexture;
    public Texture BulletTexture;
    public Texture HealthTexture;
    public Texture FrozenTexture;
    public Texture GodTexture;

    // Player 스크립트와 상호작용하기 위한 변수
    public Player player;



    void Start()
    {

        // 초기화 
        meter = 0;
        timePrev = Time.time;

        player = GameObject.Find("Player").GetComponent<Player>();
    }

    void Update()
    {
        // 1초마다 meter 증가
        if (Time.time - timePrev > 1.0f) {
            timePrev = Time.time;
            meter++;
        }

        // GUI 텍스트 업데이트
        guiMeter.text = meter + "m";
    }

    void OnGUI()
    {
        float x;
        float y;
        float width = OilTexture.width / 2;
        float height = OilTexture.height / 2;

        GUI.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);

        // 아이템이 적용되면 화면 상단에 노출시키기
        if (player.bItemOil) {
            x = Screen.width - (10 + width);
            y = 6;

            Rect rect = new Rect(x, y, width, height);
            GUI.DrawTexture(rect, OilTexture);
        }

        if (player.bItemBullet)
        {
            x = Screen.width - (10 + width);
            y = 6 + (height + 10);

            Rect rect = new Rect(x, y, width, height);
            GUI.DrawTexture(rect, BulletTexture);
        }

        if (player.bItemReverse) {
            x = Screen.width - (10 + width) * 2;
            y = 6;
            Rect rect = new Rect(x, y, width, height);
            GUI.DrawTexture(rect, ReverseTexture);
        }

        if (player.bItemHealth) {
            x = Screen.width - (10 + width) * 2;
            y = 6 + (height + 10);
            Rect rect = new Rect(x, y, width, height);
            GUI.DrawTexture(rect, HealthTexture);
        }

        if (player.bItemFrozen)
        {
            x = Screen.width - (10 + width) * 3;
            y = 6 + (height + 10);
            Rect rect = new Rect(x, y, width, height);
            GUI.DrawTexture(rect, FrozenTexture);
        }

        if (player.bItemGod)
        {
            x = Screen.width - (10 + width) * 3;
            y = 6;
            Rect rect = new Rect(x, y, width, height);
            GUI.DrawTexture(rect, GodTexture);
        }

        GUI.color = Color.white;
    }
}
