using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSelector : MonoBehaviour
{
    public UIHelper uiHelper;

    public Camera playerCamera;

    public Radar radar;
    public float radarRange;
    // Start is called before the first frame update
    void Start()
    {
        radarRange = radar.radarRange;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray cameraRay = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        if(Physics.Raycast(cameraRay, out hit, radarRange))
        {
            if(hit.collider.tag == "DebrisObject")
            {
                ChangeObjectColor(hit.collider.gameObject, Color.red);
                uiHelper.currentObjectText = uiHelper.ShowObjectMetadata(hit.collider.gameObject);
                uiHelper.focusObject = hit.collider.gameObject;
            }
        }
    }

   public void ChangeObjectColor(GameObject obj, Color color)
   {
       obj.GetComponent<MeshRenderer>().material.color = color;
   }
}

