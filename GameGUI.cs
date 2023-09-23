using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameGUI : MonoBehaviour
{

    // ȭ�鿡 meter�� ǥ���� text
    public Text guiMeter;

    // meter�� ���� ��, static���� ���� �Ǿ� �ٸ� ��ũ��Ʈ���� ���� ����
    // Scene���� Ȱ�뵵 ����
    public static int meter;
    public float timePrev;

    // �����ۿ� ���� �ؽ��ĵ�
    public Texture OilTexture;
    public Texture ReverseTexture;
    public Texture BulletTexture;
    public Texture HealthTexture;
    public Texture FrozenTexture;
    public Texture GodTexture;

    // Player ��ũ��Ʈ�� ��ȣ�ۿ��ϱ� ���� ����
    public Player player;



    void Start()
    {

        // �ʱ�ȭ 
        meter = 0;
        timePrev = Time.time;

        player = GameObject.Find("Player").GetComponent<Player>();
    }

    void Update()
    {
        // 1�ʸ��� meter ����
        if (Time.time - timePrev > 1.0f) {
            timePrev = Time.time;
            meter++;
        }

        // GUI �ؽ�Ʈ ������Ʈ
        guiMeter.text = meter + "m";
    }

    void OnGUI()
    {
        float x;
        float y;
        float width = OilTexture.width / 2;
        float height = OilTexture.height / 2;

        GUI.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);

        // �������� ����Ǹ� ȭ�� ��ܿ� �����Ű��
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
