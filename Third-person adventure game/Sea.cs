using UnityEngine;

public class Sea : MonoBehaviour
{
    Material mat;
    Vector2 offset;

    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        offset.y += Time.deltaTime * 0.05f;
        mat.SetTextureOffset("_MainTex", offset);
    }
}
