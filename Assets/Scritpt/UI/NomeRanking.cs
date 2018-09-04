using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NomeRanking : MonoBehaviour {

    private InputField inputField;

    private void Awake()
    {
        this.inputField = this.GetComponent<InputField>();
    }

    private void Start()
    {
        EventSystem.current.SetSelectedGameObject(this.gameObject, null);
        this.inputField.OnPointerClick(new PointerEventData(EventSystem.current));
    }

    public void DesativarInteracao()
    {
        this.inputField.interactable = false;
    }
}
