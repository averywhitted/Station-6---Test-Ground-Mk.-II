using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDir;
    // 1 - Bottom Door
    // 2 - Top Door
    // 3 - Left Door
    // 4 - Right Door
    // Don't worry about making a Destroyer object just copy a Spawn Point, move it to the center of the room, change the openingDir to 0 and set Spawned to true in the inspector before runtime.

    private RoomTemplates templates;
    private int random;
    public bool spawned = false;

    private void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);
    }

    void Spawn()
    {
        if(spawned == false)
        {
            if (openingDir == 1)
            {
                // Needs to spawn room with BOTTOM door
                random = Random.Range(0, templates.bottomRooms.Length);
                Instantiate(templates.bottomRooms[random], transform.position, templates.bottomRooms[random].transform.rotation);
            }
            else if (openingDir == 2)
            {
                //Needs to spawn room with TOP door
                random = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[random], transform.position, templates.topRooms[random].transform.rotation);
            }
            else if (openingDir == 3)
            {
                //Needs to spawn room with LEFT door
                random = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[random], transform.position, templates.leftRooms[random].transform.rotation);
            }
            else if (openingDir == 4)
            {
                //Needs to spawn room with RIGHT door
                random = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[random], transform.position, templates.rightRooms[random].transform.rotation);
            }
        }
        spawned = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("SpawnPoint"))
        {
            if(other.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {
                //Spawn wall to block opening
                Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            spawned = true;
        }
    }
}
