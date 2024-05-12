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
    [SerializeField] private RectTransform tranCommentPanel;
    [SerializeField] private ScrollRect scCommentScrollRect;
    [SerializeField] private GameObject goCommentPrefab;
    [SerializeField] private UIFormShortComment pinComment;
    private List<GameObject> listComment = new List<GameObject>();
    public UIFormMain MainForm { get; set; }
    public bool IsCommentOpen { get; private set; }

    SDShort data;

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

    public void SetData(SDShort shortData)
    {
        data = shortData;

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

            commentObject.transform.SetParent(scCommentScrollRect.content);
            listComment.Add(commentObject);
        }
    }

    private void OpenComment()
    {
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
