using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFormMain : UIBase
{
    [Header("Buttons")]
    [SerializeField] private Button btnTrue;
    [SerializeField] private Button btnFalse;
    [SerializeField] private Button btnSearch;
    [SerializeField] private Button btnBack;

    [Header("Time")]
    [SerializeField] private Image TimeProcess;
    private float deltaTime;

    [Header("Forms")]
    [SerializeField] private UIFormInstargram uiInstargram;
    [SerializeField] private UIFormShorts uiShorts;
    [SerializeField] private UIFormNewsLInk uiNewsLink;
    [SerializeField] private UIFormNews uiNews;
    [SerializeField] private UIFormThesis uiThesis;

    [Header("Popup")]
    [SerializeField] private Transform uiPausePanel;
    [SerializeField] private Button btnPause;
    [SerializeField] private Button btnExit;
    [SerializeField] private Button btnRestart;
    [SerializeField] private Button btnResume;

    private Stack<UIBase> windowStack = new Stack<UIBase>();

    private BoLandingData boCurrentLandingPageData;

    private bool isVisiedCluePage = false;
    private bool isPlaying = false;
    private float MaxTime = 0f;

    private void Start()
    {
        UIHelper.AddButtonEvent(btnTrue, OnClickTrue);
        UIHelper.AddButtonEvent(btnFalse, OnClickFalse);
        UIHelper.AddButtonEvent(btnBack, OnClickBack);
        UIHelper.AddButtonEvent(btnSearch, onClickSearch);

        UIHelper.AddButtonEvent(btnPause, OnClickPause);
        UIHelper.AddButtonEvent(btnExit, OnClickQuit);
        UIHelper.AddButtonEvent(btnRestart, OnClickRestart);
        UIHelper.AddButtonEvent(btnResume, OnClickResume);
        uiInstargram.MainForm = this;
        uiShorts.MainForm = this;
        uiNewsLink.main = this;
    }

    public void OnEnable()
    {
        uiInstargram.gameObject.SetActive(false);
        uiShorts.gameObject.SetActive(false);
        uiNewsLink.gameObject.SetActive(false);
        uiNews.gameObject.SetActive(false);
        uiThesis.gameObject.SetActive(false);
        uiPausePanel.gameObject.SetActive(false);

        Time.timeScale = 1f;

        isVisiedCluePage = false;

        windowStack.Clear();

        int index = GameManager.Instance.GetNextQuiz();
        if (index < 0)
        {
            Close();
            GameManager.Instance.EndGame();
            return;
        }
        SDLanding landingData = SDManager.Instance.Landing.dataList[index];

        deltaTime = 0.0f;
        isPlaying = true;
        boCurrentLandingPageData = new BoLandingData(landingData);
        OpenForm(boCurrentLandingPageData.SDLanding.ID);
    }

    private void Update()
    {
        if(isPlaying)
        {
            deltaTime += Time.deltaTime;
            TimeProcess.fillAmount = 1 - deltaTime / MaxTime;
        }
    }

    private void OnClickTrue()
    {
        OnClickAnswer();
        boCurrentLandingPageData.ShowResult(true);
    }

    private void OnClickFalse()
    {
        OnClickAnswer();
        boCurrentLandingPageData.ShowResult(false);
    }

    private void OnClickAnswer()
    {
        if(isVisiedCluePage)
        {
            GameManager.Instance.OnAddScore(Define.Score.OnVisitCluePage);
        }

        // 시간 관련
        isPlaying = false;
        int timeScore = 0;
        if(deltaTime <= MaxTime / 3)
        {
            timeScore = Define.Score.FullTimeScore;
        }
        else if(deltaTime <= MaxTime / 3 * 2)
        {
            timeScore = Define.Score.TwoThirdTimeScore;
        }
        else if(deltaTime < MaxTime)
        {
            timeScore = Define.Score.OneThirdTimeScore;
        }
        GameManager.Instance.OnAddScore(timeScore);
    }

    private void OnClickBack()
    {
        // 더 이상 넘어가지 않음
        if (windowStack.Count < 1)
            return;

        UIBase top = windowStack.Peek();
        if(top is UIFormInstargram && uiInstargram.IsCommentOpen)
        {
            uiInstargram.CloseComment();
            return;
        }
        else if(top is UIFormShorts && uiShorts.IsCommentOpen)
        {
            uiShorts.CloseComment();
        }

        if (windowStack.Count < 2)
            return;

        top.gameObject.SetActive(false);
        windowStack.Pop();
        windowStack.Peek().gameObject.SetActive(true);
    }

    private void onClickSearch()
    {
        if (windowStack.Count <= 0)
            return;

        int index = windowStack.Peek().GetResearchIndex();
        OpenForm(index);
    }

    public void OpenForm(int formId)
    {
        if (formId < 0)
            return;

        if(windowStack.Count >= 1)
        {
            windowStack.Peek().gameObject.SetActive(false);
        }

        if(isVisiedCluePage == false && boCurrentLandingPageData.SDLanding.ClueID == formId)
        {
            isVisiedCluePage = true;
        }

        // 인스타
        if (formId > 0 && formId <= 50)
        {
            uiInstargram.SetData(SDManager.Instance.Instar.dataList.Find(_ => _.ID == formId));
            windowStack.Push(uiInstargram);
            windowStack.Peek().OnOpen();

            if (windowStack.Count <= 1)
            {
                MaxTime = Define.Time.MaxInstaThinkTime;
            }
        }
        // 쇼츠
        else if(formId <= 100)
        {
            uiShorts.SetData(SDManager.Instance.Short.dataList.Find(_ => _.ID == formId));
            windowStack.Push(uiShorts);
            windowStack.Peek().OnOpen();

            if (windowStack.Count <= 1)
            {
                MaxTime = Define.Time.MaxShortThinkTime;
            }
        }
        // 검색
        else if(formId <= 200)
        {
            uiNewsLink.SetData(SDManager.Instance.Search.dataList.Find(_ => _.ID == formId));
            windowStack.Push(uiNewsLink);
            windowStack.Peek().OnOpen();
        }
        // 뉴스
        else if(formId <= 300)
        {
            uiNews.SetData(SDManager.Instance.News.dataList.Find(_ => _.ID == formId));
            windowStack.Push(uiNews);
            windowStack.Peek().OnOpen();
        }
        // 논문
        else if(formId <= 400)
        {
            uiThesis.SetData(SDManager.Instance.Thesis.dataList.Find(_ => _.ID == formId));
            windowStack.Push(uiThesis);
            windowStack.Peek().OnOpen();
        }


        windowStack.Peek().gameObject.SetActive(true);
    }

    private void OnClickPause()
    {
        uiPausePanel.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    private void OnClickQuit()
    {
        Application.Quit();
    }

    private void OnClickRestart()
    {
        UIManager.Instance.ShowPopup(Define.UI.UIFormMain, out var _);
    }

    private void OnClickResume()
    {
        uiPausePanel.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
