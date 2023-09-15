using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class StatData 
{
	public int level = 0;
	public int exp;
	public int atk;
	public int def;
	public int agi;
	public int dex;
	public int cri;
	public int luk;
	public List<Enum_Specificity> specificities;
	public List<Enum_Skill> skills;
}
