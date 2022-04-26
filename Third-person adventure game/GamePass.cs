using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePass : MonoBehaviour
{
	//宣告:有2個敵人
	public GameObject enemy1;
	public GameObject enemy2;

	// Update is called once per frame
	void Update ()
    {
        //當消滅所有敵人，讀取在File->Build設定為編號3的檔案
        if (!enemy1 && !enemy2)
            SceneManager.LoadScene(3); 
    }
}
