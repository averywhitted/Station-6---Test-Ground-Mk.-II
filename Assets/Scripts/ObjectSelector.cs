using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSelector : MonoBehaviour
{
    public UIHelper uiHelper;

    public Camera playerCamera;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray cameraRay = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        if(Physics.Raycast(cameraRay, out hit, 50f))
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

