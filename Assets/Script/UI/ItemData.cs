using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemData : ScriptableObject
{
    public Sprite itemIcon; //������ ������

    public bool equip; //����Ҽ��ִ°�
}
