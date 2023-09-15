using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utill.Pattern;
public class CharacterManager : MonoSingleton<CharacterManager>
{
	public List<BaseCharacter> baseCharacters = new List<BaseCharacter>();
}
