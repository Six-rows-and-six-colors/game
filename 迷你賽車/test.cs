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
        print("�������");
        //Debug.Log("�����T��");
        //UnityEngine.Debug.Log("�����T��");
        // UnityEngine.Debug.LogWarning("ĵ�i�T��");
        //UnityEngine.Debug.LogError("���~�T��");
    }


    void Update()
    {
        
    }
}
