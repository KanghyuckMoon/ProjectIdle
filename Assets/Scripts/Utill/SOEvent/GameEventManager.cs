using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utill.Pattern;

public class GameEventManager : MonoSingleton<GameEventManager>
{
	public AllGameEvent allGameEvent;
	public Dictionary<string, GameEvent> gameEventDic = new Dictionary<string, GameEvent>();
	private bool isInit = false;

	public AllGameEvent AllGameEvent
	{
		get
		{
			if (allGameEvent == null)
			{
				allGameEvent = Resources.Load<AllGameEvent>("AllGameEventAll"); //AddressablesManager.Instance.GetResource<AllGameEvent>("AllGameEventAll");
			}

			return allGameEvent; 
		}
	}
	private void Init()
	{
		foreach(var gameEvent in AllGameEvent.gameEventList)
		{
			gameEventDic.Add(gameEvent.name, gameEvent);
		}
		isInit = true;
	}

	public GameEvent GetGameEvent(string key)
	{
		if(!isInit)
		{
			Init();
		}
		return gameEventDic[key];
	}

	public void EventRaise(string key)
	{
		if (!isInit)
		{
			Init();
		}
		gameEventDic[key].Raise();
	}
}
