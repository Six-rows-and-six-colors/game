using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject cube;
    void Start()
    {
        //cube.transform.position = new Vector3(0,0,0);
        //cube.transform.position = Vector3.one;
        cube.transform.localScale = Vector3.one;
        print("方塊移動");
        //Debug.Log("偵錯訊息");
        //UnityEngine.Debug.Log("偵錯訊息");
        // UnityEngine.Debug.LogWarning("警告訊息");
        //UnityEngine.Debug.LogError("錯誤訊息");
    }


    void Update()
    {
        
    }
}
