using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIStatus : MonoBehaviour
{
    //ui �Ŵ������� ����ǰ��� ������ ����ġ ����
    
    public GameObject statWindow;//����â Ȱ��ȭ ��Ȱ��ȭ ����

    public TextMeshProUGUI attackNumText;//���ݷ� ��ġ �ؽ�Ʈ

    public TextMeshProUGUI defNumText;//���� ��ġ �ؽ�Ʈ

    public TextMeshProUGUI healthNumText;//ü�� ��ġ �ؽ�Ʈ

    public TextMeshProUGUI criticalNumText;//ġ��Ÿ ��ġ �ؽ�Ʈ

    public Button statBackBtn;
    void Start()
    {
        // �ڷΰ��� ��ư�� Ŭ�� �̺�Ʈ �߰�
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
