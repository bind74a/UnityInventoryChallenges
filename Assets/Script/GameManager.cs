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
            "전사",          // 칭호
            "르탄",          // 이름
            "에너지드링크의 중독된 전사", // 설명
            1,             // 레벨
            0f,              // 경험치
            100f,            // 최대 경험치
            10,              // 공격력
            5,               // 방어력
            100,             // 체력
            5,               // 치명타
            1000             // 골드
        );
    }
}
