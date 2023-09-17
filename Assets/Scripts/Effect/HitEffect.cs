using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
	static List<GameObject> hitEffects = new List<GameObject>();
	static GameObject hitEffectPrefab;

	public static void SetHitEffect(Vector3 pos)
	{
		for(int i = 0; i < hitEffects.Count; ++i)
		{
			if(!hitEffects[i].activeSelf)
			{
				hitEffects[i].transform.position = pos;
				hitEffects[i].SetActive(true);
				return;
			}
		}
		InstanceHitEffect(pos);
	}

	public static void InstanceHitEffect(Vector3 pos)
	{
		hitEffectPrefab ??= Resources.Load<GameObject>("HitEffect");
		hitEffects.Add(Instantiate(hitEffectPrefab, pos, Quaternion.identity));
	}
}
