using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;

// Python for Unity���g�킸�ɁA�C�ӂ�Pyhton�����s������@ 
public class PyoscClientExecutor : MonoBehaviour
{
    private Process process;

    //python������ꏊ
    private string pyExePath = @"c:\Program Files\Python36\python.exe";

    //���s�������X�N���v�g������ꏊ
    private string pyCodePath = @"Assets/PythonScript/pyoscclient.py";

    private void Start()
    {
        //�O���v���Z�X�̐ݒ�
        ProcessStartInfo processStartInfo = new ProcessStartInfo()
        {
            FileName = pyExePath, //���s����t�@�C��(python)
            UseShellExecute = false,//�V�F�����g�����ǂ���
            CreateNoWindow = true, //�E�B���h�E���J�����ǂ���
            RedirectStandardOutput = true, //�e�L�X�g�o�͂�StandardOutput�X�g���[���ɏ������ނ��ǂ���
            Arguments = pyCodePath, //���s����X�N���v�g ����(������)
        };

        //�O���v���Z�X�̊J�n
        process = Process.Start(processStartInfo);

        //�X�g���[������o�͂𓾂�
        StreamReader streamReader = process.StandardOutput;
        string str = streamReader.ReadLine();
        print(str);
    }

    private void Update()
    {
        if (process != null)
        {
            //�X�g���[������o�͂𓾂�
            //StreamReader streamReader = process.StandardOutput;
            //string str = streamReader.ReadLine();
            //print(str);

            if (Input.GetKeyDown(KeyCode.Q))
            {
                //�O���v���Z�X�̏I��
                process.WaitForExit();
                process.Close();

                UnityEditor.EditorApplication.isPlaying = false;
                //UnityEngine.Application.Quit();
            }
        }
    }
}