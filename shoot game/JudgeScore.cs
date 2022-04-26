using UnityEngine;

public class JudgeScore : MonoBehaviour
{
	void OnTriggerStay(Collider other)
    {	
		if (other.tag == "Player")
			Count.index = 2;		
	}

	void OnTriggerExit(Collider other)
    {
		if (other.tag == "Player")
			Count.index = 3;
	}
}
