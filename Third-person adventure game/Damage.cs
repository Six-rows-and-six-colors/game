using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Damage : MonoBehaviour
{
    public Transform self;//紀錄自身用
    public float damage;//傷害值
    public AudioClip attSound;//攻擊音效

    bool onAtt = false;//判斷能否攻擊

    Collider coll;
    AudioSource source;

    // Use this for initialization
    void Start()
    {
        coll = GetComponent<Collider>();
        source = GetComponent<AudioSource>();        

        Physics.IgnoreCollision(coll, self.GetComponent<Collider>());

        GameObject[] gos = GameObject.FindGameObjectsWithTag("damage");

        foreach (var go in gos)
        {
            if (go != transform.gameObject)
                Physics.IgnoreCollision(coll, go.GetComponent<Collider>());
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //如果偵測到的物體不是自身，且能攻擊(onAtt = true)
        if (onAtt)
        {
            source.PlayOneShot(attSound);//播放攻擊音效
            //對偵測到的物件廣播到function ApplyDamage，並傳送damage資訊
            other.SendMessage("ApplyDamage", damage, SendMessageOptions.DontRequireReceiver);
            onAtt = false;//確保不會重複傳送damage資訊
        }
    }

    void AttackCheck(bool check)
    {
        onAtt = check;
    }
}
