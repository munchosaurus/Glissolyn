using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu_Introduction : MonoBehaviour
{
	int storyNumber;
	[SerializeField] private Text txt;
	[SerializeField] private float timeToWait = 0.1f;
	[SerializeField] private string story1 = "";
	[SerializeField] private string story2 = "";
	[SerializeField] private string story3 = "";
	[SerializeField] private GameObject buttonToChangeTo;
	[SerializeField] private GameObject nextButtonObject;
	[SerializeField] private Button nextButton;

	void Awake()
	{
		storyNumber = 1;
		StartCoroutine("PlayText");
	}

	public void readText() {
		storyNumber++;
		StartCoroutine("PlayText");

	}

	IEnumerator PlayText()
	{
		txt.text = "";
		nextButton.interactable = false;
		switch (storyNumber)
		{
			case 1:
				
				foreach (char c in story1)
				{
					txt.text += c;
					yield return new WaitForSeconds(timeToWait);
				}
				nextButton.interactable = true;
				break;

			case 2:
				foreach (char c in story2)
				{
					
					txt.text += c;
					yield return new WaitForSeconds(timeToWait);
				}
				nextButton.interactable = true;
				break;

			case 3:
				foreach (char c in story3)
				{
					txt.text += c;
					yield return new WaitForSeconds(timeToWait);
				}
				nextButtonObject.SetActive(false);
				buttonToChangeTo.SetActive(true);
				break;
		}
		

	}

}
