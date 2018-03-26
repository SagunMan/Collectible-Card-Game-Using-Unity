using UnityEngine;
using UnityEditor;

static class CharacterUnityIntegration {

	[MenuItem("Assets/Create/CharacterAsset")]
	public static void CreateYourScriptableObject() {
        ScriptableObjectUtitity2.CreateAsset<CharacterAsset>();
	}

}
