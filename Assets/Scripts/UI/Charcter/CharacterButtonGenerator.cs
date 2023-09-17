using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.Rendering;
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
			int index = i;
			var obj = Instantiate(characterButtonPrefab, parent);
			var chBtn = obj.GetComponent<CharacterButton>();
			var btn = chBtn.GetButton();
			chBtn.SetImage(index);
			btn.AddEvent(characterPanel.OpenAndClose, index);
		}
	}
}
