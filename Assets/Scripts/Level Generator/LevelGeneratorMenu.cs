using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
public class LevelGeneratorMenu : EditorWindow
{
    private static readonly string path = "Assets/Levels/";
    private static string levelName = "Level #";
    private static int levelTime;
    
    [MenuItem("Level Generator/Generate Level")]
    public static void Init()
    {
        LevelGeneratorMenu window = (LevelGeneratorMenu)EditorWindow.GetWindow(typeof(LevelGeneratorMenu));
      //  path = Application.dataPath + levelsPath;
        window.Show();
    }
    public static void GenerateLevel()
    {
        LevelInfo levelInfo = LevelInfo.CreateInstance<LevelInfo>();
        Ball[] balls = FindObjectsOfType<Ball>();
        int size = balls.Length;
        levelInfo.balls = new LevelInfo.BallInfo[size];
        for (int i = 0; i < size; i++)
        {
            levelInfo.balls[i] = new LevelInfo.BallInfo(balls[i].Position, balls[i].Size);
        }
        levelInfo.levelTime = levelTime;
        string soPath = path + levelName + ".asset";
        EditorUtility.SetDirty(levelInfo);
        AssetDatabase.CreateAsset(levelInfo, path + levelName + ".asset");
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = levelInfo;
    }
    void OnGUI()
    {
        GUILayout.Label("Create Level", EditorStyles.boldLabel);
        levelName = EditorGUILayout.TextField("Level Name", levelName);
        levelTime = EditorGUILayout.IntField("Level Time", levelTime);

        if (GUILayout.Button("Generate Level"))
        {
            if (Directory.EnumerateFiles(path).Any(f => f.Contains(levelName)))
                throw new System.Exception("There is already a level with the same name in folder " + path);
            else
                GenerateLevel();
        }
    }

}
#endif