using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] Slider audioSlider;

    float desiredAudioValue;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Volume"))
        {
            desiredAudioValue = PlayerPrefs.GetFloat("Volume");
        }
        else
        {
            desiredAudioValue = 0.5f;
        }
        
        audioSlider.value = desiredAudioValue;
    }
    private void Update()
    {
        desiredAudioValue = audioSlider.value;
        if((desiredAudioValue < 0.5 && desiredAudioValue > 0.48) || (desiredAudioValue > 0.5 && desiredAudioValue < 0.52))
        {
            desiredAudioValue = 0.5f;
        }
        audioSlider.value = desiredAudioValue;
        audioSource.volume = audioSlider.value;
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat("Volume", desiredAudioValue);
    }

    public void Toggle()
    {
        if (gameObject.activeInHierarchy)
        {
            PlayerPrefs.SetFloat("Volume", desiredAudioValue);
        }
        
        gameObject.SetActive(!gameObject.activeInHierarchy);
    }
}
