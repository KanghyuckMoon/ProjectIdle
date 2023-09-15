using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
	public Money gold;
	public Money crystal;

	public void Start()
	{
		gold = new Money();
		crystal = new Money();
		GameEventManager.Instance.EventRaise("ChangeMoney");
	}

	public bool CheckMoneyGreater(Enum_MoneyType goodsType, Money money)
	{
		switch (goodsType)
		{
			case Enum_MoneyType.Gold:
				if(gold.Index > money.Index || (gold.Index == money.Index && gold.getmoney() >= money.getmoney()))
				{
					return true;
				}
				return false;
			case Enum_MoneyType.Crystal:
				if (crystal.Index > money.Index || (crystal.Index == money.Index && crystal.getmoney() >= money.getmoney()))
				{
					return true;
				}
				return false;
			default:
				return false;
		}
	}

	public void EarnMoney(Enum_MoneyType goodsType, Money money)
	{
		switch (goodsType)
		{
			case Enum_MoneyType.Gold:
				gold.EarnMoney(money);
				break;
			case Enum_MoneyType.Crystal:
				crystal.EarnMoney(money);
				break;
			default:
				break;
		}
		GameEventManager.Instance.EventRaise("ChangeMoney");
	}

	public void SpendMoney(Enum_MoneyType goodsType, Money money)
	{
		switch (goodsType)
		{
			case Enum_MoneyType.Gold:
				gold.SpendMoney(money);
				break;
			case Enum_MoneyType.Crystal:
				crystal.SpendMoney(money);
				break;
			default:
				break;
		}
		GameEventManager.Instance.EventRaise("ChangeMoney");
	}
}
