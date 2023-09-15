using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPanel : MonoBehaviour
{
	public CharacterData CurCharacterData
	{
		get
		{
			return GameManager.Instance.PlayerCharacter.GetCharacterData(curIndex);
		}
	}

	[SerializeField] private StatPanel statPanel;
	[SerializeField] private List<StatItem> statItems;

	private int curIndex;
	private Action<CharacterData> action;
	

	private void Awake()
	{
	}

	public void AddAction(Action<CharacterData> action)
	{
		this.action += action;
	}

	public void OpenAndClose(int index)
	{
		if(!gameObject.activeSelf)
		{
			gameObject.SetActive(true);
			curIndex = index;
			ShowCharacterInfo();
		}
		else if(curIndex != index)
		{
			curIndex = index;
			ShowCharacterInfo();
		}
		else
		{
			gameObject.SetActive(false);
		}
	}

	private void ShowCharacterInfo()
	{
		action?.Invoke(CurCharacterData);
	}
}
