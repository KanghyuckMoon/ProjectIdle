using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AYellowpaper.SerializedCollections;

[CreateAssetMenu(fileName = "TextSO", menuName = "SO/TextSO")]
public class TextSO : ScriptableObject
{
	[SerializeField]
	private SerializedDictionary<string, string> textDataDic = new SerializedDictionary<string, string>();

	[ContextMenu("DebugAllTexts")]
	public void DebugAllTexts()
	{
		foreach (var txt in textDataDic)
		{
			Debug.Log($"KEY : {txt.Key}, VALUE : {txt.Value}");
		}
	}

	public void InitTextDatas()
	{
		textDataDic.Clear();
	}

	public void AddTextData(string key, string value)
	{
		if (string.IsNullOrEmpty(key))
		{
			return;
		}
		if (textDataDic.ContainsKey(key))
		{
			Debug.LogError($"{key} 키가 이미 포함되어 있음.");
			return;
		}
		textDataDic.Add(key, value);
	}

	public string GetText(string key)
	{
		if (textDataDic.TryGetValue(key, out string value))
		{
			return value;
		}
		Debug.LogWarning("Null Text Data");
		return null;
	}
}