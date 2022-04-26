using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPos : MonoBehaviour
{
    public GameManager _GM;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "P1"|| other.tag == "P2")
        {
            _GM.Win(other.tag);
            print(other.tag + "win");
        }
    }
}
