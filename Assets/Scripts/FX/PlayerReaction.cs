using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace DD.FX
{
    public class PlayerReaction : MonoBehaviour
    {
        [Header("Chat")]
        [TextArea]
        [SerializeField] string[] winChats = null;
        [TextArea]
        [SerializeField] string[] loseChats = null;

        [SerializeField] GameObject chatBubble = null;
        [SerializeField] TextMeshProUGUI textFrame = null;
        [SerializeField] TextMeshProUGUI text = null;

        [Header("Review")]
        [SerializeField] Sprite[] reviewSprites = null;
        [SerializeField] Image review = null;

        private void Start() 
        {
            chatBubble.SetActive(false);    
        }

        public IEnumerator ChatAboutWin(float timeToShow)
        {
            string chatToShow = winChats[Random.Range(0, winChats.Length)];
            yield return StartCoroutine(ShowBubble(chatToShow, timeToShow));
        }

        public IEnumerator ChatAboutLose(float timeToShow)
        {
            string chatToShow = loseChats[Random.Range(0, winChats.Length)];
            yield return StartCoroutine(ShowBubble(chatToShow, timeToShow));
        }
 
        IEnumerator ShowBubble(string textToShow, float timeToShow)
        {
            chatBubble.SetActive(true);

            textFrame.text = textToShow;
            text.text = textToShow;

            yield return new WaitForSeconds(timeToShow);

            chatBubble.SetActive(false);
        }

        public void ShowReview(bool like)
        {
            review.gameObject.SetActive(true);

            Sprite spriteToShow = reviewSprites[0];
            if(!like) spriteToShow = reviewSprites[1];

            review.sprite = spriteToShow;
            // review.GetComponent<Animator>().SetBool("isLike", like);
        }
    }
}

