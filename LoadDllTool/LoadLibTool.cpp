#include <Windows.h>
#include <iostream>
#include "LoadLibTool.h"

////方法模板模式  C#中输入字符串输出字符串
//char * StrMethod(char * value)
//{
//	return value;
//}

char * LoadLibraryTool(char * value, char * dllPath, char * method)
{
	/*char * v1 = new char[11]{ 'f', 'a','i','l',' ','m','e','t','h','o','d' };
	char * v2 = new char[8]{ 'f', 'a','i','l',' ','l','i','b' };
	char * v3 = new char[4]{ 'f', 'a','i','l'};*/
	typedef char*(*pStrMethod)(char *value);
	HINSTANCE hDLL = LoadLibrary(dllPath);
	if (NULL != hDLL) {
		pStrMethod pFun = (pStrMethod)GetProcAddress(hDLL, method);

		if (NULL != pFun) {
			return pFun(value);
		}
		else
		{
			return nullptr;
		}
		FreeLibrary(hDLL);
	}
	else
	{
		return nullptr;
	}
	return nullptr;
}


