using UnityEngine;
using UnityEngine.SceneManagement; 
using TMPro; 

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject victoryScreen;
    public GameObject defeatScreen;
    public TextMeshProUGUI enemyCounterText; 

    private int totalEnemies;

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
        victoryScreen.SetActive(false);
        defeatScreen.SetActive(false);

        totalEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        UpdateEnemyCounter();
    }

    public void EnemyDefeated()
    {
        totalEnemies--;
        UpdateEnemyCounter();

        if (totalEnemies <= 0)
        {
            ShowVictoryScreen();
        }
    }

    public void PlayerDefeated()
    {
        ShowDefeatScreen();
    }

    void UpdateEnemyCounter()
    {
        if (enemyCounterText != null)
        {
            enemyCounterText.text = "Enemigos restantes: " + totalEnemies;
        }
    }

    void ShowVictoryScreen()
    {
        victoryScreen.SetActive(true);
        Time.timeScale = 0f; 
    }

    void ShowDefeatScreen()
    {
        defeatScreen.SetActive(true);
        Time.timeScale = 0f; 
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
