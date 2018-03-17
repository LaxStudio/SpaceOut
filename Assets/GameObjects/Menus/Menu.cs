using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

    [System.Serializable]
    public class MenuAction
    {
        public Color Color;
        public Sprite Sprite;
        public string Title;
    }

    public MenuButton MenuButtonPrefab;
    public MenuButton SelectedButton;
    
    public TMPro.TextMeshProUGUI TextLabel;

    public MenuAction[] ButtonOptions;
    public string Title;

    private float distance = 100f;
    private KeyCode _menuKeyCode;
    private Transform _menuContentWrapper;

    public void Awake()
    {
        _menuContentWrapper = transform.GetChild(0);
    }

    public void Initialize(KeyCode menuKeyCode, Transform parentTransform)
    {
        transform.SetParent(parentTransform, false);
        _menuContentWrapper.position = Input.mousePosition;

        _menuKeyCode = menuKeyCode;
        StartCoroutine(AnimateButtons());
        TextLabel.text = Title.ToUpper();
    }

    IEnumerator AnimateButtons ()
    {
        for (var i = 0; i < ButtonOptions.Length; i++)
        {
            var newButton = Instantiate(MenuButtonPrefab) as MenuButton;
            newButton.transform.SetParent(_menuContentWrapper); // Place the buttons in the MenuContentWrapper

            var theta = (2 * Mathf.PI / ButtonOptions.Length) * i;
            var xPos = Mathf.Sin(theta);
            var yPos = Mathf.Cos(theta);
            newButton.transform.localPosition = new Vector3(xPos, yPos, 0f) * distance;

            newButton.Circle.color = ButtonOptions[i].Color;
            newButton.Icon.sprite = ButtonOptions[i].Sprite;
            newButton.Title = ButtonOptions[i].Title;
            newButton.ButtonAction = ToggleSelected;

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
                Debug.Log(SelectedButton.Title + " was selected");
            }

        }
        
    } 
}
