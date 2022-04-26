using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiePlane : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "P1" || other.tag == "P2")

        {
            //other.GetComponent<CarController>().ResetCar();
            other.GetComponent<CarController>().isReset = true;
        }
    }

}

