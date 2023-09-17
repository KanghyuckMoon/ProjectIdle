using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillBtn : MonoBehaviour
{
	public Image coolTimeImage;
	public int index;
	public int chIndex;
	public BaseCharacter baseCharacter;
	public BaseSkill baseSkill;

	public void SetSkill()
	{
		baseCharacter = CharacterManager.Instance.playerCharacters[chIndex];
		baseSkill = baseCharacter.skilList[index];
		baseSkill.action += UpdateUI;
		UpdateUI();
	}

	public void UpdateUI()
	{
		coolTimeImage.fillAmount = baseSkill.CoolTime / baseSkill.MaxCoolTime;
	}

	public void UseSkill()
	{
		UpdateUI();
		baseSkill.UseSkill(baseCharacter);
	}

}
