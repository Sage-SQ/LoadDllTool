
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using UnityEngine;

public class testDllS : MonoBehaviour
{

    [DllImport("LoadDllTool")]
    static extern string LoadLibraryTool(string s, string s1, string s2);

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ASDLLV();
        }
    }

    public void ASDLLV()
    {
        Debug.Log(Application.streamingAssetsPath + "/x86_64/testDLL1Dll.dll");
        string outResult = LoadLibraryTool("afefawg", Application.streamingAssetsPath + "/x86_64/testDLL1Dll.dll", "testDllMethod111");
        Debug.Log(outResult);
    }
}
