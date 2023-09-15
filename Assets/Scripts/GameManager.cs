using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utill.Pattern;

public class GameManager : MonoSingleton<GameManager>
{
	#region 프로퍼티
	public PlayerMoney PlayerMoney => playerMoney;
	public PlayerCharacter PlayerCharacter => playerCharacter;
	public PlayerProfile PlayerProfile => playerProfile;
	#endregion


	#region 변수
	[SerializeField] private PlayerMoney playerMoney;
	[SerializeField] private PlayerCharacter playerCharacter;
	[SerializeField] private PlayerProfile playerProfile;
	#endregion
}
