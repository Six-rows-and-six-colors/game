using UnityEngine;
using UnityEngine.UI;

public class AI : MonoBehaviour
{
    float MaxHP;//最大生命值
    float HPGUIWidth = 250f;//紀錄血條寬度
    float dis;//記錄自己與目標的距離用
    float GUIDisplayTime;//GUI顯示的時間
    float ApplyDamageTime;//無敵秒數

    Animator anim;

    public Transform target;//目標
    public float HP = 200f;//生命值
    public float moveSpeed = 1f;//移動速度

    //頭像、血條、血條底圖等圖片
    public GameObject hpUI;
    public Sprite headIcon;
    public Image headUI;
    public Slider hpSlider;

    public float searchRange;//搜尋範圍
    public float attRange;//攻擊範圍

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();//動畫組件，後面會常用到先存起來
        MaxHP = HP;//紀錄最大生命值
    }

    // Update is called once per frame
    void Update()
    {
        dis = Vector3.Distance(transform.position, target.position);//計算與目標的距離
        //當在搜尋範圍內
        if (dis < searchRange)
        {
            //面向目標
            transform.LookAt(target);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            //當在攻擊範圍內
            if (dis < attRange)
            {
                if (!anim.GetCurrentAnimatorStateInfo(0).IsName("attack"))
                    anim.Play("attack");//播放攻擊動畫											
            }
            else//否則
            {
                transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);//往目標移動

                if (!anim.GetCurrentAnimatorStateInfo(0).IsName("walk"))
                    anim.Play("walk");//播放走路動畫
            }
        }

        //無敵時間一直減少			
        ApplyDamageTime -= Time.deltaTime;
        //顯示血量
        ShowHP();
        //當生命小於等於0，死亡
        if (HP <= 0)
            Destroy(gameObject);
    }

    void ShowHP()
    {
        //UI顯示時間小於等於0不顯示
        if (GUIDisplayTime <= 0) return;
        //顯示血量與設定血量頭像UI
        if (!hpUI.activeSelf)
        {
            hpUI.SetActive(true);
            headUI.sprite = headIcon;
        }
        //計算生命值百分比
        hpSlider.value = Mathf.Clamp01(HP / MaxHP);
        //GUI顯示時間一直減少
        GUIDisplayTime -= Time.deltaTime;
        //UI顯示時間小於等於0或生命小於等於0關閉血量UI
        if (GUIDisplayTime <= 0 || HP <= 0)
            hpUI.SetActive(false);
    }

    void attStart()
    {
        BroadcastMessage("AttackCheck", true, SendMessageOptions.DontRequireReceiver);//廣播到function attackCheck，並傳送true資訊
    }

    void attEnd()
    {
        BroadcastMessage("AttackCheck", false, SendMessageOptions.DontRequireReceiver);//廣播到function attackCheck，並傳送false資訊
    }

    void ApplyDamage(float damage)
    {
        if (HP <= 0) return;
        if (ApplyDamageTime > 0) return;

        ApplyDamageTime = 1;//無敵時間增加至1秒	       
        GUIDisplayTime = 5;//GUI顯示時間增加至5秒       
        anim.Play("hurt");//播放受傷動畫       
        HP -= damage;//生命值減少(減少的數量取決於接受多少damage)
    }

    //Scene視窗用的輔助設定
    void OnDrawGizmosSelected()
    {        
        Gizmos.color = Color.green;//顏色設為綠色       
        Gizmos.DrawWireSphere(transform.position, searchRange);//畫出搜尋範圍       
        Gizmos.color = Color.red;//顏色設為紅色        
        Gizmos.DrawWireSphere(transform.position, attRange);//畫出攻擊範圍
    }
}
