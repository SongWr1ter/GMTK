using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDialogue : MonoBehaviour
{
    private CanvasGroup _canvasGroup;
    private TextPanel _textPanel;
    private bool _showingUI = true;
    // Start is called before the first frame update
    void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _textPanel = GetComponentInChildren<TextPanel>();
        Show(false);
    }

    public void Show(bool show,string text = "")
    {
        if (_showingUI != show)
        {
            _showingUI = show;
            _canvasGroup.alpha = show ? 1 : 0;
            _canvasGroup.interactable = show;
            _canvasGroup.blocksRaycasts = show;
            _textPanel.enabled = show;
            if (show)
            {
                _textPanel.StartTyping(text);
            }
        }
    }
}
