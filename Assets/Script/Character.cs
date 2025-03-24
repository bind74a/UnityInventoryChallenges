using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character: MonoBehaviour
{
    private static Character _instance;

    public string Title { get; private set; }//Īȣ
    public string Name { get; private set; }//�÷��̾� �̸�
    public string Description { get; private set; }//�÷��̾� ����
    public int Level { get; private set; }//����
    public float Exp { get; private set; }//����ġ
    public float ExpMax { get; private set; }//�ִ� ����ġ
    public int Attack { get; private set; }//���ݷ�
    public int Defens { get; private set; }//����
    public int Health { get; private set; }//ü��
    public int CriticalHit { get; private set; }//ġ��Ÿ
    public int Gold { get; private set; }//���

    public UIInventory Inventory;

    public ItemData[] hand;//����ִ� ������ ����Ʈ

    public Action addItem;//�κ��丮 ������ ����

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
