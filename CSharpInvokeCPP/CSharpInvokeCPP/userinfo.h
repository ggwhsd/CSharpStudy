#pragma once
#include <string>
using namespace std;
class UserInfo {
private:
	char* m_Name;
	int m_Age;
public:
	UserInfo(char* name, int age)
	{
		m_Name = new char[32];
		strcpy_s(m_Name, 32,name);
		m_Age = age;
	}
	virtual ~UserInfo() { }
	int GetAge() { return m_Age; }
	char* GetName() { return m_Name; }
};
