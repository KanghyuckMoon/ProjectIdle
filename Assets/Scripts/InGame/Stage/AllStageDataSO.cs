using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AllStageDataSO : ScriptableObject
{
	public List<StageData> stageDataList = new List<StageData>();
}
