using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    public Text usernameText;
    public Text scoreText;
    void Start()
    {
        if (DBManager.username == null)
        {
            SceneManager.LoadScene(0);
        }
        usernameText.text = "Username:"+DBManager.username;
        scoreText.text = "Score:"+DBManager.score;
    }

    // Update is called once per frame
    
    public void IncreasePoints()
    {
        DBManager.score++;
        scoreText.text = "Score" + DBManager.score;
    }

    public void CallSaveData()
    {
        StartCoroutine(SavePlayerData());
    }

    IEnumerator SavePlayerData()
    {
        WWWForm form = new WWWForm();
        form.AddField("username",DBManager.username );
        form.AddField("score", DBManager.score);

        WWW www = new WWW("http://localhost/sqlconnect/savedata.php", form);

        yield return www;

        
        
        if(www.text == "0")
        {
            print("Game Saved.");
        }
        else
        {
            print("Save Player Data Error # " + www.text);
        }
        DBManager.LogOut();
        SceneManager.LoadScene(0);
    }
}
