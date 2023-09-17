using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChS_1 : BaseSkill
{
	public override void UseSkill(BaseCharacter baseCharacter)
	{
		base.UseSkill(baseCharacter);
		List<BaseCharacter> list = null;
		if (baseCharacter.IsPlayer)
		{
			list = CharacterManager.Instance.playerCharacters;
		}
		else
		{
			list = CharacterManager.Instance.enemyCharacters;
		}

		for (int i = 0; i < list.Count; ++i)
		{
			list[i].Hilling(skillData.level * 10);
		}
		baseCharacter.InvokeAnim("skill1");
	}
}
