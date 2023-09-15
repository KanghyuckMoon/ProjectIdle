using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StageButton : MonoBehaviour
{
	[SerializeField] private Button enterButton;
	[SerializeField] private Button infoButton;
	[SerializeField] private TextMeshProUGUI stageNameText;
	private StageData stageData;

	public void SetStageData(StageData stageData)
	{
		this.stageData = stageData;
		UpdateUI();
	}

	public Button GetEnterButton()
	{
		return enterButton;
	}
	
	public Button GetInfoButton()
	{
		return infoButton;
	}

	public void UpdateUI()
	{
		stageNameText.text = stageData.stageName;
	}
}
