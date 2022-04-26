using UnityEngine;
using UnityEngine.UI;

public class BasketballCourtSwitch : MonoBehaviour
{
    public Image aim;//準心    

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log(hit.gameObject.tag);
        //在球場內可以投球
        if (hit.gameObject.tag == "throwplate")
        {
            BallThrow.onPlate = true;
            aim.enabled = true;
        }
        //離開球場後不可以投球
        else
        {
            BallThrow.onPlate = false;
            aim.enabled = false;
        }
    }
}
