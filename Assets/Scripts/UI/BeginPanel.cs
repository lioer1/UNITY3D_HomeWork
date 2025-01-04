using System.Collections;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public  class BeginPanel: MonoBehaviour 
{
    private static BeginPanel instance;

    public static BeginPanel Instance => instance;

    public TMP_InputField inputAccount;
    public TMP_InputField inputPassword;
    public Button btnLogin;
    
    void Awake()
    {
        instance = this;
        init();
      
    }

    private void init()
    {
        btnLogin.onClick.AddListener(() =>
        {
            if (MySqlConnector.Instance.CheckAccount(inputAccount.text, inputPassword.text))
            {
                SceneManager.LoadScene("Scene1");
                Grade.grade = 0;
            }
        });
    }





    public virtual void ShowMe()
    {
        this.gameObject.SetActive(true);
    }

    public virtual void HideMe()
    {
        this.gameObject.SetActive(false);
    }
}
