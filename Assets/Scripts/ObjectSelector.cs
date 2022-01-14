using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObjectSelector : MonoBehaviour
{
    public UIHelper uiHelper;

    public Camera playerCamera;

    public Radar radar;
    public float radarRange;

    public GameObject currentObject;
    public Color highlightColor;
    public Color unHighlightColor;
    public string radarObjectsInRangeString;
    // Start is called before the first frame update
    void Start()
    {
        radarRange = radar.radarRange;
    }

    // Update is called once per frame
    void Update()
    {
        //RaycastHit hit;
        //Ray cameraRay = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        //if(Physics.Raycast(cameraRay, out hit, radarRange))
        //{
        //    if(hit.collider.tag == "DebrisObject")
        //    {
        //        HighlightObject(hit.collider.gameObject, highlightColor);
        //        uiHelper.currentObjectText = uiHelper.ShowObjectMetadata(hit.collider.gameObject);
        //        uiHelper.focusObject = hit.collider.gameObject;
        //    }
        //}
    }

   public void HighlightObject(GameObject obj, Color color)
   {
       if(currentObject != obj)
       {
            currentObject = obj;
            var outline = obj.GetComponent<Outline>();
            Sequence seq = DOTween.Sequence();
            seq.AppendCallback(() => outline.OutlineColor = Color.Lerp(unHighlightColor, highlightColor, 2));
       }
   }

   public void UnHiglightObject(GameObject obj)
   {
        currentObject = null;
        var outline = obj.GetComponent<Outline>();
        Sequence seq = DOTween.Sequence();
        seq.AppendCallback(() => outline.OutlineColor = Color.Lerp(highlightColor, unHighlightColor, 2));
   }

   public string SaveListAsString(List<GameObject> list)
   {
       return list.ToString();
   }
}

