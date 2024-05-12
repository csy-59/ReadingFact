using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class UIFormInstargram : UIBase
{
    // 이미지 스와이핑
    [Header("Images")]
    [SerializeField] private ScrollRect srImageScrollView;
    private List<Image> listImages = new List<Image>();

    // 내용
    [Header("Content")]
    [SerializeField] private RectTransform transMainTextRect;
    [SerializeField] private TextMeshProUGUI txtMainText;
    [SerializeField] private UIClickableText txtMainTMP_Text;
    static readonly string strMainBsicForm = "<b><color=black>reading_fact</color></b> {0} <#C1C1C1><link=\"OpenContent\">더보기</link></color>";
    static readonly string strMainFullForm = "<b><color=black>reading_fact</color></b> {0}";

    // 댓글
    [Header("Comment")]
    [SerializeField] private UIClickableText txtShowCommentTMP_Text;
    [SerializeField] private RectTransform transCommentPanel;
    [SerializeField] private ScrollRect srCommentScrollView;
    [SerializeField] private GameObject goCommentPrefab;
    private List<GameObject> listComment = new List<GameObject>();

    private SDInstar data;
    private string simpleContect;

    public UIFormMain MainForm { get; set; }

    // 검색 시 필요한 데이터
    public int SearchID { get; set; }

    public bool IsCommentOpen { get; private set; }

    public void Awake()
    {
        txtMainTMP_Text.OnClickHandler = this;
        txtShowCommentTMP_Text.OnClickHandler = this;
    }

    public override void OnOpen()
    {
        base.OnOpen();

        foreach(var image in listImages)
        {
            Destroy(image);
        }

        foreach(var comment in listComment)
        {
            Destroy(comment);
        }

        CloseComment();
    }

    public override void OnTextClicked(TMP_LinkInfo info)
    {
        string linkId = info.GetLinkID();
        if(linkId.Equals("coment"))
        {
            OpenComment();
        }
        else if(linkId.Equals("OpenContent"))
        {
            OpenContext();
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

    public void SetData(SDInstar instarData)
    {
        data = instarData;

        string tempText = string.Empty;
        var tempTexts = instarData.Content.Split('\n');
        if(tempTexts[0].Length >= 20)
        {
            simpleContect = tempTexts[0].Substring(0, 20);
        }
        else
        {
            simpleContect = tempTexts[0];
        }

        // 내용 설정
        txtMainText.SetText(string.Format(strMainBsicForm, simpleContect));
        transMainTextRect.sizeDelta = new Vector2(transMainTextRect.rect.width, txtMainText.preferredHeight);

        // 검색 정보
        SearchID = instarData.SearchID;

        // 이미지 설정
        foreach (var path in instarData.ImagePath)
        {
            Image image = Resources.Load<Image>(path);
            image.transform.SetParent(srImageScrollView.content);
            listImages.Add(image);
        }

        // 댓글 설정
        foreach (var index in instarData.CommentList)
        {
            SDComment commentData = SDManager.Instance.Comment.dataList.Find(_ => _.ID == index);

            GameObject commentObject = Instantiate(goCommentPrefab);
            UIFormInstaComment commentComponent = commentObject.GetComponent<UIFormInstaComment>();
            commentComponent.SetData(commentData, this);

            commentObject.transform.SetParent(srCommentScrollView.content);
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
        transCommentPanel.anchoredPosition = new Vector2(transCommentPanel.anchoredPosition.x, -600.0f);
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
        transCommentPanel.anchoredPosition = new Vector2(transCommentPanel.anchoredPosition.x, -2000.0f);
        yield break;
    }

    private void OpenContext()
    {
        // 내용 설정
        txtMainText.SetText(string.Format(strMainFullForm, data.Content));
        transMainTextRect.sizeDelta = new Vector2(transMainTextRect.rect.width, txtMainText.preferredHeight);
    }
}
