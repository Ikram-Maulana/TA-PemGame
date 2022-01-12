using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
  public Transform player;
  public Text scoreText;
  public Text highScoreText;
  [SerializeField] PlayerController playerController;

  float score = 0;
  float highScore = 0;

  void Start()
  {
    highScore = PlayerPrefs.GetFloat("highScore", 0);
    score = Mathf.Round(player.position.z); 
    scoreText.text = score.ToString("0") + " Points";
    highScoreText.text = "Highscore: " + highScore.ToString("0");
  }
  
  void Update()
  {
    score = Mathf.Round(player.position.z);
    scoreText.text = score.ToString("0") + " Points";
    if(highScore < score) {
      PlayerPrefs.SetFloat("highScore", score);
    }
    if(score % 150 == 0) {
      playerController.speed += playerController.speedIncreasePerTime;
    }
  }
}

