using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCommand : Command {
    //命令被执行时调用
    [Inject]
    public AduioManager AM { get; set; }
    public override void Execute()
    {
        Debug.Log("StartCommandExcute");
        AM.Init();
        PoolManager.Instance.Init();
    }
}
