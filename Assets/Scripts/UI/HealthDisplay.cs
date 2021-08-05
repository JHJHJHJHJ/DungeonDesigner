using UnityEngine;
using UnityEngine.UI.ProceduralImage;
using TMPro;
using DD.Combat;

namespace DD.UI
{
    public class HealthDisplay : MonoBehaviour
    {
        [SerializeField] Health health = null;
        [SerializeField] ProceduralImage bar = null;
        [SerializeField] ProceduralImage barEmpty = null;
        [SerializeField] TextMeshProUGUI healthText = null;
        [SerializeField] Color barColorGreen;
        [SerializeField] Color barEmptyColorGreen;
        [SerializeField] Color barColorRed;
        [SerializeField] Color barEmptyColorRed;

        private void Update()
        {
            UpdateBar();
        }

        void UpdateBar()
        {
            float fillAmount = health.GetHealthPoints() / health.GetMaxHealthPoints();
            bar.fillAmount = fillAmount;

            if(fillAmount <= 0.33)
            {
                bar.color = barColorRed;
                barEmpty.color = barEmptyColorRed;
            }
            else
            {
                bar.color = barColorGreen;
                barEmpty.color = barEmptyColorGreen;
            }

            healthText.text = health.GetHealthPoints() + "/" + health.GetMaxHealthPoints();
        }
    }
}
