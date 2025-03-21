using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class UIMainMenu : MonoBehaviour
{
    //ui �Ŵ������� ����ǰ��� ������ ui ����

    public TextMeshProUGUI goldText;//��ȭ
    public TextMeshProUGUI TitleText;//Īȣ
    public TextMeshProUGUI playerNameText;//�÷��̾� �̸�
    public TextMeshProUGUI lvNumText;//���� ���� �ؽ�Ʈ
    public TextMeshProUGUI CharacterText;//������ �ΰ� ���� �ؽ�Ʈ

    public Image levelBar;//����ġ��
    public float curExp;
    public float maxExp;

    public Button invenBtn;//�κ��丮 â ���� ��ư
    public Button statBtn;//����â ���� ��ư
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
        UpdateProgressbar(levelBar, curExp, maxExp);//���߿� �ڷ�ƾ���� ����
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
