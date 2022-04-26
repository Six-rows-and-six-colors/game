using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public float HP;//生命值
    public Text HP_Text;//顯示生命值
    public Slider HP_Texture;//血條

    float MaxHP;//最大生命值

    // Use this for initialization
    void Start()
    {
        MaxHP = HP;//紀錄最大生命值
        HP_Text.text = "HP: " + HP + " / " + MaxHP;//顯示生命值文字
    }

    // Update is called once per frame
    void Update()
    {
        //當生命小於等於0，讀取在File->Build設定為編號2的檔案
        if (HP <= 0)
        {
            SceneManager.LoadSceneAsync(2);
            HP = 0;
        }
    }

    void ApplyDamage(float damage)
    {
        if (HP <= 0) return;//生命小於等於0，返回
        //當ApplyDamage被呼叫，生命值減少
        HP -= damage;
        //計算生命值百分比
        var HPRatioh = Mathf.Clamp01(HP / MaxHP);
        //控制血條
        HP_Texture.value = HPRatioh;
        //控制生命值文字
        HP_Text.text = "HP: " + Mathf.Floor(HP) + " / " + MaxHP;
    }
}
