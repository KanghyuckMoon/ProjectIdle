using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utill.Pattern;

public class GameManager : MonoSingleton<GameManager>
{
	#region ������Ƽ
	public PlayerMoney PlayerMoney => playerMoney;
	public PlayerCharacter PlayerCharacter => playerCharacter;
	public PlayerProfile PlayerProfile => playerProfile;
	#endregion


	#region ����
	[SerializeField] private PlayerMoney playerMoney;
	[SerializeField] private PlayerCharacter playerCharacter;
	[SerializeField] private PlayerProfile playerProfile;
	#endregion
}
