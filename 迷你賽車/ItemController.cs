using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public GameObject cube;
    public GameManager _GM;
    public GameObject P1, P2;
    public AudioSource Audio;
    public float Speed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(Vector3.up * Speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "P1")
        {
            Audio.Play();
            //_GM.StartCoroutine(P1ConuntThreeFast());
            _GM.Itemcontroller(other.tag);
            Destroy(cube);
        }
        else if (other.tag == "P2")
        {
            Audio.Play();
            //_GM.StartCoroutine(P2ConuntThreeFast());
            _GM.Itemcontroller(other.tag);
            Destroy(cube);
        }
    }

    
}
