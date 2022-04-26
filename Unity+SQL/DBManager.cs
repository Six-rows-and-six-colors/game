using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public  static class DBManager
{

    public static string username;
    public static int score;
    public static bool hasResistered = false;

    public static bool LoggedIn { get { return username != null; } }
    public static void LogOut()
    {
        username = null;
    }



}
