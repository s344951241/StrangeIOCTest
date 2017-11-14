using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalizationManager {

    public static LocalizationManager _instance;

    public static LocalizationManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = new LocalizationManager();
            return _instance;
        }
    }

    private const string Chinese = "Localization/Chinese";
    private const string English = "localization/English";

    public const string Language = English;

    private Dictionary<string, string> dic ;

    public LocalizationManager()
    {
        dic = new Dictionary<string, string>();

        TextAsset ta = Resources.Load<TextAsset>(Language);
        string[] lines = ta.text.Split('\n');
        foreach (string line in lines)
        {
            if (string.IsNullOrEmpty(line) == false)
            {
                string[] keyValue = line.Split('=');
                dic.Add(keyValue[0], keyValue[1]);
            }
        }
    }

    public void Init()
    {

    }

    public string GetValue(string key)
    {
        string value;
        dic.TryGetValue(key, out value);
        return value;
    }
}
