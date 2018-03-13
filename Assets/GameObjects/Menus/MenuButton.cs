using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.Collections;

public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler{

    public Image Circle;
    public Image Icon;
    public string Title;
    public Menu thisMenu;
    public float speed = 8f;

    Color defaultColor;

    public void Anim()
    {
        StartCoroutine(AnimateButtonIn());
    }

    IEnumerator AnimateButtonIn()
    {
        transform.localScale = Vector3.zero;
        var timer = 0f;
        while(timer < (1 / speed))
        {
            transform.localScale = Vector3.one * timer * speed;
            timer += Time.deltaTime;
            yield return null;
        }
        transform.localScale = Vector3.one;
    }

	// Use this for initialization
	void Start () {
        Circle = GetComponent<Image>();
	}

    public void OnPointerEnter(PointerEventData eventData)
    {
        thisMenu.selected = this;
        defaultColor = Circle.color;
        Circle.color = Color.white;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        thisMenu.selected = null;
        Circle.color = defaultColor;
    }
}
