using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    public GameObject P1,P2;
    public GameObject i1,i2,i3,iGO,EndPanel;
    public GameObject maincamera;
    public GameObject maincanvas;
    public GameObject gameitems;
    public Text WinText;
    public string Winplayer;

    public Animator anim_Move;

    public AudioSource WinSound;

    public float GamingTime;
    public Text T_gamingtime;
    public bool isGameStart;
    List<Score> scoreList = new List<Score>();

    public Transform LBContent;
    public GameObject Prefab_LBitem;
    public GameObject Inputpanel;
    public InputField IF_Name;

    public bool P1Item1 = false;
    public bool P2Item1 = false;

    public int P1whichItem;
    public int P2whichItem;

    public GameObject P1ItemIamage1;
    public GameObject P2ItemIamage1;

    public Sprite[] P1ItemPng1;
    public Sprite[] P2ItemPng1;
    void Start()
    {
        LoadData();
    }

    
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            EscFuction();
        }

        if (isGameStart)
        {
            GamingTime += Time.deltaTime;
            T_gamingtime.text = TimeToString(GamingTime);
        }
    }

    public void Win( string _player)
    {
        P1.GetComponent<CarController>().isStart = false;
        P2.GetComponent<CarController>().isStart = false;
        EndPanel.SetActive(true);
        P1.GetComponent<CarController>().ResetCar();
        P2.GetComponent<CarController>().ResetCar();
        Winplayer = _player + "win";
        WinText.text = Winplayer;
        anim_Move.enabled = false;
        WinSound.Play();
        isGameStart = false;

    }

    public IEnumerator CountDown()
    {
        i1.SetActive(true);
        i2.SetActive(true);
        i3.SetActive(true);
        iGO.SetActive(true);

        yield return new WaitForSeconds(1);
        i3.SetActive(false);
        yield return new WaitForSeconds(1);
        i2.SetActive(false);
        yield return new WaitForSeconds(1);
        i1.SetActive(false);

        P1.GetComponent<CarController>().isStart = true;
        P2.GetComponent<CarController>().isStart = true;
        isGameStart = true;



        yield return new WaitForSeconds(1);
        iGO.SetActive(false);

        anim_Move.enabled = true;
    }

    public void PlayGame()
    {
        maincamera.SetActive(false);
        maincanvas.SetActive(false);
        gameitems.SetActive(true);
        GamingTime = 0;
        T_gamingtime.text = TimeToString(GamingTime);
        StartCoroutine(CountDown());
    }

    public void EscFuction()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
       
    public string TimeToString(float result)
    {
        int hour = (int)result / 3600;
        int minute = ((int)result - hour * 3600) / 60;
        int second =(int)result - hour * 3600 -minute / 60;
        int millisecond= (int)((result - (int)result) * 1000);
        string data = string.Format("{0:D2}:{1:D2}:{2:D2}.{3:D2}", hour, minute, second, millisecond);
        return data;
    }

    public void AddLeaderBoard()
    {
        if (IF_Name.text.Length == 0)
            return;
        Inputpanel.SetActive(false);
        scoreList.Add(new Score(IF_Name.text, (int)(GamingTime * 1000)));
        scoreList.Sort();
        scoreList.Reverse();
        SavaData();

        for(int i = 0;i<LBContent.childCount; i++)
        {
            Destroy(LBContent.GetChild(i).gameObject);
        }
        LBContent.GetComponent<RectTransform>().sizeDelta = Vector2.zero;

        for(int i = 0; i<scoreList.Count; i++)
        {
            GameObject item = Instantiate(Prefab_LBitem);
            item.transform.SetParent(LBContent, false);
            item.transform.Find("RankingText").GetComponent<Text>().text = (i + 1).ToString();
            item.transform.Find("NameText").GetComponent<Text>().text = scoreList[i].name;
            item.transform.Find("TimeText").GetComponent<Text>().text = TimeToString(scoreList[i].time / 1000f);
            Vector2 V2_lbc = LBContent.GetComponent<RectTransform>().sizeDelta;
            LBContent.GetComponent<RectTransform>().sizeDelta = new Vector2(V2_lbc.x, V2_lbc.y+ 100);
        }
    }

    public void SavaData()
    {
        StreamWriter sw = new StreamWriter(Application.dataPath + "/Resources/RankingList.txt");

        if(scoreList.Count> 5)
        
            for(int i =5;i<= scoreList.Count; i++)
            {
                scoreList.RemoveAt(i);
            }
        



     
        foreach(Score t in scoreList)
        {
            sw.WriteLine(JsonUtility.ToJson(t));
        }
        sw.Close();
    }

    public void LoadData()
    {
        StreamReader sr = new StreamReader(Application.dataPath + "/Resources/RankingList.txt");
        string nextLine;
        while((nextLine=sr.ReadLine()) != null)
        {
            scoreList.Add(JsonUtility.FromJson<Score>(nextLine));
            scoreList.Sort();
            scoreList.Reverse();
        }
        sr.Close();
    }

    public void Itemcontroller(string _player)
    {
        if (_player == "P1")
        {
            P1Item1 = true;
            P1whichItem = Random.Range(0, 2);
            P1ItemIamage1.SetActive(true);
            P1ItemIamage1.GetComponent<Image>().sprite = P1ItemPng1[P1whichItem];

        }
        else if (_player == "P2")
        {
            P2Item1 = true;
            P2whichItem = Random.Range(0, 2);
            P2ItemIamage1.SetActive(true);
            P2ItemIamage1.GetComponent<Image>().sprite = P2ItemPng1[P2whichItem];

        }
    }
}
