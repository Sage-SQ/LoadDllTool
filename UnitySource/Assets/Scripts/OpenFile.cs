using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class OpenFile : MonoBehaviour
{
    public Button btn1;

    void Start()
    {
        btn1.onClick.AddListener(OpenFileWin);
    }

    public void OpenFileWin()
    {
        OpenFileName ofn = new OpenFileName();

        ofn.structSize = Marshal.SizeOf(ofn);

        ofn.filter = "All Files\0*.*\0\0";

        ofn.file = new string(new char[256]);

        ofn.maxFile = ofn.file.Length;

        ofn.fileTitle = new string(new char[64]);

        ofn.maxFileTitle = ofn.fileTitle.Length;
        string path = Application.streamingAssetsPath;
        path = path.Replace('/', '\\');
        //默认路径  
        ofn.initialDir = path;

        ofn.title = "Open Project";

        ofn.defExt = "JPG";//显示文件的类型  
        //注意 一下项目不一定要全选 但是0x00000008项不要缺少  
        ofn.flags = 0x00080000 | 0x00001000 | 0x00000800 | 0x00000200 | 0x00000008;//OFN_EXPLORER|OFN_FILEMUSTEXIST|OFN_PATHMUSTEXIST| OFN_ALLOWMULTISELECT|OFN_NOCHANGEDIR  

        if (WindowDll.GetOpenFileName(ofn))
        {
            Debug.Log("path is " + ofn.file);
            //选择E:\Work\controlTest\Assets\StreamingAssets\x86_64下的dll测试
            string outResult = WindowDll.LoadLibraryTool("inputtest", ofn.file, "testDllMethod111");
            Debug.Log("output is " + outResult);
        }
    }
}
