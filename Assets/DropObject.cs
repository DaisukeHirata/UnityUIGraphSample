﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DropObject : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
	public Image iconImage;
	private Sprite nowSprite;

	void Start()
	{
		nowSprite = null;
	}

	public void OnPointerEnter(PointerEventData pointerEventData)
	{
        Debug.Log("enter");
		if (pointerEventData.pointerDrag == null) return;
		Image droppedImage = pointerEventData.pointerDrag.GetComponent<Image>();
		//iconImage.sprite = droppedImage.sprite;
		//iconImage.color = Vector4.one * 0.6f;
	}

	public void OnPointerExit(PointerEventData pointerEventData)
	{
		Debug.Log("exit");
		if (pointerEventData.pointerDrag == null) return;
		//iconImage.sprite = nowSprite;
		//if (nowSprite == null)
		//	iconImage.color = Vector4.zero;
		//else
			//iconImage.color = Vector4.one;
	}
	public void OnDrop(PointerEventData pointerEventData)
	{
		Debug.Log("drop");
	    Image droppedImage = pointerEventData.pointerDrag.GetComponent<Image>();
//		iconImage.sprite = droppedImage.sprite;
		nowSprite = droppedImage.sprite;
//		iconImage.color = Vector4.one;
	}
}