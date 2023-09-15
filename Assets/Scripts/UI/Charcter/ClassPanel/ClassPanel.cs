using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClassPanel : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI classNameText;
	[SerializeField] private TextMeshProUGUI levelText;
	[SerializeField] private Image expBar;

	private void Awake()
	{
		var panel = GetComponentInParent<CharacterPanel>();
		panel.AddAction(UpdateUI);
		UpdateUI(panel.CurCharacterData);
	}

	public void UpdateUI(CharacterData characterData)
	{
		classNameText.text = TextManager.Instance.GetText(characterData.enum_Class.ToString());

		levelText.text = $"LV.{characterData.level_class}";
		expBar.fillAmount = ((float)(characterData.exp - (characterData.level_class - 1) * 5) / 5);
	}
}
