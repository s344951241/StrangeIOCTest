using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AduioManager {

    private static string audioTextPathPrefix = Application.dataPath + "\\Framework\\Resources\\";
    private const string audioTextPathMidfix = "audioList";
    private const string audioTextPathPostfix = ".txt";

    public static string AudioTextPath {
        get {
            return audioTextPathPrefix + audioTextPathMidfix+audioTextPathPostfix;
        }
    }
    private Dictionary<string, AudioClip> audioClipDic = new Dictionary<string, AudioClip>();

    //public AduioManager()
    //{
    //    LoadAudioClip();
    //}

    public bool isMute = false;
    public void Init()
    {
        LoadAudioClip();
    }
    private void LoadAudioClip()
    {
        audioClipDic = new Dictionary<string, AudioClip>();
        TextAsset ta = Resources.Load<TextAsset>(audioTextPathMidfix);
        string[] lines = ta.text.Split('\n');
        foreach (string line in lines)
        {
            if (string.IsNullOrEmpty(line))
                continue;
            string[] keyValue = line.Split(',');
            string key = keyValue[0];
            AudioClip value = Resources.Load<AudioClip>(keyValue[1]);
            audioClipDic.Add(key, value);
        }
    }

    public void Play(string name)
    {
        if (isMute)
            return;
        AudioClip clip;
        audioClipDic.TryGetValue(name,out clip);
        if (clip != null)
        {
            AudioSource.PlayClipAtPoint(clip,Vector3.zero);
        }
    }

    public void Play(string name,Vector3 position)
    {
        if (isMute)
            return;
        AudioClip clip;
        audioClipDic.TryGetValue(name, out clip);
        if (clip != null)
        {
            AudioSource.PlayClipAtPoint(clip, position);
        }
    }

}
