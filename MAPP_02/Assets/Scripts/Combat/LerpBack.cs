using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpBack : MonoBehaviour
{

    private bool shouldLerp = false;

    public float timeStartedLerping;
    public float lerpTime;

    public Vector3 startPos;
    public Vector3 endPos;
    private void StartLerping()
    {
        timeStartedLerping = Time.time;
        shouldLerp = true;
    }

    public void GoLerp()
    {
        StartLerping();
    }

    void Update()
    {
        if (shouldLerp)
        {
            transform.position = Lerping(startPos, endPos, timeStartedLerping, lerpTime);
        }
    }


    public Vector3 Lerping(Vector3 start, Vector3 end, float timeStartedLerping, float lerpTime = 1)
    {
        float timeSinceStarted = Time.time - timeStartedLerping;
        float percentageComplete = timeSinceStarted / lerpTime;
        var result = Vector3.Lerp(start, end, percentageComplete);

        return result;

    }
}
