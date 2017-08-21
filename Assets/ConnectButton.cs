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

        GameObject g1 = GameObject.Find("Droppable Image");
		GameObject g2 = GameObject.Find("New Node3");
        ConnectionManager.CreateConnection(g1.GetComponent<RectTransform>(), g2.GetComponent<RectTransform>());
	}
}