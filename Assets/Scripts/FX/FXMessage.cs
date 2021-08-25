using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace DD.FX
{
    public class FXMessage : MonoBehaviour
    {
        public int dungeonID = 0;
        [SerializeField] TextMeshProUGUI messageFrame;
        [SerializeField] TextMeshProUGUI message;
        [SerializeField] float timeToShow = 1f;
        float remainingTime;
        string currentText;
    

        private void Start() 
        {
            messageFrame.gameObject.SetActive(false);    
        }

        private void Update() 
        {
            if(remainingTime > 0)
            {
                messageFrame.gameObject.SetActive(true);
                messageFrame.text = currentText;
                message.text = currentText;
            }    
            else
            {
                messageFrame.gameObject.SetActive(false);
            }

            remainingTime = Mathf.Max(remainingTime - Time.deltaTime, 0f);
        }

        public void Show(string messageToUpdate, int dungeonID)
        {
            if(this.dungeonID != dungeonID) return;

            remainingTime = timeToShow;
            currentText = messageToUpdate;
        }

        public static void ShowMessage(string messageToShow, int dungeonID)
        {
            foreach(FXMessage fxMessage in FindObjectsOfType<FXMessage>())
            {
                fxMessage.Show(messageToShow, dungeonID);
            }
        }
    }
}

