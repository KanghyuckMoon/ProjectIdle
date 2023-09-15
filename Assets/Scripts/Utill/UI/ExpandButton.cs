using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public static class ExpandButton
{
	public static void AddEvent(this Button button, UnityAction unityAction)
	{
		button.onClick.AddListener(unityAction);
	}
	public static void AddEvent(this Button button, UnityAction<int> unityAction, int index)
	{
		button.onClick.AddListener(() => unityAction(index));
	}
	public static void AddEvent(this Button button, UnityAction<string> unityAction, string str)
	{
		button.onClick.AddListener(() => unityAction(str));
	}
	public static void AddEvent(this Button button, UnityAction<float> unityAction, float f)
	{
		button.onClick.AddListener(() => unityAction(f));
	}
	public static void AddEvent(this Button button, UnityAction<double> unityAction, double du)
	{
		button.onClick.AddListener(() => unityAction(du));
	}
	public static void AddEvent(this Button button, UnityAction<Money> unityAction, Money money)
	{
		button.onClick.AddListener(() => unityAction(money));
	}
}
