
using UnityEngine;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour
{
    public AudioSource audioSource;
    public Sprite muteSprite, unmuteSprite;    
    Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SwitchSoundState);
    }

    void SwitchSoundState()
    {
        if (audioSource.volume < 1)
        {
            EnableSound();
        }
        else 
        {
            DisableSound();
        }
    }

    void EnableSound()
    {
        audioSource.volume = 1;
        button.image.sprite = unmuteSprite;
    }
    void DisableSound()
    {
        audioSource.volume = 0;
        button.image.sprite = muteSprite;
    }


    private void OnEnable()
    {
        try
        {
            EnableSound();
        }
        catch (System.Exception)
        {

            
        }

    }
}
