using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	[SerializeField] private List<Transform> spawnPoint;

	public void Spawn()
	{
		StageData stageData = StageManager.Instance.CurStageData;

		for(int i = 0; i < stageData.enemyDataList.Count; i++) 
		{
			EnemyData enemyData = stageData.enemyDataList[i];
			GameObject enemy = Resources.Load<GameObject>($"Enemy/{enemyData.enemyAddress}");
			for(int j =0 ; j < enemyData.count; j++)
			{
				int random = Random.Range(0, spawnPoint.Count);
				Instantiate(enemy, spawnPoint[random].position + new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), 0), Quaternion.identity);
			}
		}
	}
}
