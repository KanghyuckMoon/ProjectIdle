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
		string str = null;
		switch (skillData.enum_Skill)
		{
			case Enum_Skill.None:
				break;
			case Enum_Skill.Onigiri:
				break;
			case Enum_Skill.CaS_1:
				str = "범위 내 적을 모두 공격합니다.";
				break;
			case Enum_Skill.CaS_2:
				break;
			case Enum_Skill.SwS_1:
				str = "적을 두번 치명타 공격합니다.";
				break;
			case Enum_Skill.SwS_2:
				break;
			case Enum_Skill.ChS_1:
				str = "아군의 체력을 스킬 레벨에 비례해 회복합니다.";
				break;
			case Enum_Skill.ChS_2:
				break;
			case Enum_Skill.SnS_1:
				str = "먼 거리의 적도 공격합니다.";
				break;
			case Enum_Skill.SnS_2:
				break;
			default:
				break;
		}
		return str;
	}
}
