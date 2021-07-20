using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityOSC;

namespace GameSample {

    public class OSCClientTest : MonoBehaviour
    {
        public bool startFlag = false;
        void Start()
        {
            OSCHandler.Instance.Init();
        }

        void Update()
        {
            startFlag = FindObjectOfType<GameController>().flag;

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
                        //OSC�̑��M��
                        OSCHandler.Instance.SendMessageToClient("OSCClientTest", "/Int", sentInt);
                    }
                }
            }
        }
    }

}