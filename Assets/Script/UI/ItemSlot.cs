using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemSlot : MonoBehaviour
{
    //public ItemData item; //슬롯에 들어갈 아이템 데이터 변수

    public UIInventory inventory;//인벤토리 연결
    public Button Button;//아이템 슬롯 클릭
    public Image icon;//아이템 아이콘
    public Image equipIcon;//아이템 장착시 나오는 장착 아이콘

    public int index;//슬롯의 번호
    public bool equipped; //장착 여부


    public void SetItem()
    {

    }

    public void RefreshUI()
    {

    }
}
