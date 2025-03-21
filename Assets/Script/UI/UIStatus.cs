using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIStatus : MonoBehaviour
{
    //ui 매니져에서 연산되값을 가지고 스탯치 변경
    
    public GameObject statWindow;//스탯창 활성화 비활성화 변수

    public TextMeshProUGUI attackNumText;//공격력 수치 텍스트

    public TextMeshProUGUI defNumText;//방어력 수치 텍스트

    public TextMeshProUGUI healthNumText;//체력 수치 텍스트

    public TextMeshProUGUI criticalNumText;//치명타 수치 텍스트

    public Button statBackBtn;
    void Start()
    {
        // 뒤로가기 버튼에 클릭 이벤트 추가
        statBackBtn.onClick.AddListener(UIManager.Instance.OpenMainMenu);
    }

    public void UIStatDetaSet()
    {
        attackNumText.text = GameManager.Instance.Player.Attack.ToString();
        defNumText.text = GameManager.Instance.Player.Defens.ToString();
        healthNumText.text = GameManager.Instance.Player.Health.ToString();
        criticalNumText.text = GameManager.Instance.Player.Health.ToString();
    }
}
