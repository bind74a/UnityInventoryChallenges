using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    public Button invenBackBtn;

    public GameObject inverWindow;//인벤토리 창 활성화 비활성화 변수

    public TextMeshProUGUI invenSlotText;//인벤 현재 갖고잇는 아이템 개수 / 인벤토리 슬롯 총겟수 텍스트

    public ItemSlot [] slots;//슬롯 개별마다 접근하기위한 변수
    public Transform slotPanel;//슬롯 개수 인식 변수

    

    void Start()
    {
        GameManager.Instance.Player.addItem += AddItem;
        InitInventoryUI();
    }


    /// <summary>
    /// 캐릭터가 가방에 아이템을 넣는 과정
    /// </summary>
    void AddItem()
    {

        List<ItemData>[] itemData = GameManager.Instance.Player.hand; //현재 손의 들고있는 아이템 리스트
        ItemSlot nullSlot = GetEmptySlot();//인벤토리 빈공간 찾기
        for (int i = 0; i < itemData.Length; i++)//갖고있는 아이템 가방에 넣기
        {
            foreach (ItemData item in itemData[i])//리스트에 있는 아이템을 자료형을 변경하는곳
            {
                if (nullSlot != null)
                {
                    nullSlot.item = item;
                    UpdateUI();
                    GameManager.Instance.Player.hand[i] = null;
                    return;
                }
            }
        }
    }

    /// <summary>
    /// 아이템 인벤토리에 들어갈때 작동
    /// </summary>
    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            
            if (slots[i].item != null)
            {
                slots[i].SetItem();//슬롯이 비어있을때 아이템 등록
            }
            else
            {
                slots[i].RefreshUI();
            }
            
        }
    }

    /// <summary>
    /// 인벤 슬롯 접근 작업 
    /// </summary>
    void InitInventoryUI()
    {
        invenBackBtn.onClick.AddListener(UIManager.Instance.OpenMainMenu);

        slots = new ItemSlot[slotPanel.childCount];
        invenSlotText.text = $"{slots.Min()}/{slots.Length}";

        for (int i = 0; i < slots.Length; i++)
        {
            slots[i] = slotPanel.GetChild(i).GetComponent<ItemSlot>();
            slots[i].index = i;//슬롯 번호 부여
        }
    }

    /// <summary>
    /// 슬롯 빈공간 찾는곳
    /// </summary>
    /// <returns></returns>
    ItemSlot GetEmptySlot()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == null)
            {
                return slots[i];
            }
        }
        return null;
    }
}
