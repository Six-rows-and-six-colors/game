using UnityEngine;
using System.Collections;

//附加本腳本會自動添加MouseOrbit.cs
[RequireComponent (typeof (MouseOrbit))]
public class CameraRay : MonoBehaviour {

	public LayerMask hitLayer;//Raycast使用的Layer

	MouseOrbit ct;//紀錄MouseOrbit.js用
	float x;//同MouseOrbit.js內的x
	float y;//同MouseOrbit.js內的y
	float startDis;//紀錄MouseOrbit.js內的distance參

	// Use this for initialization
	void Start () {
	
		ct = GetComponent<MouseOrbit>();
		//同MouseOrbit.js內的x、y
		var angles = transform.eulerAngles;
		x = angles.y;
		y = angles.x;
		
		startDis = ct.distance; 
	}
	
	// Update is called once per frame
	void Update () {

		if (!ct) return;
		if (!ct.target) return;
	
		//同MouseOrbit.js內的x、y
		x += Input.GetAxis("Mouse X") * ct.xSpeed * 0.02f;
		y -= Input.GetAxis("Mouse Y") * ct.ySpeed * 0.02f;
		
		y = MouseOrbit.ClampAngle(y, ct.yMinLimit, ct.yMaxLimit);
		//同MouseOrbit.js內的rotation       
		var rotation = Quaternion.Euler(y, x, 0);
		//Raycast所需的方向
		var position = rotation * new Vector3(0, 0, -ct.distance - 0.2f);
		//Raycast所需的起點
		var startPoint = ct.target.position;
		
		ct.distance = startDis;
		
		
		RaycastHit hit;
		if (Physics.Raycast(startPoint, position, out hit, ct.distance + 0.2f,  hitLayer))
		{		
			//更新MouseOrbit.js內的distance參數，使camera不會穿透障礙物
			ct.distance = Mathf.Clamp(hit.distance - 0.2f, 0.3f, startDis);
		}
		//檢測Raycast	
		Debug.DrawRay (startPoint, position, Color.green);	
	}
}
