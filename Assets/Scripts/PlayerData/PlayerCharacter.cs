using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
	public int CharacterCount
	{
		get
		{
			return characterDataList.Count;
		}
	}

	[SerializeField] private List<CharacterDataSO> characterDataSOList = new List<CharacterDataSO>();
	private List<CharacterData> characterDataList;

	private void Awake()
	{
		characterDataList = new List<CharacterData>();
		foreach (var obj in characterDataSOList)
		{
			characterDataList.Add(CharacterDataSO.ChDataSOToChData(obj));
		}
	}

	public CharacterData GetCharacterData(int index)
	{
		return characterDataList[index];
	}
}
