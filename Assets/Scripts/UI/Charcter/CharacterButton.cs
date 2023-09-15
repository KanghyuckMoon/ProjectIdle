using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CharacterButton : MonoBehaviour
{
	[SerializeField] private Button button;

	public Button GetButton()
	{
		return button;
	}
}
