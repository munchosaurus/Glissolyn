using UnityEngine;

public abstract class Character_Info : MonoBehaviour
{
    [SerializeField] protected new string name;
    [SerializeField] protected int id;

    public string GetName()
    {
        return name;
    }

    public int GetId()
    {
        return id;
    }
}
