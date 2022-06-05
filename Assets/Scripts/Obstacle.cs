using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    pMove playerMovement;
    void Start()
    {
        playerMovement = GameObject.FindObjectOfType<pMove>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name=="Player")
        {
            playerMovement.die();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
