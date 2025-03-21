using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

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
        Debug.Log(Player.Exp);
        Debug.Log(Player.ExpMax);

    }

    void SetPlayerData()
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
}
