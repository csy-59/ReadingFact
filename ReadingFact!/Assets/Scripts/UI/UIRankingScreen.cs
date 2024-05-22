using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIRankingScreen : UIBase
{
    [SerializeField] private List<TMP_Text> rankingList;
    [SerializeField] private TMP_Text[] txtRanking;

    [SerializeField] private Button btnBack;

    private void Start()
    {
        UIHelper.AddButtonEvent(btnBack, Close);
    }

    public override void OnOpen()
    {
        var count = rankingList.Count;
        
        // 랭커를 받는다.
        var ranker = UserManager.Instance.GetRanker(count);

        int j = 0;
        for (int i = 0; i < count; ++i)
        {
            if (i < ranker.Count)
            {
                rankingList[i].text = $"{i + 1}. {ranker[i].Name} - {ranker[i].Score}";
                if (j < txtRanking.Length)
                {
                    txtRanking[j].text = ranker[i].Name;
                    ++j;
                }
            }
            else
            {
                rankingList[i].text = $"{i + 1}.";
                if (j < txtRanking.Length)
                {
                    txtRanking[j].text = string.Empty;
                    ++j;
                }
            }
        }
    }
}
