using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AutoAlign : MonoBehaviour
{
    public GameObject player;
    public Transform alignTo;
    public GameObject alignmentObject;
    public InputManager inputManager;

    public void AlignObjects(GameObject currentObject, GameObject targetObject)
    {
        //Quaternion current = currentObject.transform.localRotation;
        //Quaternion target = targetObject.transform.localRotation;
        
        //currentObject.transform.rotation = Quaternion.Slerp(current, target, Time.deltaTime * 0.5f);

        currentObject.transform.DORotate(new Vector3(targetObject.transform.eulerAngles.x, targetObject.transform.eulerAngles.y, targetObject.transform.eulerAngles.z), 2f);
    }

    void Update()
    {
        if (inputManager.GetAlignToTarget())
        {
            player.transform.DORotate(new Vector3(0, player.transform.eulerAngles.y, 0), 2f);
        }
    }

    IEnumerator SmoothAlign()
    {
        while (player.transform.rotation != this.transform.rotation)
        {
            AlignObjects(player, this.gameObject);
            yield return null;
        }
    }
}
