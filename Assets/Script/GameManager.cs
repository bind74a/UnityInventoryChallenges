using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEditor.Timeline.Actions.MenuPriority;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public ItemDatabase itemDatabase;

    public Character _player;

    public Character Player { get { return _player; } set { _player = value; } }

    public static GameManager Instance { get { return instance; } set { instance = value; } }

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        SetPlayerData();
        
    }

    private void Start()
    {
        SetItemData();//�÷��̾� �տ� ������ �־��ִ� �޼���
        Debug.Log(Player.Exp);
        Debug.Log(Player.ExpMax);
        Player.addItem?.Invoke();
    }
    /// <summary>
    /// �÷��̾� ���� �Է�
    /// </summary>
    public void SetPlayerData()
    {
        _player.SetData(
            "����",          // Īȣ
            "��ź",          // �̸�
            "�������帵ũ�� �ߵ��� ����", // ����
            1,             // ����
            0f,              // ����ġ
            100f,            // �ִ� ����ġ
            10,              // ���ݷ�
            5,               // ����
            100,             // ü��
            5,               // ġ��Ÿ
            1000             // ���
        );
    }
    /// <summary>
    /// �÷��̾� ���� ������ �ֱ�
    /// </summary>
    public void SetItemData()
    {
        Player.hand = new ItemData[5];//5ĭ �迭 ����  (����Ʈ�� �迭�� �����ؼ� ���һ�.)

        for (int i = 0; i < itemDatabase.itemList.Count; i++)
        {
            if (Player.hand[i] == null)
            {
                Player.hand[i] = new ItemData();  // �ʱ�ȭ
            }
            Player.hand[i] = itemDatabase.itemList[i];

        }
    }
}
