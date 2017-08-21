using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectButton : MonoBehaviour {
	private int counter = 0;

	void Start()
	{
	}

	public void OnClick()
	{
		Debug.Log("Button Click: " + counter);
		counter++;
	}
}