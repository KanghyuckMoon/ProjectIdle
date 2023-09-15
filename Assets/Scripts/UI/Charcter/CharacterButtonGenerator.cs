using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterButtonGenerator : MonoBehaviour
{
	[SerializeField] private CharacterPanel characterPanel;
	[SerializeField] private GameObject characterButtonPrefab;
	[SerializeField] private Transform parent;

	private void Start()
	{
		int count = GameManager.Instance.PlayerCharacter.CharacterCount;
		for (int i = 0; i < count; ++i)
		{
			var obj = Instantiate(characterButtonPrefab, parent);
			var chBtn = obj.GetComponent<CharacterButton>();
			var btn = chBtn.GetButton();
			btn.AddEvent(characterPanel.OpenAndClose, i);
		}
	}
}
