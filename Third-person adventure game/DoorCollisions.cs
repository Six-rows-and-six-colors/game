using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DoorCollisions : MonoBehaviour
{
    public AudioClip openAudio;//開門音效
    public AudioClip closeAudio;//關門音效

    float timer;//關門倒數用的時間
    bool doorOpened;//判斷開關門
    Transform city;//撥放開關門的物件

    AudioSource source;

    // Use this for initialization
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (doorOpened)//開門後開始計算時間
            timer += Time.deltaTime;

        if (timer >= 5)//5秒後呼叫"closeDoor"函數
            CloseDoor();
    }

    void OnCollisionEnter(Collision collision)
    {
        //開門的條件，標籤、關門、撿到鑰匙
        //keyCollect.Count為keyCollect.cs裡的Count變數
        if (collision.gameObject.tag == "cityDoor" && !doorOpened && KeyCollect.Count > 0)
        {
            if (!city)
                city = collision.transform.root;//為標籤"citydoor"的根物件
            OpenDoor();//呼叫"openDoor"函數
        }
    }

    void CloseDoor()
    {
        city.GetComponent<Animator>().Play("doorClose");//播放名為"doorclose"動畫
        doorOpened = false;//表示關門
        source.PlayOneShot(closeAudio);//關門音效	
        timer = 0;//時間歸零
    }

    void OpenDoor()
    {
        doorOpened = true;//表示開門
        city.GetComponent<Animator>().Play("doorOpen"); //播放名為"dooropen"動畫
        source.PlayOneShot(openAudio);//開門音效			
    }
}
