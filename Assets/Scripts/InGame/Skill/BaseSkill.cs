using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSkill
{
	public float CoolTime
	{
		get
		{
			return coolTime;
		}
		set
		{
			coolTime = value;
		}
	}
	public float MaxCoolTime
	{
		get
		{
			return maxCoolTime;
		}
		set
		{
			maxCoolTime = value;
		}
	}

	public bool IsUseSkill
	{
		get
		{
			if (coolTime <= 0f)
			{
				return true;
			}
			else
			{
				coolTime -= Time.deltaTime;
			}
			action?.Invoke();
			return false;
		}
	}

	public SkillData skillData;
	public float coolTime;
	public float maxCoolTime = 2f;
	public System.Action action;

	public virtual void UseSkill(BaseCharacter baseCharacter)
	{
		coolTime = maxCoolTime;
		action?.Invoke();
		Debug.Log($"Use Skill {skillData.enum_Skill}");
	}

	public static BaseSkill ReturnSkill(SkillData skillData)
	{
		BaseSkill baseSkill = null;

		switch (skillData.enum_Skill)
		{
			case Enum_Skill.None:
			case Enum_Skill.Onigiri:
				break;
			case Enum_Skill.CaS_1:
				baseSkill = new CaS_1();
				break;
			case Enum_Skill.CaS_2:
				baseSkill = new CaS_2();
				break;
			case Enum_Skill.SwS_1:
				baseSkill = new SwS_1();
				break;
			case Enum_Skill.SwS_2:
				baseSkill = new SwS_2();
				break;
			case Enum_Skill.ChS_1:
				baseSkill = new ChS_1();
				break;
			case Enum_Skill.ChS_2:
				baseSkill = new ChS_2();
				break;
			case Enum_Skill.SnS_1:
				baseSkill = new SnS_1();
				break;
			case Enum_Skill.SnS_2:
				baseSkill = new SnS_2();
				break;
			default:
				break;
		}
		baseSkill.skillData = skillData;
		return baseSkill;
	}

}
