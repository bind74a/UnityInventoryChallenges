using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    public Button invenBackBtn;

    public GameObject inverWindow;//�κ��丮 â Ȱ��ȭ ��Ȱ��ȭ ����

    public TextMeshProUGUI invenSlotText;//�κ� ���� �����մ� ������ ���� / �κ��丮 ���� �Ѱټ� �ؽ�Ʈ

    public ItemSlot [] slots;//���� �������� �����ϱ����� ����
    public Transform slotPanel;//���� ���� �ν� ����

    

    private void Awake()
    {
            
    }


    void Start()
    {
        GameManager.Instance.Player.addItem += AddItem; // Player�� �ʱ�ȭ�� �� ���� 

        InitInventoryUI();
    }


    /// <summary>
    /// ĳ���Ͱ� ���濡 �������� �ִ� ����
    /// </summary>
    void AddItem()
    {
        Debug.Log("ȣ���");
        ItemData[] itemData = GameManager.Instance.Player.hand; //���� ���� ����ִ� ������ ����Ʈ
        for (int i = 0; i < itemData.Length; i++)//�����ִ� ������ ���濡 �ֱ�
        {
            ItemSlot nullSlot = GetEmptySlot();//�κ��丮 ����� ã��

            if (itemData[i] == null) //���� �������� ������ �۵�
            {
                return; 
            }

            if (nullSlot != null)
            {
                Debug.Log("��ĭã��");
                nullSlot.item = itemData[i];
                UpdateUI();
                GameManager.Instance.Player.hand[i] = null;
                Debug.Log(nullSlot.item.equipDef);
            }
        }
    }

    /// <summary>
    /// ������ �κ��丮�� ���� �۵�
    /// </summary>
    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            
            if (slots[i].item != null)
            {
                slots[i].SetItem();//������ ��������� ������ ���
            }
            else
            {
                slots[i].RefreshUI();
            }
            
        }
    }

    /// <summary>
    /// �κ� ���� ���� �۾� 
    /// </summary>
    void InitInventoryUI()
    {
        //Debug.Log("ȣ���");
        invenBackBtn.onClick.AddListener(UIManager.Instance.OpenMainMenu);
        int emptySlot = slots.Count(slot => slot.item == null);// slots.Count(slot => slot.item == null) �� ����ִ� ������ ī��Ʈ �ϴ°�
        slots = new ItemSlot[slotPanel.childCount];
        invenSlotText.text = $"{emptySlot}/{slots.Length}";

        for (int i = 0; i < slots.Length; i++)
        {
            slots[i] = slotPanel.GetChild(i).GetComponent<ItemSlot>();
            slots[i].index = i;//���� ��ȣ �ο�
            //Debug.Log(slots[i].index);
        }
    }

    /// <summary>
    /// ���� ����� ã�°�
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
        Debug.Log("ȣ���");
        ItemData item = slots[slotIndex].item;

        if(item.equip && slots[slotIndex].equipped == false)//���� ���ɿ��� Ȯ��
        {
            Debug.Log("ȣ���2");
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
