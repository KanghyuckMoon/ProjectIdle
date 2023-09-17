using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnS_1 : BaseSkill
{
	public override void UseSkill(BaseCharacter baseCharacter)
	{
		if (baseCharacter.TargetDistance <= baseCharacter.CharacterStat.AtkRange )
		{
			return;
		}
		base.UseSkill(baseCharacter);
		baseCharacter.Target.Hit(skillData.level * 10);
		baseCharacter.InvokeAnim("skill1");
	}
}
