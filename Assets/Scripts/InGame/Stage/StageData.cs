using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class StageData
{
	public string stageName;
	public List<EnemyData> enemyDataList = new List<EnemyData>();
}
