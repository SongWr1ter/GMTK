using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBillBoard : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    private bool _showingUI;
    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        Show(false);
    }

    public void Show(bool show)
    {
        if (_showingUI != show)
        {
            _showingUI = show;
            canvasGroup.alpha = show ? 1 : 0;
            canvasGroup.interactable = show;
            canvasGroup.blocksRaycasts = show;
        }
    }
}
