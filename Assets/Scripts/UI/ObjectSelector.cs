using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DD.Action;
using DD.Level;

public class ObjectSelector : MonoBehaviour
{
    [SerializeField] ActionObject actionObject;
    ObjectSpawner objectSpawner;
    bool isSelected = false;

    private void Awake() 
    {
        objectSpawner = FindObjectOfType<ObjectSpawner>();    
    }

    public void ToggleSelector()
    {
        objectSpawner.Deactivate();

        ObjectSelector[] objectSelectors = FindObjectsOfType<ObjectSelector>();
        foreach(ObjectSelector objectSelector in objectSelectors)
        {
            if(!isSelected && objectSelector == this) 
            {
                isSelected = true;
                continue;
            }
            objectSelector.Deselect();
        }        

        if(isSelected)
        {
            objectSpawner.Activate(actionObject);
            GetComponent<Animator>().SetBool("isSelected", true);
        }
    }

    public void Deselect()
    {
        isSelected = false;
        GetComponent<Animator>().SetBool("isSelected", false);
    }
}
