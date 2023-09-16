using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatItem : MonoBehaviour
{
	[SerializeField] private Image image;
	[SerializeField] private Enum_Stat enum_Stat;
	[SerializeField] private TextMeshProUGUI levelText;
	[SerializeField] private TextMeshProUGUI statText;
	[SerializeField] private TextMeshProUGUI itemNameText;
	[SerializeField] private SignMoney signMoeny;
	[SerializeField] private TextMeshProUGUI upgradeText;
	[SerializeField] private Button upgradeButton;
	private CharacterData characterData;
	private Money spendMoney = null;

	private void Awake()
	{
		var panel = GetComponentInParent<CharacterPanel>();
		panel.AddAction(SetCharacter);
		SetCharacter(panel.CurCharacterData);
		upgradeButton.AddEvent(ClickUpgrade);
	}

	public void SetCharacter(CharacterData characterData)
	{
		this.characterData = characterData;
		UpdateUpgradeButton();
	}

	public void ClickUpgrade()
	{
		if(spendMoney == null)
		{
			spendMoney = Money.ReturnMoney(3, 500);
		}
		if (GameManager.Instance.PlayerMoney.CheckMoneyGreater(Enum_MoneyType.Gold, spendMoney))
		{
			//
			GameManager.Instance.PlayerMoney.SpendMoney(Enum_MoneyType.Gold, spendMoney);
			AddStatLevel(1);
		}
		UpdateUpgradeButton();
	}

	public void UpdateUpgradeButton()
	{
		levelText.text = $"LV.{ReturnStatAddLevel()}(+{ReturnStatLevel()})";
		itemNameText.text = ReturnStatName();
		statText.text = $"{ReturnStatAddLevel() + ReturnStatLevel()}"; // 임시

		signMoeny.Sign(Money.ReturnMoney(3, 500)); // 임시

		//임시
		CheckCanUpgrade();
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

	private void AddStatLevel(int add)
	{
		switch (enum_Stat)
		{
			default:
			case Enum_Stat.Atk:
				characterData.addLevel_Atk += add;
				break;
			case Enum_Stat.Hp:
				characterData.addLevel_Hp += add;
				break;
			case Enum_Stat.Agi:
				characterData.addLevel_Agi += add;
				break;
			case Enum_Stat.Dex:
				characterData.addLevel_Dex += add;
				break;
			case Enum_Stat.Cri:
				characterData.addLevel_Cri += add;
				break;
			case Enum_Stat.Luk:
				characterData.addLevel_Luk += add;
				break;
		}
	}

	private int ReturnStatLevel()
	{
		switch (enum_Stat)
		{
			default:
			case Enum_Stat.Atk:
				return characterData.level_Atk;
			case Enum_Stat.Hp:
				return characterData.level_Hp;
			case Enum_Stat.Agi:
				return characterData.level_Agi;
			case Enum_Stat.Dex:
				return characterData.level_Dex;
			case Enum_Stat.Cri:
				return characterData.level_Cri;
			case Enum_Stat.Luk:
				return characterData.level_Luk;
		}
	}
	private int ReturnStatAddLevel()
	{
		switch (enum_Stat)
		{
			default:
			case Enum_Stat.Atk:
				return characterData.addLevel_Atk;
			case Enum_Stat.Hp:
				return characterData.addLevel_Hp;
			case Enum_Stat.Agi:
				return characterData.addLevel_Agi;
			case Enum_Stat.Dex:
				return characterData.addLevel_Dex;
			case Enum_Stat.Cri:
				return characterData.addLevel_Cri;
			case Enum_Stat.Luk:
				return characterData.addLevel_Luk;
		}
	}

	private string ReturnStatName()
	{
		switch (enum_Stat)
		{
			default:
			case Enum_Stat.Atk:
				return "공격력";
			case Enum_Stat.Hp:
				return "체력";
			case Enum_Stat.Agi:
				return "공격속도";
			case Enum_Stat.Dex:
				return "이동속도";
			case Enum_Stat.Cri:
				return "치명타 데미지";
			case Enum_Stat.Luk:
				return "치명타 확률";
		}
	}
}
