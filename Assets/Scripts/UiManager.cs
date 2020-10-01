using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _scoreText;
    [SerializeField]
    private Sprite[] _livesSprites;
    [SerializeField]
    private Image _LivesImg;
    [SerializeField]
    private GameObject _goPanel;
    [SerializeField]
    private TMP_Text _scoreText2;
    [SerializeField]
    private TMP_Text _HGscore;


    void Start()
    {
        
        _scoreText.text = "0";
        _scoreText2.text = "0";
        


    }

    void Update()
    {
        
    }

    public void UpdateScore(int playerScore)
    {
        _scoreText.text = playerScore.ToString() ;   
    }

    public void UpdateLives(int currentLives)
    {
        _LivesImg.sprite = _livesSprites[currentLives];
    }

    public void GameOver(int playerscore)
    {
        _goPanel.SetActive(true);
        _scoreText2.text = playerscore.ToString();
        if (playerscore > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", playerscore);
        }
        _HGscore.text = PlayerPrefs.GetInt("HighScore").ToString();
    }
}
