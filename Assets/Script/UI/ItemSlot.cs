using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;
public class ItemSlot : MonoBehaviour
{
    public ItemData item; //슬롯에 들어갈 아이템 데이터 변수

    public Button Button;//아이템 슬롯 클릭
    public Image icon;//아이템 아이콘
    public GameObject equipIcon;//아이템 장착시 나오는 장착 아이콘

    public int index;//슬롯의 번호
    public bool equip; //장비 아이템 플래그

    public bool equipped = false;//장비하고있는지 플래그

    /// <summary>
    /// 슬롯을 체울때
    /// </summary>
    public void SetItem()
    {
        icon.gameObject.SetActive(true);
        icon.sprite = item.itemIcon;//아이템 데이터 아이콘으로 변경
    }

    /// <summary>
    /// 슬롯을 비울때
    /// </summary>
    public void RefreshUI()
    {
        item = null;//아이템 정보 초기화
        icon.gameObject.SetActive(false);
    }

    public void OnClickButton()
    {
        
        UIManager.Instance.UIInventory.SelectItem(index);
    }
}
