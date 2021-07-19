using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.Text;
using UnityOSC;
using UnityOSC.Test;

namespace UnityOSC.Test
{
    public class MyOSCServer : MonoBehaviour
    {

        private Dictionary<string, ServerLog> servers;
        private Dictionary<string, ClientLog> clients;
        private float randVal = 0f;
        public GameObject cube;
        private String msg = "";
        // Script initialization
        void Start()
        {
            OSCHandler.Instance.Init(); //init OSC
            servers = new Dictionary<string, ServerLog>();
            //clients = new Dictionary<string, ClientLog>();
            cube = GameObject.Find("Cube");
        }

        // NOTE: The received messages at each server are updated here
        // Hence, this update depends on your application architecture
        // How many frames per second or Update() calls per frame?
        void Update()
        {

            OSCHandler.Instance.UpdateLogs();

            msg = "0.1544944";
            byte[] val = new byte[] { 176, 8, 0 };

            servers = OSCHandler.Instance.Servers;
            //clients = OSCHandler.Instance.Clients;
            if (UnityEngine.Random.value < 0.01f)
            {
                //randVal = UnityEngine.Random.Range(0f, 0.7f);
                //OSCHandler.Instance.SendMessageToClient("TouchOSC Bridge", "/1/fader1", randVal);
                //OSCHandler.Instance.SendMessageToClient("TouchOSC Bridge", "/1/fader2", randVal);
                //OSCHandler.Instance.SendMessageToClient("TouchOSC Bridge", "/1/fader3", randVal);
                
               //OSCHandler.Instance.SendMessageToClient("OSClientA", "/filter", randVal);
            }
            OSCHandler.Instance.UpdateLogs();

            foreach (KeyValuePair<string, ServerLog> item in servers)
            {
                // If we have received at least one packet,
                // show the last received from the log in the Debug console
                if (item.Value.log.Count > 0)
                {
                    int lastPacketIndex = item.Value.packets.Count - 1;

                    UnityEngine.Debug.Log(String.Format("SERVER: {0} ADDRESS: {1} VALUE : {2}",
                                                            item.Key, // Server name
                                                            item.Value.packets[lastPacketIndex].Address, // OSC address
                                                            item.Value.packets[lastPacketIndex].Data[0].ToString())); //First data value

                    //converts the values into MIDI to scale the cube
                    float tempVal = float.Parse(item.Value.packets[lastPacketIndex].Data[0].ToString());
                    cube.transform.localScale = new Vector3(tempVal, tempVal, tempVal);
                }
            }


            //foreach (KeyValuePair<string, ClientLog> item in clients)
            //{
            //    // If we have sent at least one message,
            //    // show the last sent message from the log in the Debug console
            //    if (item.Value.log.Count > 0)
            //    {
            //        int lastMessageIndex = item.Value.messages.Count - 1;

            //        UnityEngine.Debug.Log(String.Format("CLIENT: {0} ADDRESS: {1} VALUE 0: {2}",
            //                                            item.Key, // Server name
            //                                            item.Value.messages[lastMessageIndex].Address, // OSC address
            //                                            item.Value.messages[lastMessageIndex].Data[0].ToString())); //First data value

            //    }

            //}
        }
    }
}