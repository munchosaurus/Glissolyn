using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Lerp : MonoBehaviour
{

    private bool shouldLerp = false; 

    public Vector3 startPos;
    public Vector3 endPos;
    
    public void GoLerp()
    {
        shouldLerp = true;
    }

    void Update()
    {
        if (shouldLerp)
        {
            StartCoroutine(moveChar(startPos, endPos));
        }
    }

    private IEnumerator moveChar(Vector3 start, Vector3 end)
    {
        float elapsedTime = 0;
        while (elapsedTime < 2f)
        {
            transform.position = Vector3.Lerp(start, end, elapsedTime / 1);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        
        
            transform.position = Vector3.Lerp(end, start, elapsedTime / 4);
            elapsedTime += Time.deltaTime;
            shouldLerp = false;
            yield return null;
        
    }

    /*
    public Vector3 Lerping (Vector3 start, Vector3 end, float timeStartedLerping, float lerpTime = 1)
    {
        
        float timeSinceStarted = Time.time - timeStartedLerping;
        float percentageComplete = timeSinceStarted / lerpTime;
        var result = Vector3.Lerp(start, end, percentageComplete);
        
        

        return result;

    }*/
}
