using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class KeyCollect : MonoBehaviour
{
    static public int Count;//紀錄獲得鑰匙的數量
    public AudioClip CollectSound;//拾取鑰匙音效

    AudioSource source;

    // Use this for initialization
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "key")//標籤為key的物件
        {
            Destroy(collision.gameObject);//刪除他
            Count++;//鑰匙加一
            source.PlayOneShot(CollectSound);//撥放音效
        }
    }
}
