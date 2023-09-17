using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwS_1 : BaseSkill
{
	public override void UseSkill(BaseCharacter baseCharacter)
	{
		if (!baseCharacter.IsAttack)
		{
			return;
		}
		base.UseSkill(baseCharacter);
		float damage = (baseCharacter.CharacterStat.Atk * baseCharacter.CharacterStat.Cri) / 2;
		baseCharacter.Target?.Hit(damage);
		baseCharacter.Target?.Hit(damage);
		baseCharacter.InvokeAnim("skill1");
	}
}
