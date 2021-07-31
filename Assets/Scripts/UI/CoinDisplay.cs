using UnityEngine;
using TMPro;

namespace DD.UI
{
    public class CoinDisplay : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI textShadow = null;
        [SerializeField] TextMeshProUGUI text = null;

        PlayData playData;

        private void Awake() 
        {
            playData = FindObjectOfType<PlayData>();    
        }

        private void Update() 
        {
            textShadow.text = playData.GetCurrentCoin().ToString();
            text.text = playData.GetCurrentCoin().ToString();
        }
    }
}
