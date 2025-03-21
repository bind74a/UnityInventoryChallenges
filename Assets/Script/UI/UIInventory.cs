using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    public Button invenBackBtn;

    public GameObject inverWindow;//인벤토리 창 활성화 비활성화 변수

    public TextMeshProUGUI invenSlotText;//인벤 현재 갖고잇는 아이템 개수 / 인벤토리 슬롯 총겟수 텍스트

    public ItemSlot[] slots;//슬롯 개별마다 접근하기위한 변수
    


    void Start()
    {
        invenBackBtn.onClick.AddListener(UIManager.Instance.OpenMainMenu);
    }
}
