using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityOSC;

namespace GameSample {

    public class OSCClientTest : MonoBehaviour
    {

        bool startFlag = false;
        void Start()
        {
            startFlag = FindObjectOfType<GameController>().flag;
            OSCHandler.Instance.Init();
        }

        void Update()
        {
            // �Q�[�����X�^�[�g���Ă��瑗�M�\�ɂȂ�
            if (startFlag)
            {
                if (Input.anyKeyDown)
                {
                    string inputStr = Input.inputString;
                    string allNumStr = "0123456789";
                    if (allNumStr.Contains(inputStr))
                    {
                        Debug.Log(inputStr + " is pressed");
                        int sentInt;
                        int.TryParse(inputStr, out sentInt);
                        OSCHandler.Instance.SendMessageToClient("OSCClientTest", "/Int", sentInt);
                    }
                }
            }
        }
    }

}