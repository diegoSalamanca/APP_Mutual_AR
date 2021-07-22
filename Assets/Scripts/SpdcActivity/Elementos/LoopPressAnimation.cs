
using UnityEngine;

public class LoopPressAnimation : MonoBehaviour
{

    private void OnEnable()
    {
        var hash = iTween.Hash("scale", new Vector3(1.1f,1.1f,1.1f), "time", 1, "looptype", "pingpong", "EaseType", "easeInBack");
        iTween.ScaleTo(gameObject, hash);
    }
}
