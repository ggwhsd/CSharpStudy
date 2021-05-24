// CSharpInvokeCPP.cpp: 定义 DLL 应用程序的导出函数。
//

#include "stdafx.h"
#include "userinfo.h"
#include <iostream>
/* extern "C" __declspec(dllexport)加起来的目的是为了使用DllImport调用非托管C++的DLL文件。
    因为使用DllImport只能调用由C语言函数做成的DLL。 
*/
#pragma warning(disable: 4996) // avoid GetVersionEx to be warned
extern "C" __declspec(dllexport) int Add(int x, int y)
{
	return x + y;
}
extern "C" __declspec(dllexport) int Sub(int x, int y)
{
	return x - y;
}
extern "C" __declspec(dllexport) int Multiply(int x, int y)
{
	return x * y;
}
extern "C" __declspec(dllexport) int Divide(int x, int y)
{
	return x / y;
}


//为了方便转换到C#的类中
typedef struct {
	char name[32];
	int age;
	char name2[3];
	double age2;
} User;

UserInfo* userInfo;

//返回值struct指针
extern "C" __declspec(dllexport) User* Create(char* name, int age)
{
	User *user = new User();
	memset(user, 0, sizeof User);
	userInfo = new UserInfo(name, age);
	strcpy(user->name, userInfo->GetName());
	user->age = userInfo->GetAge();
	user->age2 = 3.8;
	strcpy(user->name2, "XX");
	return user;
}

//返回值字符串
char hello[10];
extern "C" __declspec(dllexport)  char* WINAPI getStringTest(char* name, int age)
{
	return hello;
}

extern "C" __declspec(dllexport)  void  setStringTest(char name[10], int age)
{
	strcpy(hello, name);
}

//函数参数传入并且传出
extern "C" __declspec(dllexport)  void  setRef( int &age)
{
	age++;
}

//参数传入数组
extern "C" __declspec(dllexport) int sumArray(int number[],int length)
{
	int i = 0;
	int sum = 0;
	while (i < length)
	{
		sum = number[i] + sum;
		i++;
	}
	std::cout << sum << endl;
	return sum;
}

//参数传出数组,ptr为数组指针
extern "C" __declspec(dllexport) void copyArray(int number[], int length,int *ptr)
{
	int i = 0;
	int sum = 0;
	while (i < length)
	{
		ptr[i]=number[i];
		i++;
	}
}

//参数传入struct
extern "C" __declspec(dllexport) void setStruct(User user)
{
	std::cout << "c++ "<< user.name <<" "<<user.age << std::endl;
}


//参数传出struct
extern "C" __declspec(dllexport) void getStruct(User user[],int length)
{
	std::cout << __LINE__ <<"c++ " << user[0].name << " " << user[0].age << std::endl;
	while (length > 0)
	{
		length--;
		strcpy_s(user[length].name, "hahaha");
		user[length].age = 100;
	}
}

//参数传出struct
extern "C" __declspec(dllexport) void copyStructs(User user[],  User user2[], int length)
{
	std::cout << __LINE__ << "c++ " << user[0].name << " " << user[0].age << std::endl;
	while (length > 0)
	{
		length--;
		strcpy_s(user2[length].name, user[0].name);
		user2[length].age = user[0].age;
	}
}

//参数传出struct
extern "C" __declspec(dllexport) void refStructs(void* use, int length)
{
	User* user = (User*)use;
	std::cout << __LINE__ << " c++ " << user[0].name << " " << user[0].age << std::endl;
	while (length > 0)
	{
		length--;
		user->age++;
		user++;
	}
}

//返回值struct指针
extern "C" __declspec(dllexport) User* CreateArray(int length)
{

	User *user = new User[length];
	User *old = user;
	for (int i = 0; i < length; i++)
	{
		strcpy(user->name, "name ");
		user->age = i;
		user->age2 = 3.8;
		strcpy(user->name2, "XX");
		user++;
	}

	return old;
}

//返回值struct指针
extern "C" __declspec(dllexport) void DestroyArray(void* use)
{
	User* user = (User*)use;


	delete[] user;

}


typedef void(*FUNC)(int, const char*);
extern "C" __declspec(dllexport) void processCallback(int a, FUNC func)
{

	func(a, "fff");

}



