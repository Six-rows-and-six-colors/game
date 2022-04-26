using UnityEngine;

public class BlueMove : MonoBehaviour
{
    public float speed = 3f;

    bool sendAttack;//避免一直發送BroadcastMessage
    Animator m_Animator;

    // Use this for initialization
    void Start()
    {
        m_Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = (Vector3.forward * m_Animator.GetFloat("Forward") * 0.01f * speed * Time.deltaTime) / Time.deltaTime;
        transform.Translate(v);

        //在地面時
        if (m_Animator.GetBool("OnGround"))
        {
            m_Animator.SetBool("Attack", Input.GetMouseButton(0));

            //廣播到void AttackCheck
            if (m_Animator.GetBool("Attack") && !sendAttack)
                BroadcastMessage("AttackCheck", sendAttack = true, SendMessageOptions.DontRequireReceiver);
            //沒有按下滑鼠左鍵，廣播到void AttackCheck
            else if (sendAttack)
                BroadcastMessage("AttackCheck", sendAttack = false, SendMessageOptions.DontRequireReceiver);
        }
    }
}
