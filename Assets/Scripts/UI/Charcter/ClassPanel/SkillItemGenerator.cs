using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillItemGenerator : MonoBehaviour
{
	//[SerializeField] private CharacterPanel characterPanel;
	[SerializeField] private GameObject skillItemPrefab;
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

		while(parent.childCount > 0)
		{
			// Get the first child
			Transform child = parent.GetChild(0);

			child.SetParent(null);

			// Destroy it
			Destroy(child.gameObject);
		}
		int count = characterData.skillDataList.Count;
		for (int i = 0; i < count; ++i)
		{
			var obj = Instantiate(skillItemPrefab, parent);
			var skillBtn = obj.GetComponent<SkillItem>();
			skillBtn.SetSkillData(characterData.skillDataList[i]);
		}
	}
}
