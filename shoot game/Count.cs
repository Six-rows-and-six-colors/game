using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof (AudioSource))]
public class Count : MonoBehaviour {
	
	AudioSource source;

	public Text scoreUi;
	public AudioClip sound;

	static public int score = 0;
	static public int index = 0;

	// Use this for initialization
	void Start () {

		score = 0;
		index = 3;

		source = GetComponent<AudioSource> ();

		RefreshGUI ();
	}	

	void RefreshGUI ()
	{
		scoreUi.text = "Score: " + score;
	}

	void OnTriggerEnter(Collider other) {
	
		if(other.tag == "ball")
		{
			score += index;//計分
			other.tag = "Finish";//避免重複計分
			source.PlayOneShot(sound);//播放音效

			RefreshGUI ();
		}	
	}
}
