using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

    public MenuButton MenuButtonPrefab;
    public MenuButton SelectedButton;
    
    public TMPro.TextMeshProUGUI TextLabel;

    
    public string Title;

    private float distance = 100f;
    private KeyCode _menuKeyCode;
    private Transform _menuContentWrapper;
    private MenuAction[] _buttonOptions;

    public void Awake()
    {
        _menuContentWrapper = transform.GetChild(0);
    }

    public void Initialize(KeyCode menuKeyCode, Transform parentTransform, MenuAction[] buttonOptions)
    {
        transform.SetParent(parentTransform, false);
        _menuContentWrapper.position = Input.mousePosition;

        _menuKeyCode = menuKeyCode;
        TextLabel.text = Title.ToUpper();
        _buttonOptions = buttonOptions;

        StartCoroutine(AnimateButtons());

    }

    IEnumerator AnimateButtons ()
    {
        for (var i = 0; i < _buttonOptions.Length; i++)
        {
            var newButton = Instantiate(MenuButtonPrefab) as MenuButton;
            newButton.transform.SetParent(_menuContentWrapper); // Place the buttons in the MenuContentWrapper

            var theta = (2 * Mathf.PI / _buttonOptions.Length) * i;
            var xPos = Mathf.Sin(theta);
            var yPos = Mathf.Cos(theta);
            newButton.transform.localPosition = new Vector3(xPos, yPos, 0f) * distance;

            newButton.Circle.color = _buttonOptions[i].Color;
            newButton.Icon.sprite = _buttonOptions[i].Sprite;
            newButton.Title = _buttonOptions[i].Title;
            newButton.ButtonAction = ToggleSelected;
            newButton.AcionOnSelected = _buttonOptions[i].ButtonAction;

            yield return new WaitForSeconds(0.06f);
        }
    }

    private void ToggleSelected(MenuButton menuButton)
    {
        if(SelectedButton != menuButton)
        {
            SelectedButton = menuButton;
            TextLabel.text = SelectedButton.Title;
        }
        else
        {
            SelectedButton = null;
            TextLabel.text = Title;
        }
        
    }

    private void Update()
    {
        if(Input.GetKeyUp(_menuKeyCode))
        {
            Destroy(gameObject);

            if (SelectedButton)
            {
                SelectedButton.AcionOnSelected.Invoke();
            }

        }
        
    } 
}
