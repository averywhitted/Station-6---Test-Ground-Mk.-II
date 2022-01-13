using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIHelper : MonoBehaviour
{
    public Image gravityOnImage;
    public Image gravityOffImage;
    public string currentObjectText;
    public TMP_Text currentObject;
    public GameObject focusObject;

     Radar radar;

    private void Start()
    {
        radar = GameObject.Find("Radar").GetComponent<Radar>();
        currentObject.text = currentObjectText;
    }

    private void Update()
    {
        currentObject.text = currentObjectText;

        for (int i = 0; i < radar.objectsInRange.Count; i++)
        {
            //Dynamically list objects in range on HUD
            //radar.objectsInRange[i].name
        }
    }

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
}
