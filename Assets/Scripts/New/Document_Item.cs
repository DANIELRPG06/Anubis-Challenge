using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Document_Item : MonoBehaviour
{

    public Button button;

    private void Start()
    {
        button.interactable = false;

    }
    private void OnDestroy()
    {
        button.interactable = true;
    }
}
