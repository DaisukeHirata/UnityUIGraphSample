using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class DroppableObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	private Transform canvasTran;
	private GameObject draggingObject;

	void Awake()
	{
		canvasTran = transform.parent.parent;
	}

	public void OnBeginDrag(PointerEventData pointerEventData)
	{
		CreateDragObject();
		draggingObject.transform.position = GetLocalPosition(pointerEventData.position);
	}

	public void OnDrag(PointerEventData pointerEventData)
	{
		draggingObject.transform.position = GetLocalPosition(pointerEventData.position);
	}

	public void OnEndDrag(PointerEventData pointerEventData)
	{
		gameObject.GetComponent<Image>().color = Vector4.one;
		GameObject g1 = GameObject.Find("Dragging Object");
		GameObject g2 = GameObject.Find("New Node3");
		ConnectionManager.CreateConnection(g1.GetComponent<RectTransform>(), g2.GetComponent<RectTransform>());
	}

	// ドラッグオブジェクト作成
	private void CreateDragObject()
	{
		draggingObject = new GameObject("Dragging Object");
		draggingObject.transform.SetParent(canvasTran);
		draggingObject.transform.SetAsLastSibling();
		draggingObject.transform.localScale = Vector3.one;

		// レイキャストがブロックされないように
		CanvasGroup canvasGroup = draggingObject.AddComponent<CanvasGroup>();
		canvasGroup.blocksRaycasts = false;

		Image draggingImage = draggingObject.AddComponent<Image>();
		Image sourceImage = GetComponent<Image>();

		draggingImage.sprite = sourceImage.sprite;
		draggingImage.rectTransform.sizeDelta = sourceImage.rectTransform.sizeDelta;
		draggingImage.color = sourceImage.color;
		draggingImage.material = sourceImage.material;

		gameObject.GetComponent<Image>().color = Vector4.one * 0.6f;
	}


	private Vector2 GetLocalPosition(Vector2 screenPosition)
	{
		Vector3 result = Vector3.zero;

		RectTransformUtility.ScreenPointToWorldPointInRectangle(canvasTran.GetComponent<RectTransform>(), screenPosition, Camera.main, out result);

		return result;
	}
}
