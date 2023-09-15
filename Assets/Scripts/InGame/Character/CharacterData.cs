using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData
{
	public string nickName;
	public Enum_Class enum_Class;
	public int exp;
	public int level_class;
	public int level_Atk;
	public int level_Def;
	public int level_Agi;
	public int level_Dex;
	public int level_Cri;
	public int level_Luk;

	public List<SpecificityData> specificityDataList = new List<SpecificityData>();
	public List<SkillData> skillDataList = new List<SkillData>();

	public void AddExp(int addExp)
	{
		exp += addExp;
		level_class = (exp / 5) + 1;
		//GameEventManager.Instance.EventRaise("ChangeExp");
	}
}
