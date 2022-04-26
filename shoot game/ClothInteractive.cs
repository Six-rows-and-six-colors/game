using UnityEngine;
using System.Collections;

public class ClothInteractive : MonoBehaviour {

	Cloth[] cloths;//場景上所有的布料

	// Use this for initialization
	void Start () {
		//搜尋所有布料
		cloths = FindObjectsOfType<Cloth> ();
		//設定與布料互動的碰撞
		for (int i = 0; i < cloths.Length; i++) {

			var collider = new ClothSphereColliderPair();
			collider.first = gameObject.GetComponent<SphereCollider>();

			cloths[i].sphereColliders = new ClothSphereColliderPair[]{collider};
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
