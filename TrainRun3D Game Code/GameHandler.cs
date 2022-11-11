using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public static GameHandler instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
}
