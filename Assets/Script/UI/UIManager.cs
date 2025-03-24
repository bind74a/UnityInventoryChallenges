using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
public class UIManager : MonoBehaviour
{

    public UIMainMenu _uiMainMenu;
    public UIMainMenu UIMainMenu { get { return _uiMainMenu; } set { _uiMainMenu = value; } }//get 은 해당 변수의 정보를 가져오는것 //set은 해당변수에게 정보를 보내는것

    public UIStatus _uiStatus;
    public UIStatus UIStatus { get { return _uiStatus; } set { _uiStatus = value; } }

    public UIInventory _uiInventory;
    public UIInventory UIInventory { get { return _uiInventory; } set { _uiInventory = value; } }

    public static UIManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        OpenMainMenu();
        UIMainMenu.UIMainMenuDetaSet();
        UIStatus.UIStatDetaSet();
    }

    private void Update()
    {
        
    }

    public void OpenMainMenu()
    {
        UIMainMenu.statBtn.gameObject.SetActive(true);
        UIMainMenu.invenBtn.gameObject.SetActive(true);
        UIStatus.statWindow.gameObject.SetActive(false);
        UIInventory.inverWindow.gameObject.SetActive(false);
    }

    public void OpenStatus()
    {
        UIMainMenu.statBtn.gameObject.SetActive(false);
        UIMainMenu.invenBtn.gameObject.SetActive(false);
        UIStatus.statWindow.gameObject.SetActive(true);
        UIInventory.inverWindow.gameObject.SetActive(false);
    }

    public void OpenInventory()
    {
        UIMainMenu.statBtn.gameObject.SetActive(false);
        UIMainMenu.invenBtn.gameObject.SetActive(false);
        UIStatus.statWindow.gameObject.SetActive(false);
        UIInventory.inverWindow.gameObject.SetActive(true);
    }

    public void TestEXPBtn()
    {
        GameManager.Instance.Player.TestAddEXP(10f);
        UIMainMenu.curExp = GameManager.Instance.Player.Exp;
    }
}
