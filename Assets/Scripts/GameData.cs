using System;
using System.Numerics;
using UnityEngine;

[Serializable]
public class GameData
{
    [Header("Energy")]
    public int energyLevel = 0;
    public int energyPossessed = 0;
    public int energyPerClick = 1;
    public int autoClickPerSecond = 1;

    [Header("Spirit")]
    public int spiritLevel = 0;
    public int spiritPossessed = 0;
    public int spiritSpawnedCount = 0;
    public int spiritSpawnLimitCount = 1;
    public int spritEnergyPerSecond = 1;

    [Header("Eternity Remnants")]
    public int eternityRemnantsLevel = 0;
    public int eternityRemnantsPossessed = 0;

    [Header("Celestial Tree")]
    public int celestialTreeLevel = 0;
}
