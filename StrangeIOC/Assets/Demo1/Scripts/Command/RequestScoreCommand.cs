using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestScoreCommand : EventCommand {

    [Inject]
    public IScoreService ScoreService { get; set;}
    [Inject]
    public ScoreModel ScoreModel { get; set; }

    //[Inject(ContextKeys.CONTEXT_DISPATCHER)]//全局派发器
    //public IEventDispatcher Dispatcher { get; set; }
    public override void Execute()
    {
        Retain();
        ScoreService.Dispatcher.AddListener(Demo1ServiceEvent.RequestScore, OnComplete);
        ScoreService.RequestScore("http://xxxxxx");
    }

    private void OnComplete(IEvent ent)
    {
        Debug.Log("request score complete"+ent.data);
        ScoreService.Dispatcher.RemoveListener(Demo1ServiceEvent.RequestScore,OnComplete);
        ScoreModel.Score = (int)ent.data;
        dispatcher.Dispatch(Demo1MediatorEvent.ScoreChange, ent.data);

        Release();
    }
}
