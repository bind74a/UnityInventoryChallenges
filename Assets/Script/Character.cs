using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character: MonoBehaviour
{
    private static Character _instance;

    public string Title { get; private set; }//칭호
    public string Name { get; private set; }//플레이어 이름
    public string Description { get; private set; }//플레이어 설명
    public int Level { get; private set; }//레벨
    public float Exp { get; private set; }//경험치
    public float ExpMax { get; private set; }//최대 경험치
    public int Attack { get; private set; }//공격력
    public int Defens { get; private set; }//방어력
    public int Health { get; private set; }//체력
    public int CriticalHit { get; private set; }//치명타
    public int Gold { get; private set; }//골드

    public UIInventory Inventory;

    public ItemData[] hand;//들고있는 아이템 리스트

    public Action addItem;//인벤토리 아이템 생성

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    private void Start()
    {
        GameManager.Instance.Player = this;
    }
    public void SetData(string title, string name, string description, int level, float exp, float expMax, int attack, int defens, int health, int criticalHit, int gold)
    {
        
        Title = title;
        Name = name;
        Description = description;
        Level = level;
        Exp = exp;
        ExpMax = expMax;
        Attack = attack;
        Defens = defens;
        Health = health;
        CriticalHit = criticalHit;
        Gold = gold;
    }

    public void TestAddEXP(float exp)
    {
        Exp += exp;
    }

    public void Equip(ItemData equipValue)
    {
        Attack += equipValue.equipAttack;
        Defens += equipValue.equipDef;
        Health += equipValue.equipHealth;
        CriticalHit += equipValue.equipCriticalHit;
    }

    public void UnEquip(ItemData unequipValue)
    {
        Attack -= unequipValue.equipAttack;
        Defens -= unequipValue.equipDef;
        Health -= unequipValue.equipHealth;
        CriticalHit -= unequipValue.equipCriticalHit;
    }
}
