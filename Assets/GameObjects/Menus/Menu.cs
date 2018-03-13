using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

    public MenuButton menuButtonPrefab;
    public MenuButton selected;
    public TMPro.TextMeshProUGUI TextLabel; 

    private float distance = 100f;

	// Use this for initialization
	public void SpawnButtons (MenuInteractable obj) {
        StartCoroutine(AnimateButtons(obj));

	}

    IEnumerator AnimateButtons (MenuInteractable obj)
    {
        for (var i = 0; i < obj.options.Length; i++)
        {
            var newButton = Instantiate(menuButtonPrefab) as MenuButton;
            newButton.transform.SetParent(transform, false);

            var theta = (2 * Mathf.PI / obj.options.Length) * i;
            var xPos = Mathf.Sin(theta);
            var yPos = Mathf.Cos(theta);
            newButton.transform.localPosition = new Vector3(xPos, yPos, 0f) * distance;

            newButton.Circle.color = obj.options[i].Color;
            newButton.Icon.sprite = obj.options[i].Sprite;
            newButton.Title = obj.options[i].Title;
            newButton.thisMenu = this;
            newButton.Anim();
            yield return new WaitForSeconds(0.06f);
        }
    }

    private void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            Destroy(gameObject);

            if (selected)
            {
                Debug.Log(selected.Title + " was selected");
            }

        }
        
    } 
}
