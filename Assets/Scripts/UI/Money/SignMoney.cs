using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SignMoney : MonoBehaviour
{
	[SerializeField] private Enum_MoneyType goodsType;

	[SerializeField] private TextMeshProUGUI text;
	[SerializeField] private Image image;

	public void Sign(Money money)
	{
		text.text = money.GetMoney();

	}
}
