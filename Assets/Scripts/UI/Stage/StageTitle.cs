using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StageTitle : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI stageText;

	public void UpdateUI()
	{
		stageText.text = StageManager.Instance.CurStageData.stageName;
	}
}
