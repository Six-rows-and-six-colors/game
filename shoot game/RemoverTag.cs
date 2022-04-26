using UnityEngine;
using System.Collections;

public class RemoverTag : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	//進入觸發框後，將籃球的標籤改掉
	void OnTriggerEnter(Collider other) {
		
		if(other.tag == "ball")
			other.tag = "Finish";
	}
}
