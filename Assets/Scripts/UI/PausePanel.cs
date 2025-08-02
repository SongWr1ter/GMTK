using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : MonoBehaviour
{
    [SerializeField] private GameObject player;
    // [SerializeField] private GameObject dynamicObject;
    private CanvasGroup canvasGroup;

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void ReturnGame()
    {
        Time.timeScale = 1;
        player.SetActive(true);
        
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }

    public void PauseGame(CommonMessage msg)
    {
        Time.timeScale = 0;
        player.SetActive(false);
        
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

    private void OnEnable()
    {
        MessageCenter.AddListener(PauseGame,MESSAGE_TYPE.Pause);
        canvasGroup = GetComponent<CanvasGroup>();
    }

    private void OnDestroy()
    {
        MessageCenter.RemoveListener(PauseGame, MESSAGE_TYPE.Pause);
    }
}
