using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatPanel : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI nickNameText;

	private void Awake()
	{
		var panel = GetComponentInParent<CharacterPanel>();
		panel.AddAction(UpdateUI);
		UpdateUI(panel.CurCharacterData);
	}

	public void UpdateUI(CharacterData characterData)
	{
		nickNameText.text = characterData.nickName;
	}
}
