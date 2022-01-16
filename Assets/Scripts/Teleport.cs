using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject player;
    public GameObject teleportSensor;
    public GameObject teleportDestination;
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == teleportSensor)
        {
            player.transform.position = teleportDestination.transform.position;
            Debug.Log("TELEPORTED!");
        }
    }
}
