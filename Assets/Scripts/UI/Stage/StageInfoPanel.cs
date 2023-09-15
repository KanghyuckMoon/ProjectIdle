using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StageInfoPanel : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI exText;

	public void Open(StageData stageData)
	{
		gameObject.SetActive(true);
		string str = "";
		for (int i = 0; i < stageData.enemyDataList.Count; ++i)
		{
			str += $"{stageData.enemyDataList[i].enemyAddress} {stageData.enemyDataList[i].count}마리 출현\n";
		}
		exText.text = str;
	}
}
