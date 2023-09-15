using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeItemGenerator : MonoBehaviour
{
	//[SerializeField] private CharacterPanel characterPanel;
	[SerializeField] private SeInfoPanel seInfoPanel;
	[SerializeField] private GameObject seItemPrefab;
	[SerializeField] private Transform parent;


	private void Awake()
	{
		var panel = GetComponentInParent<CharacterPanel>();
		panel.AddAction(UpdateUI);
		UpdateUI(panel.CurCharacterData);
	}

	public void UpdateUI(CharacterData characterData)
	{
		//nickNameText.text = characterData.nickName;

		while (parent.childCount > 0)
		{
			// Get the first child
			Transform child = parent.GetChild(0);

			child.SetParent(null);

			// Destroy it
			Destroy(child.gameObject);
		}

		int count = characterData.specificityDataList.Count;
		for (int i = 0; i < count; ++i)
		{
			var obj = Instantiate(seItemPrefab, parent);
			var seItem = obj.GetComponent<SeItem>();
			var seData = characterData.specificityDataList[i];
			seItem.SetSeData(seData);
			seItem.GetButton().AddEvent(() => seInfoPanel.SetInfo(seData));
		}
	}
}
