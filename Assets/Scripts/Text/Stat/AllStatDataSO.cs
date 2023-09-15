using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AYellowpaper.SerializedCollections;

[CreateAssetMenu]
public class AllStatDataSO : ScriptableObject
{
	public SerializedDictionary<Enum_Class, StatDataSO> statDataSOs = new SerializedDictionary<Enum_Class, StatDataSO>();
}
