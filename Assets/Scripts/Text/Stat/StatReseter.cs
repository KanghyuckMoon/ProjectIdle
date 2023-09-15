using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.Networking;
using Utill.Pattern;

public class StatReseter : MonoBehaviour
{
	public AllStatDataSO AllStatDataSO
	{
		get
		{
			if (!isInit)
			{
				//textSO.InitTextDatas();
				//allStatDataSO

				//추후 언어에 따라 다르게 설정
				StartCoroutine(SetStats());
			}
			return allStatDataSO;
		}
	}
	public bool IsInit => isInit;

	[SerializeField]
	private AllStatDataSO allStatDataSO = null;

	[SerializeField]
	private bool isReset = false;

	private bool isInit = false;

	public void Start()
	{
		if (!isReset)
		{
			isInit = true;
			return;
		}

		if (!isInit)
		{
			InitStatData();
		}
	}

	[ContextMenu("InitStatData")]
	public void InitStatData()
	{
		//stat.InitTextDatas();
		//추후 언어에 따라 다르게 설정
		StartCoroutine(SetStats());
	}

	/// <summary>
	/// 키를 통해 텍스트를 가져옴
	/// </summary>
	/// <param name="key"></param>
	/// <returns></returns>
	public StatDataSO GetStatDataSO(Enum_Class cl)
	{
		return allStatDataSO.statDataSOs[cl];
	}

	private IEnumerator SetStats()
	{
		foreach(var statDataSO in allStatDataSO.statDataSOs)
		{
			yield return StartCoroutine(SetStat(statDataSO.Value));
		}
		isInit = true;
	}

	private IEnumerator SetStat(StatDataSO statDataSO)
	{
		string url = "";
		switch (statDataSO.enum_Class)
		{
			default:
			case Enum_Class.Captain:
				url = URL.CAPTAIN;
				break;
			case Enum_Class.SwordMan:
				url = URL.SWORDMAN;
				break;
			case Enum_Class.Chef:
				url = URL.CHEF;
				break;
			case Enum_Class.Sniper:
				url = URL.SNIPER;
				break;
		}
		UnityWebRequest www = UnityWebRequest.Get(URL.CAPTAIN);
		yield return www.SendWebRequest();
		SetStatDataSO(statDataSO, www.downloadHandler.text);
	}

	private void SetStatDataSO(StatDataSO statDataSO, string tsv)
	{
		statDataSO.statDataDic.Clear();

		string[] col = tsv.Split('\t');
		string[] row = tsv.Split('\n');
		int colSize = col.Length;
		int rowSize = row.Length;

		for (int i = 1; i <= rowSize; i++)
		{
			//string[] rowV = col[i].Split('\n');
			StatData statData = new StatData();
			statData.level = int.Parse(col[i].Split('\n')[0]); //Level
			statData.exp = int.Parse(col[i+ rowSize * 1].Split('\n')[0]); //Exp
			statData.atk = int.Parse(col[i+ rowSize * 2].Split('\n')[0]); //Atk
			statData.def = int.Parse(col[i+ rowSize * 3].Split('\n')[0]); //Def
			statData.agi = int.Parse(col[i+ rowSize * 4].Split('\n')[0]); //Agi
			statData.dex = int.Parse(col[i+ rowSize * 5].Split('\n')[0]); //Dex
			statData.cri = int.Parse(col[i+ rowSize * 6].Split('\n')[0]); //Cri
			statData.luk = int.Parse(col[i + rowSize * 7].Split('\n')[0]); //Luk

			List<Enum_Specificity> enum_Specificities = new List<Enum_Specificity>();

			//Specificity
			var spec = col[i + rowSize * 8].Split('\n')[0].Split(',');
			for(int j = 0; j < spec.Length; ++j)
			{
				enum_Specificities.Add((Enum_Specificity)Enum.Parse(typeof(Enum_Specificity), spec[j]));
			}

			List<Enum_Skill> enum_Skills = new List<Enum_Skill>();

			//SKills
			var skill = col[i + rowSize * 9].Split('\n')[0].Split(',');
			for (int j = 0; j < skill.Length; ++j)
			{
				enum_Skills.Add((Enum_Skill)Enum.Parse(typeof(Enum_Skill), skill[j]));
			}
			statDataSO.statDataDic.Add(statData.level, statData);
		}

#if UNITY_EDITOR
		UnityEditor.EditorUtility.SetDirty(statDataSO);
#endif
	}
}