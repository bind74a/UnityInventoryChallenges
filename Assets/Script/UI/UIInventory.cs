using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    public Button invenBackBtn;

    public GameObject inverWindow;//�κ��丮 â Ȱ��ȭ ��Ȱ��ȭ ����

    public TextMeshProUGUI invenSlotText;//�κ� ���� �����մ� ������ ���� / �κ��丮 ���� �Ѱټ� �ؽ�Ʈ

    public ItemSlot[] slots;//���� �������� �����ϱ����� ����
    


    void Start()
    {
        invenBackBtn.onClick.AddListener(UIManager.Instance.OpenMainMenu);
    }
}
