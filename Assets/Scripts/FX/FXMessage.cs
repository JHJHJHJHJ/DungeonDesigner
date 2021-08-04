using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace DD.FX
{
    public class FXMessage : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI message;
        [SerializeField] float timeToShow = 1f;
        float remainingTime;
        string currentText;
    

        private void Start() 
        {
            message.gameObject.SetActive(false);    
        }

        private void Update() 
        {
            if(remainingTime > 0)
            {
                message.gameObject.SetActive(true);
                message.text = currentText;
            }    
            else
            {
                message.gameObject.SetActive(false);
            }

            remainingTime = Mathf.Max(remainingTime - Time.deltaTime, 0f);
        }

        public void Show(string messageToUpdate)
        {
            remainingTime = timeToShow;
            currentText = messageToUpdate;
        }
    }
}

