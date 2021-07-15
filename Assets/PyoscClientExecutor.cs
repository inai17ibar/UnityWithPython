using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;

// Python for Unityを使わずに、任意のPyhtonを実行する方法 
public class PyoscClientExecutor : MonoBehaviour
{
    private Process process;

    //pythonがある場所
    private string pyExePath = @"c:\Program Files\Python36\python.exe";

    //実行したいスクリプトがある場所
    private string pyCodePath = @"Assets/PythonScript/pyoscclient.py";

    private void Start()
    {
        //外部プロセスの設定
        ProcessStartInfo processStartInfo = new ProcessStartInfo()
        {
            FileName = pyExePath, //実行するファイル(python)
            UseShellExecute = false,//シェルを使うかどうか
            CreateNoWindow = true, //ウィンドウを開くかどうか
            RedirectStandardOutput = true, //テキスト出力をStandardOutputストリームに書き込むかどうか
            Arguments = pyCodePath, //実行するスクリプト 引数(複数可)
        };

        //外部プロセスの開始
        process = Process.Start(processStartInfo);

        //ストリームから出力を得る
        StreamReader streamReader = process.StandardOutput;
        string str = streamReader.ReadLine();
        print(str);
    }

    private void Update()
    {
        if (process != null)
        {
            //ストリームから出力を得る
            //StreamReader streamReader = process.StandardOutput;
            //string str = streamReader.ReadLine();
            //print(str);

            if (Input.GetKeyDown(KeyCode.Q))
            {
                //外部プロセスの終了
                process.WaitForExit();
                process.Close();

                UnityEditor.EditorApplication.isPlaying = false;
                //UnityEngine.Application.Quit();
            }
        }
    }
}