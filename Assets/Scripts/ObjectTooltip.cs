using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ObjectTooltip : MonoBehaviour
{
    public UIHelper uIHelper;
    public TMP_Text infoText;
    public Transform target;
    public Camera playerCamera;
    
    // Update is called once per frame
    void Update()
    {
        target = uIHelper.focusObject.transform;
        infoText.transform.position = playerCamera.WorldToScreenPoint(target.position);
    }
}
