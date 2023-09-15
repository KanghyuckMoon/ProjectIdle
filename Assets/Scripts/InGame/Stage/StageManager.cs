using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.Networking;
using Utill.Pattern;

public class StageManager : MonoSingleton<StageManager>
{
	public StageData CurStageData => curStageData;
	public AllStageDataSO AllStageDataSO => allStageDataSO;
	[SerializeField] private AllStageDataSO allStageDataSO;

	private StageData curStageData;

	public void EnterStage(StageData stageData)
	{
		curStageData = stageData;
		GameEventManager.Instance.EventRaise("ChangeStage");
	}

	[ContextMenu("InitStageData")]
	public void InitStageData()
	{
		allStageDataSO.stageDataList.Clear();
		StartCoroutine(GetStage());
	}
	private IEnumerator GetStage()
	{
		UnityWebRequest wwwStage = UnityWebRequest.Get(URL.STAGE);
		yield return wwwStage.SendWebRequest();
		SetStage(wwwStage.downloadHandler.text);

#if UNITY_EDITOR
		UnityEditor.EditorUtility.SetDirty(allStageDataSO);
#endif
	}

	private void SetStage(string tsv)
	{
		Debug.Log(tsv);
		string[] row = tsv.Split('\n');
		int rowSize = row.Length;

		for (int i = 0; i < rowSize; i++)
		{
			string[] column = row[i].Split('\t');
			StageData stageData = new StageData();
			stageData.stageName = column[0];
			string[] enemyNameList = column[1].Split(',');
			string[] enemyCountList = column[2].Split(',');
			List<EnemyData> enemyDataList = new List<EnemyData>();
			for(int j = 0; j < enemyNameList.Length; ++j)
			{
				int index = j;
				EnemyData enemyData = new EnemyData();
				enemyData.enemyAddress = enemyNameList[index];
				enemyData.count = int.Parse(enemyCountList[index]);
				enemyDataList.Add(enemyData);
			}

			stageData.enemyDataList = enemyDataList;
			allStageDataSO.stageDataList.Add(stageData);
		}
	}
}
