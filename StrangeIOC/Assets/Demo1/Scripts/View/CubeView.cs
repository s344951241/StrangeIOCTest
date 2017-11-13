using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeView : View {

    [Inject]
    public IEventDispatcher Dispatcher{ get; set; }
    [Inject]
    public AduioManager AM { get; set; }

    private Text mScoreText;
    /// <summary>
    /// 初始化
    /// </summary>
	public void Init()
    {
        mScoreText = GetComponentInChildren<Text>();
        Debug.Log(AM);
    }

    void Update()
    {
        transform.Translate(new Vector3(Random.Range(-1, 2), Random.Range(-1, 2), Random.Range(-1, 2)) * 0.2f);
        if (Input.GetMouseButton(1))
        {
            PoolManager.Instance.GetInst("Bullet");
        }
    }

    void OnMouseDown()
    {
        Debug.Log("OnMouseDown");
        Dispatcher.Dispatch(Demo1MediatorEvent.ClickDown);
        AM.Play("hit");
    }

    public void UpdateScore(int score)
    {
        mScoreText.text = score.ToString();
    }

}
