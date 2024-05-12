using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Define
{
    public class UI
    {
        public const string UIHomeScreen = "Prefabs/HomeScreen";
        public const string UIRankScreen = "Prefabs/RankScreen";
        public const string UIRankingScreen = "Prefabs/RankingScreen";
        public const string UIHowToScreen = "Prefabs/HowToScreen";
        public const string UIFailScreen = "Prefabs/FailScreen";
        public const string UIScoreScreen = "Prefabs/ScoreScreen";
        public const string UISuccessScreen = "Prefabs/SuccessScreen";
        public const string UIFormMain = "Prefabs/Form/FormMain";
    }

    public class DefinePrefs
    {
        public const string USER_INFO = "USER_INFO";
    }

    public class Score
    {
        public const int OnVisitCluePage = 5;
        public const int OnSuccess = 10;
        public const int OnFail = 0;
        public const int InTimeMax = 10;
        public const int FullTimeScore = 10;
        public const int TwoThirdTimeScore = 5;
        public const int OneThirdTimeScore = 1;
        public const int NoTimeScore = 0;
    }

    public class Time
    {
        public const int MaxThinkTime = 10;
        public const int FullTimeScore = 10;
    }

}
