using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AYellowpaper.SerializedCollections;

[CreateAssetMenu]
public class StatDataSO : ScriptableObject
{
	public Enum_Class enum_Class;
	public SerializedDictionary<int, StatData> statDataDic = new SerializedDictionary<int, StatData>();
}
