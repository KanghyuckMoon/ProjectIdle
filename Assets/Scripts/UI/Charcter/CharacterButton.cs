using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CharacterButton : MonoBehaviour
{
	[SerializeField] private Button button;
	[SerializeField] private Image chImage;

	public Button GetButton()
	{
		return button;
	}

	public void SetImage(int index)
	{
		chImage.sprite = Resources.Load<Sprite>($"UI/Ch_{index}");
	}
}
