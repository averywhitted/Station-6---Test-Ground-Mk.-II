using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Location : MonoBehaviour
{
    public AutoAlign autoAlign;
    public GameObject player;
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Entered Location: " + this.name);
            //StartCoroutine(SmoothAlign());
            autoAlign.AlignObjects(player, this.gameObject);
        }
    }
    public void OnTeleport(bool gravity)
    {
        if(gravity == true)
        {
            //Set Gravity to true
        }
    }

    IEnumerator SmoothAlign()
    {
        while (player.transform.rotation != this.transform.rotation)
        {
            autoAlign.AlignObjects(player, this.gameObject);
            yield return null;
        }
    }
}
