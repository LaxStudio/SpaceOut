using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInteractable : MonoBehaviour {

    [System.Serializable]
    public class Action
    {
        public Color Color;
        public Sprite Sprite;
        public string Title;
    }

    public Action[] options;
    public string Title;

    private void Start()
    {
        if (string.IsNullOrEmpty(Title))
        {
            Title = gameObject.name;
        }
    }

    void OnMouseDown()
    {
        MenuSpawner.Instance.SpawnMenu(this);
    }

}
