using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : SingleTon<GameManager>
{
    private static bool hasAbnormal = false;
    public AbnormalType abType;
    public static bool HasAbnormal => hasAbnormal;
    
    private AbnormalManager _abnormalManager = new AbnormalManager();
    private int currentLevel = 1;
    private const int maxLevel = 13;
    private AbnormalType currentAbnormalType = AbnormalType.None;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    public void NextScene(bool userChoice)
    {
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
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name)!.completed += (asyncOperation) =>
        {
            InitScene();
        };
    }

    public void InitScene()
    {
        currentAbnormalType = _abnormalManager.SelectAbnormal();
        // currentAbnormalType = abType;
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
}
