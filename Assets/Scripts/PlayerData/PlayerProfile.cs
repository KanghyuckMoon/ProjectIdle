using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProfile : MonoBehaviour
{
	public string nickName;
	public int level = 1;
	public int exp;

	public void AddExp(int addExp)
	{
		exp += addExp;
		level = (exp / 5) + 1;
		GameEventManager.Instance.EventRaise("ChangeExp");
	}
}
