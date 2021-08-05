using UnityEngine;
using TMPro;
using DD.PlayData;

namespace DD.UI
{
    public class CoinDisplay : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI textShadow = null;
        [SerializeField] TextMeshProUGUI text = null;

        Resource playData;

        private void Awake() 
        {
            playData = FindObjectOfType<Resource>();    
        }

        private void Update() 
        {
            textShadow.text = playData.GetCurrentCoin().ToString();
            text.text = playData.GetCurrentCoin().ToString();
        }
    }
}
