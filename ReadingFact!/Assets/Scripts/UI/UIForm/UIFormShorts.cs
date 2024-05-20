using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using TMPro;

public class UIFormShorts : UIBase
{
    [Header("Title")]
    [SerializeField] private TextMeshProUGUI txtTitle;

    [Header("Video")]
    [SerializeField] private VideoPlayer vpVideoPlayer;

    [Header("Comment")]
    [SerializeField] private Button ShowCommentBtn;
    [SerializeField] private RectTransform tranCommentPanel;
    [SerializeField] private ScrollRect scCommentScrollRect;
    [SerializeField] private GameObject goCommentPrefab;
    [SerializeField] private UIFormShortComment pinComment;
    private List<GameObject> listComment = new List<GameObject>();
    public UIFormMain MainForm { get; set; }
    public bool IsCommentOpen { get; private set; }

    SDShort data;

    public void Start()
    {
        UIHelper.AddButtonEvent(ShowCommentBtn, OpenComment);
    }

    public override void OnOpen()
    {
        base.OnOpen();
    }

    public override void OnTextClicked(TMP_LinkInfo info)
    {
        string linkId = info.GetLinkID();
        if (linkId.Equals("coment"))
        {
            OpenComment();
        }
        else
        {
            int index = int.Parse(linkId);
            MainForm.OpenForm(index);
        }
    }
    public override int GetResearchIndex()
    {
        return data.SearchID;
    }

    public void SetData(SDShort shortData)
    {
        data = shortData;

        foreach (var comment in listComment)
        {
            Destroy(comment);
        }
        listComment.Clear();

        CloseComment();

        // 타이틀 설정
        txtTitle.SetText(shortData.Title);

        // 비디오 설정
        vpVideoPlayer.clip = Resources.Load<VideoClip>(shortData.VideoPath);

        // 댓글 설정
        SDComment fixedCommentData = SDManager.Instance.Comment.dataList.Find(_ => _.ID == shortData.FixedComment);
        pinComment.SetData(fixedCommentData, this);

        foreach (var index in shortData.CommentList)
        {
            SDComment commentData = SDManager.Instance.Comment.dataList.Find(_ => _.ID == index);

            GameObject commentObject = Instantiate(goCommentPrefab);
            UIFormShortComment commentComponent = commentObject.GetComponent<UIFormShortComment>();
            commentComponent.SetData(commentData, this);

            commentObject.transform.SetParent(scCommentScrollRect.content, false);
            listComment.Add(commentObject);
        }
    }

    private void OpenComment()
    {
        if (this.gameObject.activeSelf == false)
            return;

        StartCoroutine(OpenCommentCoroutine());
        IsCommentOpen = true;
    }

    IEnumerator OpenCommentCoroutine()
    {
        // 임시
        tranCommentPanel.anchoredPosition = new Vector2(tranCommentPanel.anchoredPosition.x, -600.0f);
        yield break;
    }

    public void CloseComment()
    {
        if (this.gameObject.activeSelf == false)
            return;

        StartCoroutine(CloseCommentCoroutine());
        IsCommentOpen = false;
    }

    IEnumerator CloseCommentCoroutine()
    {
        // 임시
        tranCommentPanel.anchoredPosition = new Vector2(tranCommentPanel.anchoredPosition.x, -2000.0f);
        yield break;
    }
}
