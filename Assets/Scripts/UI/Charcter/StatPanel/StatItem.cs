using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatItem : MonoBehaviour
{
	public Money SpendMoney
	{
		get
		{
			if (spendMoney == null)
			{
				spendMoney = Money.ReturnMoney(0, 50 * (ReturnStatAddLevel() + 1));
			}
			return spendMoney;
		}
		set
		{
			spendMoney = value;
		}
	}

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
		if (GameManager.Instance.PlayerMoney.CheckMoneyGreater(Enum_MoneyType.Gold, SpendMoney))
		{
			GameManager.Instance.PlayerMoney.SpendMoney(Enum_MoneyType.Gold, SpendMoney);
			AddStatLevel(1);
		}
		UpdateUpgradeButton();
	}

	public void UpdateUpgradeButton()
	{
		levelText.text = $"LV.{ReturnStatAddLevel()}(+C.{ReturnStatLevel()})";
		itemNameText.text = ReturnStatName();
		statText.text = $"{((float)ReturnStatAddLevel() / 10) + ReturnStatLevel()}"; // �ӽ�

		signMoeny.Sign(SpendMoney); // �ӽ�

		//�ӽ�
		CheckCanUpgrade();
	}
	public void CheckCanUpgrade()
	{
		if (GameManager.Instance.PlayerMoney.CheckMoneyGreater(Enum_MoneyType.Gold, SpendMoney))
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
		spendMoney = Money.ReturnMoney(0, 50 * (ReturnStatAddLevel() + 1));
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
				return "���ݷ�";
			case Enum_Stat.Hp:
				return "ü��";
			case Enum_Stat.Agi:
				return "���ݼӵ�";
			case Enum_Stat.Dex:
				return "�̵��ӵ�";
			case Enum_Stat.Cri:
				return "ġ��Ÿ ������";
			case Enum_Stat.Luk:
				return "ġ��Ÿ Ȯ��";
		}
	}
}
