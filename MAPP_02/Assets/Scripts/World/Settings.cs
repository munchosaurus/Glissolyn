using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] Slider audioSlider;

    float desiredAudioValue;

    private void Start()
    {
        audioSlider.value = audioSource.volume;
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

    public float[] GetSaveValues()
    {
        float[] saveValues = new float[1];
        saveValues[0] = audioSlider.value;

        return saveValues;
    }

    public void Toggle()
    {
        gameObject.SetActive(!gameObject.activeInHierarchy);
    }
}
