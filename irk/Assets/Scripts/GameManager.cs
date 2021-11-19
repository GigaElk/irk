using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    int currentScore;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);
    }
}
