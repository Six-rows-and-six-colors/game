using UnityEngine;

public class BallRemover : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        //5秒後刪除物件
        Destroy(gameObject, 5);
    }
}
