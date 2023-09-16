using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterDataSO : ScriptableObject
{
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

	[Header("Debug")]
	public AllStatDataSO allStatDataSO;

	[ContextMenu("SetChDataSOFromAllStatDataSO")]
	public void SetChDataSOFromAllStatDataSO()
	{
		SetChDataSOFromStatDataSO(allStatDataSO.statDataSOs[enum_Class]);
	}

	public void SetChDataSOFromStatDataSO(StatDataSO statDataSO)
	{
		StatData statData = statDataSO.statDataDic[level_class];
		level_Atk = statData.atk;
		level_Hp = statData.hp;
		level_Agi = statData.agi;
		level_Dex = statData.dex;
		level_Cri = statData.cri;
		level_Luk = statData.luk;
		atkRange = statData.atkRange;
	}

	public static CharacterData ChDataSOToChData(CharacterDataSO characterDataSO)
	{
		CharacterData characterData = new CharacterData();
		characterData.nickName = characterDataSO.nickName;
		characterData.enum_Class = characterDataSO.enum_Class;
		characterData.exp = characterDataSO.exp;
		characterData.level_class = characterDataSO.level_class;
		characterData.level_Atk = characterDataSO.level_Atk;
		characterData.level_Cri = characterDataSO.level_Cri;
		characterData.level_Hp = characterDataSO.level_Hp;
		characterData.level_Dex = characterDataSO.level_Dex;
		characterData.level_Luk = characterDataSO.level_Luk;
		characterData.level_Agi = characterDataSO.level_Agi;

		characterData.addLevel_Atk = characterDataSO.addLevel_Atk;
		characterData.addLevel_Cri = characterDataSO.addLevel_Cri;
		characterData.addLevel_Hp = characterDataSO.addLevel_Hp;
		characterData.addLevel_Dex = characterDataSO.addLevel_Dex;
		characterData.addLevel_Luk = characterDataSO.addLevel_Luk;
		characterData.addLevel_Agi = characterDataSO.addLevel_Agi;

		characterData.atkRange = characterDataSO.atkRange;

		characterData.specificityDataList = new List<SpecificityData>(characterDataSO.specificityDataList);
		characterData.skillDataList = new List<SkillData>(characterDataSO.skillDataList);

		return characterData;
	}
}
