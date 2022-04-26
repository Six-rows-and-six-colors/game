using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoginMenu : MonoBehaviour
{

    public InputField usernameField;
    public InputField passwordField;
    public Button LoginButton;

    public void CallLogin()
    {
        StartCoroutine(Login());
    }

    IEnumerator Login()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", usernameField.text);
        form.AddField("password", passwordField.text);

        WWW www = new WWW("http://localhost/sqlconnect/login.php", form);

        yield return www;

        if (www.text[0] == '0')
        {
            print("User logged in Successfully");
            DBManager.username = usernameField.text;
            DBManager.score =int.Parse( www.text.Split('\t')[1]);
            //print(www.text);
            GoToMainMenu();
        }
        else
        {
            //print("Something error");
            print(" Error #" + www.text);
        }
    }



    public void VerifyInput()
    {
        if (usernameField.text.Length >= 8 && passwordField.text.Length >= 8)
        {
            LoginButton.interactable = true;
        }
    }
    void Start()

    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
