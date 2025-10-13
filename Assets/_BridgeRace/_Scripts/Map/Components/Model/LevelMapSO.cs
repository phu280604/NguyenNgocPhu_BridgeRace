using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MapLevel", menuName = "Map/Level")]
public class LevelMapSO : ScriptableObject
{
    public int level;

    public List<FloorMSO> floorMSOs;
}
