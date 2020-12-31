using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SetScoreDisplays : MonoBehaviour
{
    public Text yourTime, bestTime;

    private void Start() 
    {
        yourTime.text = FormatTime(GameState.mostRecentScore);
        bestTime.text = FormatTime(GameState.bestTime);
    }

    private string FormatTime(float time)
    {
        return string.Format("{0:0}:{1:00.00}", (int)(time/60), time%60);
    }
}
