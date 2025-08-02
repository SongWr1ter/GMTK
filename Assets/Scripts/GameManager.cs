using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using DG.Tweening;

public class GameManager : SingleTon<GameManager>
{
    private static bool hasAbnormal = false;
    public AbnormalType abType;
    public bool debug;
    public static bool HasAbnormal => hasAbnormal;
    
    private AbnormalManager _abnormalManager = new AbnormalManager();
    private int currentLevel = 1;
    private const int maxLevel = 13;
    private AbnormalType currentAbnormalType = AbnormalType.None;
    private FadeInOut _fadeinout;
    public bool isLoadingNextLevel = false;
    private FadeInOut fadeInOut
    {
        get
        {
            if (_fadeinout == null)
            {
                _fadeinout = GameObject.Find("FadeInOut").GetComponent<FadeInOut>();
            }
            return _fadeinout;
        }
    }

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if (_fadeinout == null)
        {
            _fadeinout = GameObject.Find("FadeInOut").GetComponent<FadeInOut>();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MessageCenter.SendMessage(new CommonMessage()
            {
                Mid = 0
            },MESSAGE_TYPE.Pause);
        }
    }

    public void NextScene(bool userChoice, bool fadeIn = true)
    {
        isLoadingNextLevel = true;
        if (userChoice == hasAbnormal)
        {
            //回答正确
            ++currentLevel;
            if (currentLevel >= maxLevel)
            {
                //通关
                return;
            }
        }
        else
        {
            currentLevel = Mathf.Max(currentLevel - 1, 1);
        }
        //异步重新加载这一个场景,并且添加一个回调函数:InitScene
        if (fadeIn)
             fadeInOut.FadeIn(0.5f);
        //用DoTween等1s
        float timer = 0f;
        float delayedTimer = 1f;
        //DOTwwen.To()中参数：前两个参数是固定写法，第三个是到达的最终值，第四个是渐变过程所用的时间
        DOTween.To(() => timer, x => timer = x, 1, delayedTimer)
            .OnStepComplete(() =>
            {
                SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name)!.completed += (asyncOperation) =>
                {
                    InitScene();
                    isLoadingNextLevel = false;
                };
            }).SetAutoKill();
            // .SetLoops(loopTimes); 
    }

    public void InitScene()
    {
        currentAbnormalType = _abnormalManager.SelectAbnormal();
        if (currentLevel == 1) currentAbnormalType = AbnormalType.None;
        if(debug) currentAbnormalType = abType;
        hasAbnormal = currentAbnormalType != AbnormalType.None;
        //发送信息
        MessageCenter.SendMessage(new CommonMessage()
        {
            Mid = (int)currentAbnormalType,
        },MESSAGE_TYPE.ABNORMAL);
    }

    public int GetCurrentLevel()
    {
        return currentLevel;
    }
    
    public AbnormalType GetCurrentAbnormalType()
    {
        return currentAbnormalType;
    }

    public void GameOver()
    {
        SoundManager.PlayAudio("die");
        fadeInOut.FadeIn(0.2f);
        float timer = 0f;
        float delayedTimer = 3f;
        //DOTwwen.To()中参数：前两个参数是固定写法，第三个是到达的最终值，第四个是渐变过程所用的时间
        DOTween.To(() => timer, x => timer = x, 1, delayedTimer)
            .OnStepComplete(() =>
            {
                NextScene(!hasAbnormal,false);
            }).SetAutoKill();
        
    }
}
