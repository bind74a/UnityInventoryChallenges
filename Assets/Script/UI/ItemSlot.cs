using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;
public class ItemSlot : MonoBehaviour
{
    public ItemData item; //���Կ� �� ������ ������ ����

    public UIInventory inventory;//�κ��丮 ����
    public Button Button;//������ ���� Ŭ��
    public Image icon;//������ ������
    public GameObject equipIcon;//������ ������ ������ ���� ������

    public int index;//������ ��ȣ
    public bool equipped; //���� ����

    /// <summary>
    /// ������ ü�ﶧ
    /// </summary>
    public void SetItem()
    {
        icon.gameObject.SetActive(true);
        icon.sprite = item.itemIcon;//������ ������ ���������� ����
    }

    /// <summary>
    /// ������ ��ﶧ
    /// </summary>
    public void RefreshUI()
    {
        item = null;//������ ���� �ʱ�ȭ
        icon.gameObject.SetActive(false);
    }
}
