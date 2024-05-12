using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIFormNewsLInk : UIBase
{
    [SerializeField] private TextMeshProUGUI SearchText;

    [SerializeField] private ScrollRect scSearchScrollView;
    [SerializeField] private GameObject goNewsPrefab;
    [SerializeField] private GameObject goThesisPrefab;
    private List<GameObject> listSearchedList = new List<GameObject>();

    private SDSearch data;

    public UIFormMain main;

    public override void OnOpen()
    {
        base.OnOpen();
    }

    public void SetData(SDSearch searchData)
    {
        data = searchData;

        foreach (var list in listSearchedList)
        {
            Destroy(list);
        }
        listSearchedList.Clear();

        SearchText.SetText(data.SearchContent);

        foreach(var search in data.CommentList)
        {
            if (search < 201 || search > 400)
                continue;

            // 뉴스
            if (search >= 201 && search <= 300)
            {
                SDNews newsData = SDManager.Instance.News.dataList.Find(_ => _.ID == search);

                GameObject newsObject = Instantiate(goNewsPrefab);
                UISearchNews newsComponent = newsObject.GetComponent<UISearchNews>();
                newsComponent.SetData(newsData, main);

                newsObject.transform.SetParent(scSearchScrollView.content);
                listSearchedList.Add(newsObject);
            }
            // 논문
            else if (search >= 301 && search <= 400)
            {
                SDThesis thesisData = SDManager.Instance.Thesis.dataList.Find(_ => _.ID == search);

                GameObject thesisObject = Instantiate(goNewsPrefab);
                UISearchThesis thesisComponent = thesisObject.GetComponent<UISearchThesis>();
                thesisComponent.SetData(thesisData, main);

                thesisObject.transform.SetParent(scSearchScrollView.content);
                listSearchedList.Add(thesisObject);
            }
        }

        scSearchScrollView.content.gameObject.SetActive(false);
        scSearchScrollView.content.gameObject.SetActive(true);
    }
}
