using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class SkillItem : MonoBehaviour
{
	[SerializeField] private Image image;
	[SerializeField] private TextMeshProUGUI levelText;
	[SerializeField] private TextMeshProUGUI statText;
	[SerializeField] private TextMeshProUGUI itemNameText;
	[SerializeField] private SignMoney signMoeny;
	[SerializeField] private TextMeshProUGUI upgradeText;
	[SerializeField] private Button upgradeButton;
	private SkillData skillData;
	private Money spendMoney = null;

	private void Awake()
	{
		upgradeButton.AddEvent(ClickUpgrade);
	}

	public void SetSkillData(SkillData skillData)
	{
		this.skillData = skillData;
		UpdateUpgradeButton();
	}

	public void ClickUpgrade()
	{
		if (spendMoney == null)
		{
			spendMoney = Money.ReturnMoney(3, 500);
		}
		if (GameManager.Instance.PlayerMoney.CheckMoneyGreater(Enum_MoneyType.Gold, spendMoney))
		{
			//
			GameManager.Instance.PlayerMoney.SpendMoney(Enum_MoneyType.Gold, spendMoney);
			AddSkillLevel(1);
		}
		UpdateUpgradeButton();
	}

	private void AddSkillLevel(int v)
	{
		skillData.level += v;
	}

	public void UpdateUpgradeButton()
	{
		levelText.text = $"LV.{ReturnSkillLevel()}";
		itemNameText.text = TextManager.Instance.GetText(skillData.enum_Skill.ToString());
		statText.text = $"{ReturnSkillStat()}"; // 임시

		signMoeny.Sign(Money.ReturnMoney(3, 500)); // 임시

		//임시
		CheckCanUpgrade();
	}

	private object ReturnSkillLevel()
	{
		return skillData.level;
	}

	public void CheckCanUpgrade()
	{
		if (spendMoney == null)
		{
			spendMoney = Money.ReturnMoney(3, 500);
		}
		if (GameManager.Instance.PlayerMoney.CheckMoneyGreater(Enum_MoneyType.Gold, spendMoney))
		{
			upgradeText.color = Color.black;
		}
		else
		{
			upgradeText.color = Color.red;
		}
	}

	private string ReturnSkillStat()
	{
		return "스킬 설명";
	}
}
