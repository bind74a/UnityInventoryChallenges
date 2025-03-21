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

    

    void Start()
    {
        GameManager.Instance.Player.addItem += AddItem;
        InitInventoryUI();
    }


    /// <summary>
    /// ĳ���Ͱ� ���濡 �������� �ִ� ����
    /// </summary>
    void AddItem()
    {

        List<ItemData>[] itemData = GameManager.Instance.Player.hand; //���� ���� ����ִ� ������ ����Ʈ
        ItemSlot nullSlot = GetEmptySlot();//�κ��丮 ����� ã��
        for (int i = 0; i < itemData.Length; i++)//�����ִ� ������ ���濡 �ֱ�
        {
            foreach (ItemData item in itemData[i])//����Ʈ�� �ִ� �������� �ڷ����� �����ϴ°�
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
        invenBackBtn.onClick.AddListener(UIManager.Instance.OpenMainMenu);

        slots = new ItemSlot[slotPanel.childCount];
        invenSlotText.text = $"{slots.Min()}/{slots.Length}";

        for (int i = 0; i < slots.Length; i++)
        {
            slots[i] = slotPanel.GetChild(i).GetComponent<ItemSlot>();
            slots[i].index = i;//���� ��ȣ �ο�
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
}
