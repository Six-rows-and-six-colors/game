using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text message;

    public Button registerButton;
    public Button loginButton;
    public Button playgameButton;
    void Start()
    {
        if (DBManager.LoggedIn)
        {
            message.text = DBManager.username + " has logged in.";
        }
        else
        {
            if (DBManager.hasResistered)
            {
                message.text = "Registration Successfully";
            }
        }

        registerButton.interactable = (DBManager.username == null);
        loginButton.interactable= (DBManager.username == null);
        playgameButton.interactable =!(DBManager.username == null);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToLoginMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToRegisterMenu()
    {
        SceneManager.LoadScene(2);
    }


    public void GoToGame()
    {
        SceneManager.LoadScene(3);
    }
}
