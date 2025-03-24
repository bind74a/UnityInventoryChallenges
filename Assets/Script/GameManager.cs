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
        SetItemData();//플레이어 손에 아이템 넣어주는 메서드
        Debug.Log(Player.Exp);
        Debug.Log(Player.ExpMax);
        Player.addItem?.Invoke();
    }
    /// <summary>
    /// 플레이어 정보 입력
    /// </summary>
    public void SetPlayerData()
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
    /// <summary>
    /// 플레이어 에게 아이템 주기
    /// </summary>
    public void SetItemData()
    {
        Player.hand = new ItemData[5];//5칸 배열 생성  (리스트를 배열로 생성해서 망할뻔.)

        for (int i = 0; i < itemDatabase.itemList.Count; i++)
        {
            if (Player.hand[i] == null)
            {
                Player.hand[i] = new ItemData();  // 초기화
            }
            Player.hand[i] = itemDatabase.itemList[i];

        }
    }
}
