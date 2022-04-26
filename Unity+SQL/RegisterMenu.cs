using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class RegisterMenu : MonoBehaviour
{

    public InputField usernameField;
    public InputField passwordField;
    public Button registerButton;


    public void CallRegister()
    {
        StartCoroutine(Register());
    }

    IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", usernameField.text);
        form.AddField("password", passwordField.text);
        
        WWW www = new WWW("http://localhost/sqlconnect/register.php",form);

        yield return www;


        
        if (www.text =="0")
        {
            print("User created Successfully");
            DBManager.hasResistered = true;
            GoToMainMenu();
        }
        else
        {
            print("User creation Failed");
            print(" Error #" + www.text);
        }

    }

    public void VerifyInput()
    {
        if(usernameField.text.Length>=8 && passwordField.text.Length >=8)
        {
            registerButton.interactable = true;
        }
    }


    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
