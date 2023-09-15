using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class SeItem : MonoBehaviour
{
	[SerializeField] private Image image;
	[SerializeField] private TextMeshProUGUI itemNameText;
	[SerializeField] private Button seButton;
	private SpecificityData specificityData;

	public Button GetButton()
	{
		return seButton;
	}

	public void SetSeData(SpecificityData specificityData)
	{
		this.specificityData = specificityData;
		UpdateUI();
	}

	public void CheckSeInfo()
	{
		//UpdateUpgradeButton();
	}

	public void UpdateUI()
	{
		itemNameText.text = TextManager.Instance.GetText(specificityData.enum_Specificity.ToString());
	}
}
