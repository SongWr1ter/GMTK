using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    private CanvasGroup _canvasGroup;
    // Start is called before the first frame update
    void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        FadeOut(0.5f);
    }

    public void FlashIn()
    {
        _canvasGroup.alpha = 1;
    }

    public void FlashOut()
    {
        _canvasGroup.alpha = 0;
    }

    public void FadeInAndOut(float duration)
    {
        _canvasGroup.DOFade(1, duration).SetEase(Ease.InBack).SetLoops(2, LoopType.Yoyo);
    }

    public void FadeOut(float duration)
    {
        _canvasGroup.DOFade(0,duration).SetEase(Ease.OutFlash);
    }
    
    public void FadeIn(float duration)
    {
        _canvasGroup.DOFade(1,duration).SetEase(Ease.InFlash);
    }
}
