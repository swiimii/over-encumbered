﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState
{
    public static float bestTime;

    public static float mostRecentScore;

    public static void LogTime(float time)
    {
        mostRecentScore = time;
        if (mostRecentScore < bestTime)
        {
            bestTime = mostRecentScore;
        }
    }
}
