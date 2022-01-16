using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour
{
    public GameObject[] allDebrisObjects;
    public List<GameObject> objectsInRange;
    public List<string> objectsInRangeNames;
    public float radarRange;
    public SphereCollider sphereCollider;

    void Start()
    {
        sphereCollider.radius = radarRange;
    }


    void Update()
    {
        foreach (var obj in objectsInRange)
        {
            Debug.DrawLine(transform.position, obj.transform.position, Color.red);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("DebrisObject"))
        {
            objectsInRange.Add(other.gameObject);
            objectsInRangeNames.Add(other.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("DebrisObject"))
        {
            objectsInRange.Remove(other.gameObject);
            objectsInRangeNames.Remove(other.name);
        }
    }
}
