using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStat
{
	public float Hp;
	public float MaxHp;
	public float Atk;
	public float Agi;
	public float Dex;
	public float Cri;
	public float Luk;
	public float AtkRange;

	public static CharacterStat CharacterDataToChStat(CharacterData characterData)
	{
		CharacterStat stat = new CharacterStat();
		stat.Hp = characterData.HP;
		stat.MaxHp = characterData.HP;
		stat.Atk = characterData.ATK;
		stat.Agi = characterData.AGI;
		stat.Dex = characterData.DEX;
		stat.Cri = characterData.CRI;
		stat.Luk = characterData.LUK;
		stat.AtkRange = characterData.AtkRange;
		return stat;
	}
}
