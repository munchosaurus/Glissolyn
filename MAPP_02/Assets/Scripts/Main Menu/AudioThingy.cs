using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioThingy : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Image overlay;
    [SerializeField] GameObject mainMenuPanel;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeIn());
    }

    public IEnumerator FadeOut()
    {
        overlay.gameObject.SetActive(true);
        float currentTime = 0;
        float duration = 2f;
        float currentVol;

        Color targetColor;

        audioMixer.GetFloat("volume", out currentVol);
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
        SceneManager.LoadScene(1);
    }

    private IEnumerator FadeIn()
    {
        gameObject.GetComponent<AudioSource>().Play();
        float currentTime = 0;
        float duration = 3;
        float targetVol = 0.3f;
        float currentVol;

        Color targetColor;

        audioMixer.GetFloat("volume", out currentVol);
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
    }
}
