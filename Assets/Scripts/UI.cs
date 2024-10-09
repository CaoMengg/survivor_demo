using UnityEngine;

public class UI : MonoBehaviour
{
    public static UI Instance { get; private set; }
    public GameObject background;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        ResumeGame();
    }

    public void PauseGame()
    {
        background.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        background.SetActive(false);
        Time.timeScale = 1f;
    }
}
