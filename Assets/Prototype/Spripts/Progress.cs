using System.Collections.Generic;
using MalbersAnimations.Utilities;
using UnityEngine;

public class Progress : MonoBehaviour
{
	public static Progress Instance;

	public float ProgressRatio => (float)pickupedCount / maxItems;

	private int pickupedCount = 0;
	private int maxItems = 0;

	private void Awake()
	{
		if(Instance == null)
		{
			Instance = this;
		}
		else
		{
			Destroy(this);
		}
	}

	private void Start()
	{
		FindAll();
	}

	private void FindAll()
    {
        foreach(var pickupable in GetComponentsInChildren<MInteract>())
        {
			maxItems += 1;

		}
	}

	public void PickUp()
	{
		pickupedCount += 1;
	}

	private void Update()
	{
		//Debug.Log($"Ratio => {ProgressRatio}");
	}
}
