using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerExpBar : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI playName;
	[SerializeField] private TextMeshProUGUI levelText;
	[SerializeField] private Image expBar;

	private void Start()
	{
		UpdateUI();
	}

	public void UpdateUI()
	{
		playName.text = GameManager.Instance.PlayerProfile.nickName;
		levelText.text = $"LV.{GameManager.Instance.PlayerProfile.level}";
		expBar.fillAmount = ((float)(GameManager.Instance.PlayerProfile.exp - (GameManager.Instance.PlayerProfile.level - 1) * 5) / 5);
	}
}
