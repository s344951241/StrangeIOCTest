using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

public class TestEditor : EditorWindow
{

    [MenuItem("Manager/AudioManager1")]
    static void CreateWindow()
    {
        TestEditor window = EditorWindow.GetWindow<TestEditor>("音效管理");
        window.Show();
       // window.position = new Rect(0, 0, 500, 500);
    }

    void Awake()
    {
        LoadAudioList();
    }
    private string audioName;
    private string audioPath;
    private Dictionary<string, string> audioDic = new Dictionary<string, string>();
    void OnGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("音效名称");
        GUILayout.Label("音效路径");
        GUILayout.Label("操作");
        GUILayout.EndHorizontal();
        foreach (string key in audioDic.Keys)
        {
            string value;
            audioDic.TryGetValue(key, out value);
            GUILayout.BeginHorizontal();
            GUILayout.Label(key);
            GUILayout.Label(value);
            if (GUILayout.Button("删除"))
            {
                audioDic.Remove(key);
                SaveAudioList();
                return;
            }
            GUILayout.EndHorizontal();
        }

        audioName = EditorGUILayout.TextField("音效名称", audioName);
        audioPath = EditorGUILayout.TextField("音效路劲", audioPath);

        if (GUILayout.Button("添加音效"))
        {
            object o = Resources.Load(audioPath);
            if (o == null)
            {
                Debug.LogWarning("音效不存在" + audioPath);
                audioPath = "";
            }
            else
            {
                if (!audioDic.ContainsKey(audioName))
                {
                    audioDic.Add(audioName, audioPath);
                    SaveAudioList();
                }
                else
                {
                    Debug.LogWarning("音效名字已存在");
                }

            }
        }
    }
    //窗口更新调用
    void OnInspectorUpdate()
    {
        LoadAudioList();
    }

    private void SaveAudioList()
    {
        StringBuilder sb = new StringBuilder();
        foreach (string key in audioDic.Keys)
        {
            string value;
            audioDic.TryGetValue(key, out value);
            sb.Append(key + "," + value + "\n");
        }
        File.WriteAllText(AduioManager.AudioTextPath, sb.ToString());
        //File.AppendAllText(savePath, sb.ToString());

    }

    private void LoadAudioList()
    {
        audioDic = new Dictionary<string, string>();
        if (File.Exists(AduioManager.AudioTextPath) == false) return;
        string[] lines = File.ReadAllLines(AduioManager.AudioTextPath);
        foreach (string line in lines)
        {
            if (string.IsNullOrEmpty(line))
                continue;
            string[] keyValue = line.Split(',');
            audioDic.Add(keyValue[0], keyValue[1]);
        }
    }
}
