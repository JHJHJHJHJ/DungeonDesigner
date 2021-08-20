using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.ProceduralImage;
using DD.PlayData;

public class BossTimerDisplay : MonoBehaviour
{
    [SerializeField] ProceduralImage fill = null;

    Timer timer;

    private void Awake() 
    {
        timer = GetComponent<Timer>();    
    }

    private void Update() 
    {
        UpdateBossTimer();    
    }

    public void UpdateBossTimer()
    {
        float fillAmount = Mathf.Min(timer.GetTimeSinceGameStart() / timer.GetTimeToSpawnBoss(), 1f);

        fill.fillAmount = fillAmount;
    }
}
