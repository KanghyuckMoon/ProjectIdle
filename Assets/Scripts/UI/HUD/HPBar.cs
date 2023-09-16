using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
	[SerializeField] private BaseCharacter baseCharacter;
	[SerializeField] private Image hpImage;

	public void Start()
	{
		baseCharacter.UiUpdateAction += UpdateUI;
	}
	public void UpdateUI()
	{
		//Debug.Log($"UI 업데이트 {amount}");
		float amount = baseCharacter.HpAmount;
		hpImage.fillAmount = amount;
	}
}
