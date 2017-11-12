﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// check 的摘要说明
/// </summary>
public class Check
{
    public Check()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    public bool Space(string str)
    {
        int len, i;
        len = str.Length;
        for (i = 0; i < len; i++)
        {
            if (str[i] == ' ')
                return false;
        }
        return true;
    }

    public int SubmitCheckUser(string UserName, string UserPassword, string CheckPassword, string UserPhone)
    {
        int NameLen, PasswordLen, PhoneLen;
        NameLen = UserName.Length;
        PasswordLen = UserPassword.Length;
        PhoneLen = UserPhone.Length;
        if ((Space(UserName) && Space(UserPassword) && Space(UserPhone)) == false)
            return 1;
        if (NameLen < 5 || NameLen > 11)
            return 2;
        if (PasswordLen < 5 || PasswordLen > 11)
            return 3;
        if (UserPassword != CheckPassword)
            return 4;
        if (PhoneLen != 11)
            return 5;
        else
            return 6;
    }
    
}