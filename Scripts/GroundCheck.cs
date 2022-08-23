using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public GameObject Player;
    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.layer != 8)
        {
            Player.GetComponent<Movement>().isGrounded = true;
        }
        


    }
    void OnTriggerExit(Collider col)
    {
        Player.GetComponent<Movement>().isGrounded = false;
    }
}
