using UnityEngine;
using UnityEditor;

static class CardUnityIntegration
{
    [MenuItem("Assets/Create/CardAsset")]
    public static void CreateScriptableObject()
    {
        ScriptableObjectUtitity2.CreateAsset<CardAsset>();
    }
}

