using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ObjectTooltip : MonoBehaviour
{
    public UIHelper uIHelper;
    public GameObject infoText;
    public Transform target;
    public Camera playerCamera;

    public float UIscaleFactor = 0.0001f;
    
    // Update is called once per frame
    void Update()
    {
        target = uIHelper.focusObject.transform;
        infoText.transform.position = playerCamera.WorldToScreenPoint(new Vector3(target.transform.position.x * UIscaleFactor, target.transform.position.y * UIscaleFactor, 0f));
    }
}
