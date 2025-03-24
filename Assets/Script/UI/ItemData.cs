using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemData:ScriptableObject
{
    public Sprite itemIcon; //아이템 아이콘

    public int equipAttack; //장비 공격력

    public int equipDef; //장비 방어력

    public int equipHealth; //장비 체력

    public int equipCriticalHit; //장비 치명타

    public bool equip; //장비 할수있는가?

}
