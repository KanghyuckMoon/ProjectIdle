using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SeInfoPanel : MonoBehaviour
{
	[SerializeField] private SeItem seItem;
	[SerializeField] private TextMeshProUGUI gradeText;
	[SerializeField] private TextMeshProUGUI exText;

	public void SetInfo(SpecificityData specificityData)
	{
		seItem.SetSeData(specificityData);
		gradeText.text = TextManager.Instance.GetText(specificityData.enum_Grade.ToString());
		exText.text = TextManager.Instance.GetText(specificityData.enum_Specificity.ToString() + "_Ex");
		gameObject.SetActive(true);
	}
}
