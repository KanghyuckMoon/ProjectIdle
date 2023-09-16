using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStat
{
	public int Hp;
	public int MaxHp;
	public int Atk;
	public int Agi;
	public int Dex;
	public int Cri;
	public int Luk;
	public int AtkRange;

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
