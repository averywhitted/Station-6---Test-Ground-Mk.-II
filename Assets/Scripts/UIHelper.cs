using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIHelper : MonoBehaviour
{
    //Gravity Indicator
    public Image gravityOnImage;
    public Image gravityOffImage;

    //Object Tracking
    Radar radar;
    public TMP_Text objectsInRange;
    public GameObject focusObject;
    public string noObjectMessage;
    public TMP_Text currentObject;
    public TMP_Text currentObjectHydrogen;
    public TMP_Text currentObjectHelium;
    public TMP_Text currentObjectCarbon;
    public TMP_Text currentObjectOxygen;
    

    //FPS Counter
    public TMP_Text fpsCounter;
    public FPSCounter fpsCounterScript;

    private void Start()
    {
        radar = GameObject.Find("Radar").GetComponent<Radar>();
        currentObject.text = noObjectMessage;
    }

    private void Update()
    {
        objectsInRange.text = ListToString(radar.objectsInRangeNames);

        GetObjectInfo(focusObject);
        //FPS Counter
        fpsCounter.text = FPSCounter(fpsCounterScript.m_lastFramerate);
    }

/*
    public string ShowObjectMetadata(GameObject obj)
    {
        //Get object metadata as text.
            string objectName = obj.name;
            string objectPosition = obj.transform.position.ToString();
            string objectHydrogen = obj.GetComponent<DebrisObject>().metadata.hydrogen.ToString();
            string objectHelium = obj.GetComponent<DebrisObject>().metadata.helium.ToString();
            string objectOxygen = obj.GetComponent<DebrisObject>().metadata.oxygen.ToString();
            string objectCarbon = obj.GetComponent<DebrisObject>().metadata.carbon.ToString();
            
            return objectName + "\n" + 
            objectPosition + "\n" + "\n" +
            "H: " + objectHydrogen + "\n" +
            "He: " + objectHelium + "\n" +
            "O: " + objectOxygen + "\n" +
            "C: " + objectCarbon;
    }
    */


///Object Tracking Getter Functions
    public void GetObjectInfo(GameObject obj)
    {
        DebrisObject debrisObejct = obj.GetComponent<DebrisObject>();

        currentObject.text = debrisObejct.name;
        currentObjectHydrogen.text = debrisObejct.hydrogen.ToString();
        currentObjectHelium.text = debrisObejct.helium.ToString();
        currentObjectCarbon.text = debrisObejct.carbon.ToString();
        currentObjectOxygen.text = debrisObejct.oxygen.ToString();
    }


///HELPER FUNCTIONS///

    public string ListToString(List<string> list)
    {
        string result = string.Join("\n", list);
        return result;
    }


///FPS COUNTER///
    public string FPSCounter(float fps)
    {
        string fpsString = fps.ToString();

        return fpsString;
    }

}
