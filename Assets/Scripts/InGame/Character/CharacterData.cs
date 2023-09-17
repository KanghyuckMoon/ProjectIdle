using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData
{
	public float ATK
	{
		get
		{
			return level_Atk + ((float)addLevel_Atk / 10);
		}
	}
	public float HP
	{
		get
		{
			return level_Hp + ((float)addLevel_Hp / 10);
		}
	}
	public float AGI
	{
		get
		{
			return level_Agi + ((float)addLevel_Agi / 10);
		}
	}
	public float DEX
	{
		get
		{
			return level_Dex + ((float)addLevel_Dex / 10);
		}
	}
	public float CRI
	{
		get
		{
			return level_Cri + ((float)addLevel_Cri / 10);
		}
	}
	public float LUK
	{
		get
		{
			return level_Luk + ((float)addLevel_Luk / 10);
		}
	}

	public float AtkRange
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
