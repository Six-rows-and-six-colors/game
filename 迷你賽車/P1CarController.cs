using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1CarController : MonoBehaviour
{
    public bool isItem;
    public KeyCode KC_item;
    public GameManager _GM;
    public GameObject P1, P2;
    public AudioSource fast, change;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        if (isItem)
        {
            CarItem();
        }
    }

    public void GetInput()
    {
        isItem = Input.GetKeyDown(KC_item);
    }
    public void CarItem()
    {
        if (_GM.P1Item1)
        {
            if (_GM.P1whichItem==0)
            {
                _GM.StartCoroutine(P1ConuntThreeFast());
                _GM.P1ItemIamage1.SetActive(false);
                _GM.P1Item1 = false;
                fast.Play();
                _GM.P1Item1 = false;

            }
            if (_GM.P1whichItem == 1)
            {
                _GM.StartCoroutine(P1ConuntThreeSwitch());
                _GM.P1ItemIamage1.SetActive(false);
                _GM.P1Item1 = false;
                change.Play();
                _GM.P1Item1 = false;
            }
        }
        else if (_GM.P2Item1)
        {
            if (_GM.P2whichItem == 0)
            {
                _GM.StartCoroutine(P2ConuntThreeFast());
                _GM.P2ItemIamage1.SetActive(false);
                _GM.P2Item1 = false;
                fast.Play();
                _GM.P1Item1 = false;

            }
            if (_GM.P2whichItem == 1)
            {
                _GM.StartCoroutine(P2ConuntThreeSwitch());
                _GM.P2ItemIamage1.SetActive(false);
                _GM.P2Item1 = false;
                change.Play();
                _GM.P2Item1 = false;
            }
        }
    }
    public IEnumerator P1ConuntThreeFast()
    {
        P1.GetComponent<CarController>().motorTorque = 50000;
        yield return new WaitForSeconds(1);
        P1.GetComponent<CarController>().motorTorque = 45000;
        yield return new WaitForSeconds(1);
        P1.GetComponent<CarController>().motorTorque = 40000;
        yield return new WaitForSeconds(1);
        P1.GetComponent<CarController>().motorTorque = 30000;

    }
    public IEnumerator P1ConuntThreeSwitch()
    {
        P2.GetComponent<CarController>().Axis_V = "Horizontal 1";
        P2.GetComponent<CarController>().Axis_H = "Vertical 1";
        yield return new WaitForSeconds(1);
        yield return new WaitForSeconds(1);
        yield return new WaitForSeconds(1);
        P2.GetComponent<CarController>().Axis_H = "Horizontal 1";
        P2.GetComponent<CarController>().Axis_V = "Vertical 1";
    }
    public IEnumerator P2ConuntThreeFast()
    {
        P1.GetComponent<CarController>().motorTorque = 50000;
        yield return new WaitForSeconds(1);
        P1.GetComponent<CarController>().motorTorque = 45000;
        yield return new WaitForSeconds(1);
        P1.GetComponent<CarController>().motorTorque = 40000;
        yield return new WaitForSeconds(1);
        P1.GetComponent<CarController>().motorTorque = 30000;

    }
    public IEnumerator P2ConuntThreeSwitch()
    {
        P1.GetComponent<CarController>().Axis_V = "Horizontal";
        P1.GetComponent<CarController>().Axis_H = "Vertical";
        yield return new WaitForSeconds(1);
        yield return new WaitForSeconds(1);
        yield return new WaitForSeconds(1);
        P1.GetComponent<CarController>().Axis_H = "Horizontal";
        P1.GetComponent<CarController>().Axis_V = "Vertical";
    }
}
