using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickMove : MonoBehaviour
{
	[SerializeField] VariableJoystick joystickJoystick;
	private bool isJoyStickMove;

	private void Update()
	{
		MoveCharacters();
	}

	public void MoveCharacters()
	{
		if(joystickJoystick.Direction != Vector2.zero)
		{
			for (int i = 0; i < CharacterManager.Instance.playerCharacters.Count; ++i)
			{
				CharacterManager.Instance.playerCharacters[i].JoyStickMove(joystickJoystick.Direction);
			}
			isJoyStickMove = true;
		}
		else if(isJoyStickMove)
		{
			for (int i = 0; i < CharacterManager.Instance.playerCharacters.Count; ++i)
			{
				CharacterManager.Instance.playerCharacters[i].JoyStickMoveEnd();
			}
			isJoyStickMove = false;
		}
	}
}
