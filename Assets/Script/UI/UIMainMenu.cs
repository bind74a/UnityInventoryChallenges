using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class UIMainMenu : MonoBehaviour
{
    //ui 매니져에서 연산되값을 가지고 ui 변경

    public TextMeshProUGUI goldText;//금화
    public TextMeshProUGUI TitleText;//칭호
    public TextMeshProUGUI playerNameText;//플레이어 이름
    public TextMeshProUGUI lvNumText;//레벨 숫자 텍스트
    public TextMeshProUGUI CharacterText;//개릭터 부가 설명 텍스트

    public Image levelBar;//경험치바
    public float curExp;
    public float maxExp;

    public Button invenBtn;//인벤토리 창 오픈 버튼
    public Button statBtn;//스탯창 오픈 버튼
    private void Awake()
    {
        
    }

    private void Start()
    {
        invenBtn.onClick.AddListener(UIManager.Instance.OpenInventory);
        statBtn.onClick.AddListener (UIManager.Instance.OpenStatus);
    }

    private void Update()
    {
        UpdateProgressbar(levelBar, curExp, maxExp);//나중에 코루틴으로 구현
    }

    public void UIMainMenuDetaSet()
    {
        goldText.text = GameManager.Instance.Player.Gold.ToString();
        TitleText.text = GameManager.Instance.Player.Title;
        playerNameText.text = GameManager.Instance.Player.Name;
        lvNumText.text = GameManager.Instance.Player.Level.ToString();
        CharacterText.text = GameManager.Instance.Player.Description;
        curExp = GameManager.Instance.Player.Exp;
        maxExp = GameManager.Instance.Player.ExpMax;

        UpdateProgressbar(levelBar,curExp,maxExp);
    }

    public void UpdateProgressbar(Image image, float curValue, float maxValue)
    {

        image.fillAmount = Mathf.Clamp01(curValue / maxValue);
    }
}
