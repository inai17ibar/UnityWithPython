using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityOSC;

namespace GameServer { 
public class OSCServerTest : MonoBehaviour
{
    public Image[] images;
    string s1 = "123456789";

    int currentDataLen = 0;

    void Start()
    {
        OSCHandler.Instance.Init();
    }

    void Update()
    {
        OSCHandler.Instance.UpdateLogs();
        Dictionary<string, ServerLog> servers = new Dictionary<string, ServerLog>();
        servers = OSCHandler.Instance.Servers;
        foreach (KeyValuePair<string, ServerLog> item in servers)
        {
            // データを新たに受信したら
            if (currentDataLen != item.Value.packets.Count)
            {
                Debug.Log("received packet.");
                currentDataLen = item.Value.packets.Count;

                // 最後に受信したデータのIndexを取得
                int lastPacketIndex = item.Value.log.Count - 1;

                // 最後に受信したデータを取得
                string s2 = item.Value.packets[lastPacketIndex].Data[0].ToString();
                
                // 取得したデータの数字に対応する部分を黄色に変更
                if (s1.Contains(s2))
                {
                    Debug.Log("s2: " + s2);
                    int i = int.Parse(s2);
                    images[i - 1].color = new Color(255.0f, 255.0f, 0f);
                    s1 = s1.Replace(s2, "");

                    // 9つの数字の色が全て変更したら全て白に戻す
                    if (s1 == "")
                    {
                        for (int j = 0; j < images.Length; j++)
                        {
                            images[j].color = new Color(255.0f, 255.0f, 255.0f);
                            s1 = "123456789";
                        }
                    }
                }
            }
        }
    }
}
}