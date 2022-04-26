using UnityEngine;
using UnityEngine.UI;

public class NPCDialog : MonoBehaviour
{
    public Transform player;//主角
    public Transform NPC;
    public Transform key;//開門用的鑰匙
    public GameObject dialogUI;

    float dis;//紀錄主角與NPC的距離用

    // Use this for initialization
    void Start()
    {
        key.gameObject.SetActive(false);//先將鑰匙隱藏
        dialogUI.GetComponentInChildren<Button>().onClick.AddListener(DialogClick);
    }

    // Update is called once per frame
    void Update()
    {
        dis = Vector3.Distance(NPC.transform.position, player.position);//計算主角與NPC距離

        if (dis < 5)//當主角靠近NPC時
        {
            NPC.transform.LookAt(player);//NPC面向主角
            NPC.transform.eulerAngles = new Vector3(0, NPC.transform.eulerAngles.y, 0);
        }
    }

    //進入觸發區域後啟動對話
    void OnTriggerEnter(Collider other)
    {
        if (other.transform == player && dis < 5)
            dialogUI.SetActive(true);
    }

    //離開區域結束對話
    void OnTriggerExit(Collider other)
    {
        if (other.transform == player && dis < 5)
            dialogUI.SetActive(false);
    }

    void DialogClick()
    {
        if (key)
        {
            key.gameObject.SetActive(true);
            dialogUI.SetActive(false);
        }
    }
}
