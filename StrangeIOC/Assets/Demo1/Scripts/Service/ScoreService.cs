using System;
using System.Collections;
using System.Collections.Generic;
using strange.extensions.dispatcher.eventdispatcher.api;
using UnityEngine;

public class ScoreService : IScoreService
{
    

    public void OnReceiveScore()
    {
        int score = UnityEngine.Random.Range(0, 100);
        Dispatcher.Dispatch(Demo1ServiceEvent.RequestScore, score);
    }

    public void RequestScore(string url)
    {
        Debug.Log("Request Score from url" + url);
        OnReceiveScore();
    }

    public void UpdateScore(string url, int score)
    {
        Debug.Log("Update Score to url" + url + "new Score" + score);
    }

    [Inject]
    public IEventDispatcher Dispatcher { get; set; }

}
