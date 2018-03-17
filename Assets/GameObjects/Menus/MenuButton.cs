using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.Collections;

public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler{

    public Image Circle;
    public Image Icon;
    public string Title;
    public float Speed = 8f;
    public Action<MenuButton> ButtonAction;

    Color defaultColor;

    public void Start()
    {
        Circle = GetComponent<Image>();
        StartCoroutine(AnimateButtonIn());
    }

    IEnumerator AnimateButtonIn()
    {
        transform.localScale = Vector3.zero;
        var timer = 0f;
        while(timer < (1 / Speed))
        {
            transform.localScale = Vector3.one * timer * Speed;
            timer += Time.deltaTime;
            yield return null;
        }
        transform.localScale = Vector3.one;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ButtonAction.Invoke(this);
        defaultColor = Circle.color;
        Circle.color = Color.white;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ButtonAction.Invoke(this);
        Circle.color = defaultColor;
    }
}
