using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadStartMenu : MonoBehaviour
{
    //按下畫面任一地方，讀取在File->Build設定為編號0的檔案
    public void Click()
	{
        SceneManager.LoadSceneAsync(0);
    }	
}
