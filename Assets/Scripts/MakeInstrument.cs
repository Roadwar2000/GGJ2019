#if UNITY_EDITOR
using System.Collections;
using UnityEngine;
using UnityEditor;

public class MakeInstrument
{
    [MenuItem("Assets/Create/Make new Instrument", priority = 2)]
    public static void CreateNewInstrument()
    {
        InstrumentsSO asset = ScriptableObject.CreateInstance<InstrumentsSO>();
        AssetDatabase.CreateAsset(asset, "Assets/InstrumentData/BrandNewInstrument.asset");
        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = asset;
    }
}
#endif
