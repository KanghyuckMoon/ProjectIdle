using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AYellowpaper.SerializedCollections;

[CreateAssetMenu]
public class ClassExplanationSO : ScriptableObject
{
	public SerializedDictionary<string, string> textKeys;

	public string GetText(string key)
	{
		return TextManager.Instance.GetText(textKeys[key]);
	}
}
