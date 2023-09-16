using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData
{
	public int ATK
	{
		get
		{
			return level_Atk + addLevel_Atk;
		}
	}
	public int HP
	{
		get
		{
			return level_Hp + addLevel_Hp;
		}
	}
	public int AGI
	{
		get
		{
			return level_Agi + addLevel_Agi;
		}
	}
	public int DEX
	{
		get
		{
			return level_Dex + addLevel_Dex;
		}
	}
	public int CRI
	{
		get
		{
			return level_Cri + addLevel_Cri;
		}
	}
	public int LUK
	{
		get
		{
			return level_Luk + addLevel_Luk;
		}
	}

	public int AtkRange
	{
		get
		{
			return atkRange;
		}
	}

	public string nickName;
	public Enum_Class enum_Class;
	public int exp;
	public int level_class;
	public int level_Atk;
	public int level_Hp;
	public int level_Agi;
	public int level_Dex;
	public int level_Cri;
	public int level_Luk;
	public int atkRange;

	public int addLevel_Atk;
	public int addLevel_Hp;
	public int addLevel_Agi;
	public int addLevel_Dex;
	public int addLevel_Cri;
	public int addLevel_Luk;

	public List<SpecificityData> specificityDataList = new List<SpecificityData>();
	public List<SkillData> skillDataList = new List<SkillData>();

	public void AddExp(int addExp)
	{
		exp += addExp;
		level_class = (exp / 5) + 1;
		//GameEventManager.Instance.EventRaise("ChangeExp");
	}
}
