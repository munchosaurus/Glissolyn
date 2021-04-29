using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu_Introduction : MonoBehaviour
{
	int storyNumber;
	[SerializeField] private Text txt;
	[SerializeField] private float timeToWait;
	private string story1 = "Hello brave warrior!" +
		" Welcome to the world of Glyssolin.";
	private string story2 = "The lands of Glyssolin have for as long as people can remember been a calm and peaceful state" +
		" However, things have recently changed. Peculiar things have started happening.";
	private string story3 = "Villagers have suddenly gone sick and people have increasingly" +
		" been reported missing in neighbouring villages!";
	private string story4 = "Head out on a journey to find out what's" +
		" causing the sudden change of events.";
	private string story5 = "But first, please let the inhabitants of Glyssolin get to know your name" +
		" after pressing next";
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
				nextButton.interactable = true;
				break;
			case 4:
				foreach (char c in story4)
				{

					txt.text += c;
					yield return new WaitForSeconds(timeToWait);
				}
				nextButton.interactable = true;
				break;

			case 5:
				foreach (char c in story5)
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
