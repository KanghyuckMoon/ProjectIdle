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
	public int level_Def;
	public int level_Agi;
	public int level_Dex;
	public int level_Cri;
	public int level_Luk;

	public List<SpecificityData> specificityDataList = new List<SpecificityData>();
	public List<SkillData> skillDataList = new List<SkillData>();

	public static CharacterData ChDataSOToChData(CharacterDataSO characterDataSO)
	{
		CharacterData characterData = new CharacterData();
		characterData.nickName = characterDataSO.nickName;
		characterData.enum_Class = characterDataSO.enum_Class;
		characterData.exp = characterDataSO.exp;
		characterData.level_class = characterDataSO.level_class;
		characterData.level_Atk = characterDataSO.level_Atk;
		characterData.level_Cri = characterDataSO.level_Cri;
		characterData.level_Def = characterDataSO.level_Def;
		characterData.level_Dex = characterDataSO.level_Dex;
		characterData.level_Luk = characterDataSO.level_Luk;
		characterData.level_Agi = characterDataSO.level_Agi;
		characterData.specificityDataList = new List<SpecificityData>(characterDataSO.specificityDataList);
		characterData.skillDataList = new List<SkillData>(characterDataSO.skillDataList);

		return characterData;
	}
}
