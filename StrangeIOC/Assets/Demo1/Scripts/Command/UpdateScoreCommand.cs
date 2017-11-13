using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateScoreCommand : EventCommand {
    [Inject]
    public ScoreModel ScoreModel { get; set; }
    [Inject]
    public IScoreService ScoreService { get; set; } 

    public override void Execute()
    {
        ScoreModel.Score++;
        ScoreService.UpdateScore("http://sddsd", ScoreModel.Score);

        dispatcher.Dispatch(Demo1MediatorEvent.ScoreChange, ScoreModel.Score);
    }
}
