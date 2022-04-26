using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    //按下此按鈕，讀取在File->Build設定為編號1的檔案
    public void ClickStartGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    //按下此按鈕，離開遊戲
    public void ClickExitGame()
    {
        Application.Quit();
    }
}
