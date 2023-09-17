using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaS_1 : BaseSkill
{
	public override void UseSkill(BaseCharacter baseCharacter)
	{
		if(!baseCharacter.IsAttack)
		{
			return;
		}
		base.UseSkill(baseCharacter);
		List<BaseCharacter> list = null;
		if (baseCharacter.IsPlayer)
		{
			list = baseCharacter.FindClosestInRange(CharacterManager.Instance.enemyCharacters);
		}
		else
		{
			list = baseCharacter.FindClosestInRange(CharacterManager.Instance.playerCharacters);
		}

		if(list != null)
		{
			for (int i = 0; i < list.Count; ++i)
			{
				list[i].Hit(baseCharacter.CalcDamage() * (skillData.level + 1));
			}
		}
		baseCharacter.InvokeAnim("skill1");
	}
}
