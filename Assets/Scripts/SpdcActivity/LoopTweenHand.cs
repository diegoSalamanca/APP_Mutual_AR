
using UnityEngine;

public class LoopTweenHand : MonoBehaviour
{


    public Transform  endPos;
    // Start is called before the first frame update


    private void OnEnable()
    {
        var hash = iTween.Hash("position", endPos.position, "time",3, "looptype","loop");
        iTween.MoveTo(gameObject, hash);
    }


}
