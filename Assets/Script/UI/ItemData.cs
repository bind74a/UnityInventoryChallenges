using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemData:ScriptableObject
{
    public Sprite itemIcon; //������ ������

    public int equipAttack; //��� ���ݷ�

    public int equipDef; //��� ����

    public int equipHealth; //��� ü��

    public int equipCriticalHit; //��� ġ��Ÿ

    public bool equip; //��� �Ҽ��ִ°�?

}
