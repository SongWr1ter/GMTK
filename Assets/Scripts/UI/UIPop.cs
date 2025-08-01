using UnityEngine;
using UnityEngine.UI;

public class UIPop : MonoBehaviour
{
    protected CanvasGroup _canvasGroup;
    protected bool _showingUI = true;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        Show(false);
    }

    public void Show(bool show)
    {
        if (_showingUI != show)
        {
            _showingUI = show;
            _canvasGroup.alpha = show ? 1 : 0;
            _canvasGroup.interactable = show;
            _canvasGroup.blocksRaycasts = show;
            if (show)
            {
                OnShow();
            }
        }
    }
    protected virtual void OnShow(){}
}
