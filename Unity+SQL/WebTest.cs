using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebTest : MonoBehaviour
{
    
    IEnumerator Start()
    {
        WWW request = new WWW("http://localhost/sqlconnect/webtest.php");
            yield return request;
        print(request.text);
        string[] webResults = request.text.Split('\t');
        foreach (string s in webResults)
        {
            print(s);
        }
        int webSore = int.Parse(webResults[2]);
        webSore *= 2;
        print(webSore);
        
    }

 
}
