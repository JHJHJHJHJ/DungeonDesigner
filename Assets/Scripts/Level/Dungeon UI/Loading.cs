using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.ProceduralImage;

public class Loading : MonoBehaviour
{
    [SerializeField] float timeToLoad = 5f;
    [SerializeField] ProceduralImage bar;

    public float GetTimeToLoad()
    {
        return timeToLoad;
    }

    public void UpdateBar(float fillAmount)
    {
        bar.fillAmount = fillAmount;
    }
}
