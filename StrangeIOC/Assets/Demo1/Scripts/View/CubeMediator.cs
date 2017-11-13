using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMediator : Mediator {

    [Inject]
    public CubeView CubeView { get; set; }

    [Inject(ContextKeys.CONTEXT_DISPATCHER)]//全局派发器
    public IEventDispatcher Dispatcher { get; set; }

    public override void OnRegister()
    {
        Debug.Log("CubeView" + CubeView);
        CubeView.Init();
        Dispatcher.AddListener(Demo1MediatorEvent.ScoreChange,OnScoreChange);
        CubeView.Dispatcher.AddListener(Demo1MediatorEvent.ClickDown, OnScoreUpdate);

        Dispatcher.Dispatch(Demo1CommandEvent.RequestScore);

    }

    public override void OnRemove()
    {
        Dispatcher.RemoveListener(Demo1MediatorEvent.ScoreChange, OnScoreChange);
        CubeView.Dispatcher.RemoveListener(Demo1MediatorEvent.ClickDown, OnScoreUpdate);
    }

    public void OnScoreChange(IEvent ent)
    {
        CubeView.UpdateScore((int)ent.data);
    }

    public void OnScoreUpdate()
    {
        Dispatcher.Dispatch(Demo1CommandEvent.UpdateScore);
    }
}
