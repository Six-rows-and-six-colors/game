using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabSwitch : MonoBehaviour
{
    public InputField nextField;

    InputField myField;
    void Start()
    {
        myField = this.GetComponent<InputField>();
    }

    
    void Update()
    {
        if (myField.isFocused)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                nextField.ActivateInputField();
            }
        }
    }
}
