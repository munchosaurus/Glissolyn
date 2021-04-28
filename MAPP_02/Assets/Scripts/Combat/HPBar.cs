using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour
{
    [SerializeField] GameObject health;


    public void SetHP(float HP)
    {
        health.transform.localScale = new Vector3 (HP, 1f);
    }

    public IEnumerator SmoothHPChange(float hpChange)
    {
        float currentHP = health.transform.localScale.x;
        float changeAmt = currentHP - hpChange;

        while (currentHP - hpChange > Mathf.Epsilon)
        {
            currentHP -= changeAmt * Time.deltaTime;
            health.transform.localScale = new Vector3(currentHP, 1f);
            yield return null;
        }
        health.transform.localScale = new Vector3(hpChange, 1f);
    }

}
