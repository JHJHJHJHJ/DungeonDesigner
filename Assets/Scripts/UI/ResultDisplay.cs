using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultDisplay : MonoBehaviour
{
    [SerializeField] Image[] icons = null;

    [Header("Sprite")]
    [SerializeField] Sprite like = null;
    [SerializeField] Sprite dislike = null;

    int index = 0;

    private void Start()
    {
        Initialize();
    }

    void Initialize()
    {
        index = 0;
        foreach (Image icon in icons)
        {
            icon.gameObject.SetActive(false);
        }
    }

    public void UpdateResultDisplay(GameObject deadObject) // Event Listner에서 실행
    {   
        if(index >= icons.Length)
        {
            print("result index 초과");
            return;
        }

        icons[index].gameObject.SetActive(true);

        if(deadObject.CompareTag("Boss")) // Win
        {
            icons[index].sprite = like;
        }
        else // Lose
        {
            icons[index].sprite = dislike;
        }

        index++;
    }
}
