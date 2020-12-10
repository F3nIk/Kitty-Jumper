using Doozy.Engine.Progress;
using TMPro;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI label;
    [SerializeField] private ProgressorGroup progressorGroup;

    private const string winLabelText = "Victory";
    private const string loseLabelText = "Lose";

	public void OnEndGameViewEnable()
	{
		SetLabel();
		Invoke("SetProgressors", 1f);
	}

	private void SetLabel()
	{
		if (Progress.Instance.ProgressRatio > 0.5f) label.text = winLabelText;
		else label.text = loseLabelText;
	}

	private void SetProgressors()
	{
		float progressLeft = Progress.Instance.ProgressRatio;

		foreach(Progressor progressor in progressorGroup.Progressors)
		{
			if(progressLeft >= progressor.MaxValue)
			{
				progressor.SetValue(progressor.MaxValue);
				progressor.UpdateProgress();
				progressLeft -= progressor.MaxValue;
			}
			else
			{
				progressor.SetValue(progressLeft);
				progressor.UpdateProgress();
				progressLeft = 0;
				break;
			}
		}
	}


}
