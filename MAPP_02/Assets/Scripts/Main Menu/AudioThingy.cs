using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioThingy : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Image overlay;
    [SerializeField] GameObject mainMenuPanel;
    [SerializeField] GameObject audioObject;
    [SerializeField] int sceneToLoad;
    
    private Slider audioSlider;
    private float sliderValue;

    // Start is called before the first frame update
    void Start()
    {
        audioSlider = audioObject.GetComponentInChildren<Slider>();
        audioMixer.SetFloat("volume", -80);
        if (PlayerPrefs.HasKey("Volume"))
        {
            sliderValue = PlayerPrefs.GetFloat("Volume");
        }
        else
        {
            sliderValue = 0.5f;
        }

        audioSlider.value = sliderValue;
        gameObject.GetComponent<AudioSource>().volume = sliderValue;
        StartCoroutine(FadeIn());
    }

    private void Update()
    {
        sliderValue = audioSlider.value;
        if ((sliderValue < 0.5 && sliderValue > 0.45) || (sliderValue > 0.5 && sliderValue < 0.55))
        {
            sliderValue = 0.5f;
        }
        audioSlider.value = sliderValue;
        gameObject.GetComponent<AudioSource>().volume = sliderValue;
    }

    public IEnumerator FadeOut()
    {
        audioObject.SetActive(false);
        overlay.gameObject.SetActive(true);
        float currentTime = 0;
        float duration = 2f;

        Color targetColor;

        audioMixer.GetFloat("volume", out float currentVol);
        currentVol = Mathf.Pow(10, currentVol / 20);
        float targetValue = Mathf.Clamp(0, 0.0001f, 1);

        while (currentTime < duration)
        {
            targetColor = overlay.color;
            targetColor.a = Mathf.Lerp(0, 1, currentTime / duration);
            currentTime += Time.deltaTime;
            float newVol = Mathf.Lerp(currentVol, targetValue, currentTime / duration);
            audioMixer.SetFloat("volume", Mathf.Log10(newVol) * 20);
            overlay.color = targetColor;
            yield return null;
        }
        gameObject.GetComponent<AudioSource>().Stop();
        PlayerPrefs.SetFloat("Volume", sliderValue);
        Game_Controller.GoToWorld();
    }

    private IEnumerator FadeIn()
    {
        gameObject.GetComponent<AudioSource>().Play();
        float currentTime = 0;
        float duration = 3;
        float targetVol = 0.3f;

        Color targetColor;

        audioMixer.GetFloat("volume", out float currentVol);
        currentVol = Mathf.Pow(10, currentVol / 20);
        float targetValue = Mathf.Clamp(targetVol, 0.0001f, 1);

        while (currentTime < duration)
        {
            targetColor = overlay.color;
            targetColor.a = Mathf.Lerp(1, 0, currentTime / duration);
            currentTime += Time.deltaTime;
            float newVol = Mathf.Lerp(currentVol, targetValue, currentTime / duration);
            audioMixer.SetFloat("volume", Mathf.Log10(newVol) * 20);
            overlay.color = targetColor;
            yield return null;
        }
        overlay.gameObject.SetActive(false);
        mainMenuPanel.SetActive(true);
        audioObject.SetActive(true);
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetFloat("Volume", sliderValue);
        PlayerPrefs.Save();
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            PlayerPrefs.SetFloat("Volume", sliderValue);
            PlayerPrefs.Save();
        }
    }
}
