using UnityEngine;

public abstract class Character_Info : MonoBehaviour
{
    [SerializeField] protected new string name;

    public string GetName()
    {
        return name;
    }
}
