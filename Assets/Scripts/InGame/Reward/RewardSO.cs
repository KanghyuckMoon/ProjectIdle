using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class RewardSO : ScriptableObject
{
	public Enum_MoneyType moneyType;
	public int moneyIndex;
	public int money;
	public int exp;
}
