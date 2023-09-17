using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Utill.Pattern;
public class CharacterManager : MonoSingleton<CharacterManager>
{
	public List<BaseCharacter> playerCharacters = new List<BaseCharacter>();
	public List<BaseCharacter> enemyCharacters = new List<BaseCharacter>();
	public List<Transform> playerSpawnPoint = new List<Transform>();

	public void CheckStageClear()
	{
		for(int i = 0; i < enemyCharacters.Count; i++) 
		{
			if (!enemyCharacters[i].IsDead)
			{
				return;
			}
		}
		ClearStage();
	}

	public void CheckStageFailed()
	{
		for (int i = 0; i < playerCharacters.Count; i++)
		{
			if (!playerCharacters[i].IsDead)
			{
				return;
			}
		}
		ResetStage();
	}

	public void ClearStage()
	{
		ChangeStage();
		GameEventManager.Instance.EventRaise("ClearStage");
	}
	public void ResetStage()
	{
		ChangeStage();
		GameEventManager.Instance.EventRaise("ResetStage");
	}

	public void ChangeStage()
	{
		for (int i = 0; i < playerCharacters.Count; i++)
		{
			int index = i;
			playerCharacters[index].transform.position = playerSpawnPoint[index].position;
			playerCharacters[index].ResetStat();
			playerCharacters[index].gameObject.SetActive(true);
		}
		for (int i = 0; i < enemyCharacters.Count; i++)
		{
			int index = i;
			Destroy(enemyCharacters[index].gameObject);
		}
		enemyCharacters.Clear();
	}
}
