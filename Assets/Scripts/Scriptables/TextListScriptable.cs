


using UnityEngine;

[CreateAssetMenu(fileName = "TextListScriptable", menuName = "ScriptableObjects/TextListScriptable", order = 1)]

public class TextListScriptable : ScriptableObject
{
    public string[] texts;
    public AudioClip audioClip;
}
