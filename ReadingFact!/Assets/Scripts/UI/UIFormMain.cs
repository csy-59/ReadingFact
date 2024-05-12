using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFormMain : UIBase
{
    [SerializeField] private Button btnTrue;
    [SerializeField] private Button btnFalse;
    [SerializeField] private Button btnSearch;
    [SerializeField] private Button btnBack;

    [SerializeField] private UIFormInstargram uiInstargram;

    private Stack<UIBase> windowStack = new Stack<UIBase>();

    private BoLandingData boCurrentLandingPageData;

    private void Start()
    {
        UIHelper.AddButtonEvent(btnTrue, OnClickTrue);
        UIHelper.AddButtonEvent(btnTrue, OnClickFalse);
        UIHelper.AddButtonEvent(btnBack, OnClickBack);
        UIHelper.AddButtonEvent(btnSearch, onClickSearch);

        uiInstargram.MainForm = this;
    }

    public override void OnOpen()
    {
        base.OnOpen();

        OpenForm(1);
    }

    private void OnClickTrue()
    {
        
    }

    private void OnClickFalse()
    {
        
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

        if (windowStack.Count < 2)
            return;

        top.gameObject.SetActive(false);
        windowStack.Pop();
        windowStack.Peek().gameObject.SetActive(true);
    }

    private void onClickSearch()
    {

    }

    public void OpenForm(int formId)
    {
        if(windowStack.Count >= 1)
        {
            windowStack.Peek().gameObject.SetActive(false);
        }

        // 인스타
        if (formId > 0 && formId <= 50)
        {
            uiInstargram.SetData(SDManager.Instance.Instar.dataList.Find(_ => _.ID == formId));
            windowStack.Push(uiInstargram);
        }
        // 쇼츠
        else if(formId <= 100)
        {

        }
        // 검색
        else if(formId <= 200)
        {

        }
        // 뉴스
        else if(formId <= 300)
        {

        }
        // 논문
        else if(formId <= 400)
        {

        }
    }
}
