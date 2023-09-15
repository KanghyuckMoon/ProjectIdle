using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPlayerMoney : MonoBehaviour
{
	[SerializeField] private SignMoney signCoin;
	[SerializeField] private SignMoney signCrystal;

	public void UpdateSignMoney()
	{
		signCoin.Sign(GameManager.Instance.PlayerMoney.gold);
		signCrystal.Sign(GameManager.Instance.PlayerMoney.crystal);
	}
}
