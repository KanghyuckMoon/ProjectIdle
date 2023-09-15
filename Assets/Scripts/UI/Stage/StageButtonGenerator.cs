using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageButtonGenerator : MonoBehaviour
{
	[SerializeField] private StageSelectPanel stageSelectPanel;
	[SerializeField] private StageInfoPanel stageInfoPanel;
	//[SerializeField] private Stage stageSelectPanel;
	[SerializeField] private GameObject stageButton;
	[SerializeField] private Transform parent;

	private void Start()
	{
		int count = StageManager.Instance.AllStageDataSO.stageDataList.Count;
		for (int i = 0; i < count; ++i)
		{
			int index = i;
			var obj = Instantiate(stageButton, parent);
			var stBtn = obj.GetComponent<StageButton>();
			var enterBtn = stBtn.GetEnterButton();
			var infoBtn = stBtn.GetInfoButton();
			stBtn.SetStageData(StageManager.Instance.AllStageDataSO.stageDataList[index]);
			enterBtn.AddEvent(() => StageManager.Instance.EnterStage(StageManager.Instance.AllStageDataSO.stageDataList[index]));
			infoBtn.AddEvent(() => stageInfoPanel.Open(StageManager.Instance.AllStageDataSO.stageDataList[index]));
			//btn.AddEvent();
		}
	}
}
