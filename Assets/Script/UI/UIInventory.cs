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

    

    private void Awake()
    {
            
    }


    void Start()
    {
        GameManager.Instance.Player.addItem += AddItem; // Player가 초기화된 후 구독 

        InitInventoryUI();
    }


    /// <summary>
    /// 캐릭터가 가방에 아이템을 넣는 과정
    /// </summary>
    void AddItem()
    {
        Debug.Log("호출됨");
        ItemData[] itemData = GameManager.Instance.Player.hand; //현재 손의 들고있는 아이템 리스트
        for (int i = 0; i < itemData.Length; i++)//갖고있는 아이템 가방에 넣기
        {
            ItemSlot nullSlot = GetEmptySlot();//인벤토리 빈공간 찾기

            if (itemData[i] == null) //넣을 아이템이 없을때 작동
            {
                return; 
            }

            if (nullSlot != null)
            {
                Debug.Log("빈칸찾음");
                nullSlot.item = itemData[i];
                UpdateUI();
                GameManager.Instance.Player.hand[i] = null;
                Debug.Log(nullSlot.item.equipDef);
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
        //Debug.Log("호출됨");
        invenBackBtn.onClick.AddListener(UIManager.Instance.OpenMainMenu);
        int emptySlot = slots.Count(slot => slot.item == null);// slots.Count(slot => slot.item == null) 은 비어있는 슬롯을 카운트 하는것
        slots = new ItemSlot[slotPanel.childCount];
        invenSlotText.text = $"{emptySlot}/{slots.Length}";

        for (int i = 0; i < slots.Length; i++)
        {
            slots[i] = slotPanel.GetChild(i).GetComponent<ItemSlot>();
            slots[i].index = i;//슬롯 번호 부여
            //Debug.Log(slots[i].index);
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

    public void SelectItem(int slotIndex)
    {
        Debug.Log("호출됨");
        ItemData item = slots[slotIndex].item;

        if(item.equip && slots[slotIndex].equipped == false)//장착 가능여부 확인
        {
            Debug.Log("호출됨2");
            GameManager.Instance.Player.Equip(item);
            slots[slotIndex].equipped = true;
            SlotEquip(slotIndex);
            UIManager.Instance.UIStatus.UIStatDetaSet();
        }
        else if(item.equip && slots[slotIndex].equipped == true)
        {
            GameManager.Instance.Player.UnEquip(item);
            slots[slotIndex].equipped = false;
            SlotUnEquip(slotIndex);
            UIManager.Instance.UIStatus.UIStatDetaSet();
        }
    }

    void SlotEquip(int slotIndex)
    {
        slots[slotIndex].equipIcon.gameObject.SetActive(true);
    }

    void SlotUnEquip(int slotIndex)
    {
        slots[slotIndex].equipIcon.gameObject.SetActive(false);
    }
}
