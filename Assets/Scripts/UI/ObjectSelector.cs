using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DD.Object;
using DD.Level;
using UnityEngine.UI;
using TMPro;
using DD.PlayData;

public class ObjectSelector : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] Image objectImage = null;
    [SerializeField] TextMeshProUGUI nameText = null;
    [SerializeField] TextMeshProUGUI costText = null;

    [Header("Object")]
    [SerializeField] ActionObject objectToSelect;

    [Header("Color")]
    [SerializeField] Color canSelectColor;
    [SerializeField] Color cannotSelectColor;

    // Reference
    ObjectSpawner objectSpawner;
    Resource resource;

    // Status
    bool isSelected = false;

    private void Awake()
    {
        objectSpawner = FindObjectOfType<ObjectSpawner>();
        resource = FindObjectOfType<Resource>();
    }

    private void Start()
    {
        UpdateSelector();
    }

    private void Update()
    {
        UpdateCostTextColor();
        if(isSelected && !CanSelect()) Deselect();
    }

    void UpdateSelector()
    {
        objectImage.sprite = objectToSelect.profile.repSprite;
        nameText.text = objectToSelect.profile.myName;
        costText.text = "● " + objectToSelect.profile.cost;
    }

    void UpdateCostTextColor()
    {
        if (CanSelect()) costText.color = canSelectColor;
        else costText.color = cannotSelectColor;
    }

    bool CanSelect()
    {
        return resource.GetCurrentCoin() >= objectToSelect.profile.cost;
    }

    public void ToggleSelector()
    {
        if(!CanSelect()) return;

        ObjectSelector[] objectSelectors = FindObjectsOfType<ObjectSelector>();
        foreach (ObjectSelector objectSelector in objectSelectors)
        {
            if (!isSelected && objectSelector == this)
            {
                isSelected = true;
                continue;
            }
            objectSelector.Deselect();
        }

        if (isSelected)
        {
            objectSpawner.Activate(objectToSelect);
            GetComponent<Animator>().SetBool("isSelected", true);
        }
    }

    public void Deselect()
    {
        isSelected = false;
        GetComponent<Animator>().SetBool("isSelected", false);

        objectSpawner.Deactivate();
    }
}
