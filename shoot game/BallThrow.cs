using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class BallThrow : MonoBehaviour {

	public Rigidbody ball;//球

	public Transform basketL;//左籃框
	public Transform basketR;//右籃框

	public AudioClip throwSound;//投球音效
	public float throwFreq = 1f;//投球頻率

	public static bool onPlate = false;//判斷是否在球場

	Transform lookBasket;//面向的籃框

	float throwForce;//投球力道
	float dis;//距離
	float  lastThrow; 

	// Use this for initialization
	void Start () {
		lookBasket = basketL;
	}
	
	// Update is called once per frame
	void Update () {
	
		Cursor.lockState = CursorLockMode.Locked;//鎖定滑鼠游標
		Cursor.visible = false;//隱藏滑鼠游標

		dis = Vector3.Distance(lookBasket.position, transform.position);
		throwForce = dis - 0.5f;//根據人物離籃框距離決定投球力道
		
		//判斷要面對哪個籃框
		if (throwForce > 17 && lookBasket == basketL)
			lookBasket =  basketR;
		else if (throwForce > 17 && lookBasket == basketR)
			lookBasket = basketL;
		else if(throwForce > 12)
			throwForce = 12;
		
		//當在球場上時
		if(onPlate)
		{
			if(Input.GetButtonUp("Fire1")&&(Time.time >  lastThrow + throwFreq))//按下後放開滑鼠左鍵且在頻率之內
			{			
				Rigidbody Ball = Instantiate(ball, transform.position, transform.rotation) as Rigidbody;//產生球
				Ball.velocity = transform.TransformDirection(new Vector3 (0,0,throwForce));	//將球往Z軸丟出
				
				Physics.IgnoreCollision(Ball.GetComponent<Collider>(), transform.root.GetComponent<Collider>());//忽略自身碰撞
				
				GetComponent<AudioSource>().PlayOneShot(throwSound);//播音效
				lastThrow = Time.time;//更新頻率

			}
		}
	}
}
