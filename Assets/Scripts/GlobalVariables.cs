using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalVariables
{
    public static bool mutedAllMusic = false;
    public static bool mutedAllSFX = false;

    public static float musicVolume;
    public static float sfxVolume;

    public static bool[] unlockedLevels = new bool[25];
}
