using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private Button pokeButton;

    [SerializeField]
    private GameObject gameTitle;

    [SerializeField]
    private GameObject scoreAndBest;

    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private Text bestText;

    [SerializeField]
    private GameObject gameOverText;

    [SerializeField]
    private GameObject thisIsNotALinkText;

    [SerializeField]
    private Text finalScore;

    [SerializeField]
    private Image canvasPanel;

    int pokeCounter = 0;

    bool firstClick = true;

    float restartDelay = 2f;

    void StartGame()
    {
        gameTitle.SetActive(false);
        bestText.text = "Best: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        scoreAndBest.SetActive(true);
    }

    public void AddPokeCount()
    {

        if (firstClick)
        {
            firstClick = false;
            StartGame();
        }


        if(pokeButton.image.sprite.name == "ganondorf")
        {
            gameOverText.SetActive(true);
            thisIsNotALinkText.SetActive(true);
            scoreAndBest.SetActive(false);
            finalScore.text = pokeCounter.ToString();

            if (pokeCounter > PlayerPrefs.GetInt("HighScore", 0))
            {
                PlayerPrefs.SetInt("HighScore", pokeCounter);
            }
    
            Invoke("Restart", restartDelay);
        } else
        {
            pokeCounter = pokeCounter + 1;
            scoreText.text = pokeCounter.ToString();
            canvasPanel.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }

    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
