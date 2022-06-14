using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerStats
{
    public float life;
    
    public PlayerStats(PlayerStats dates)
    {
        life = dates.life;
    }
}
