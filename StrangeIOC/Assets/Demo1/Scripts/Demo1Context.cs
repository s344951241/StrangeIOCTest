using strange.extensions.context.api;
using strange.extensions.context.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo1Context : MVCSContext {

    public Demo1Context(MonoBehaviour view,bool boo) : base(view,boo) { }

    protected override void mapBindings()//绑定映射
    {
        base.mapBindings();
        Debug.Log("mapBindings");
        //manager
        injectionBinder.Bind<AduioManager>().To<AduioManager>().ToSingleton();
        //model
        injectionBinder.Bind<ScoreModel>().To<ScoreModel>().ToSingleton();
        //service
        injectionBinder.Bind<IScoreService>().To<ScoreService>().ToSingleton();//表示这个对象只会生成一个
        //command
        commandBinder.Bind(Demo1CommandEvent.RequestScore).To<RequestScoreCommand>();
        commandBinder.Bind(Demo1CommandEvent.UpdateScore).To<UpdateScoreCommand>();
        //mediator
        mediationBinder.Bind<CubeView>().To<CubeMediator>();//完成view和mediator的绑定

        //创建一个startCommand
        commandBinder.Bind(ContextEvent.START).To<StartCommand>().Once();
    }
}
