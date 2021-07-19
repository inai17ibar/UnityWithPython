using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public InputField ipField;
    public InputField portField;
    public Button startButton;
    public GameObject client;
    public GameObject instructUI;

    public string ip = "172.0.0.1";
    public int port = 8080;

    public bool flag = false;

    void Start()
    {
        ipField.text = ip;
        portField.text = port.ToString();
        startButton.onClick.AddListener(ConnectToServer);
    }

    // IPアドレスとポート番号を入力してサーバと接続する関数
    public void ConnectToServer()
    {
        ip = ipField.text;
        port = int.Parse(portField.text);
        flag = true;
        GameObject.Find("StartUI").SetActive(false);
        instructUI.SetActive(true);
    }
}