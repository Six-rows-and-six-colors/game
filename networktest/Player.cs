using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : NetworkBehaviour
{
    public GameObject bullet, sp;
    public GameObject cp;

    private GameObject fpsCamera;
    private GameObject[] entrance;
    private int playerCount;


    float speed;
    
    
    [Client]
    void Start()
    {
        speed = 0.2f;
        fpsCamera = GameObject.FindGameObjectWithTag("MainCamera");
        entrance = GameObject.FindGameObjectsWithTag("Entrances");
        playerCount = GameObject.FindGameObjectsWithTag("Player").Length;
        this.transform.position = entrance[playerCount - 1].transform.position;
        this.transform.rotation = entrance[playerCount - 1].transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasAuthority) { return; }


        if (isLocalPlayer)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            
            this.transform.position += this.transform.forward* vertical * speed;
            this.transform.Rotate(0, horizontal, 0);

            fpsCamera.transform.position = cp.transform.position;
            fpsCamera.transform.rotation = cp.transform.rotation;

        }
        if (!Input.GetKeyDown(KeyCode.Space)) { return; }

        CmdShoot();
    }

    [Command]
    void CmdShoot()
    {
        RPCShoot();
    }

    [ClientRpc]
    void RPCShoot()
    {
        print("Space");
        GameObject b = Instantiate(bullet);
        b.transform.position = sp.transform.position;
        b.transform.rotation = sp.transform.rotation;
    }
}
