using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score instance;
    public Text scoreText;
    public Text highScoreText;
    public Text packagesDeliveredText;





    int score = 0;
    int highscore = 0;
    int packagesDelivered = 0;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = "Score:" + score.ToString();
        highScoreText.text = "High Score:" + highscore.ToString();
        packagesDeliveredText.text = "X:" + packagesDelivered.ToString();
;



    }

    public void AddpointNormal()
    {
        score += 10;
        scoreText.text = "Score:" + score.ToString();
        if (highscore < score)
        {
            PlayerPrefs.SetInt("highscore", score);

        }
        
    }

    public void AddpointBonus()
    {
        score += 20;
        scoreText.text = "Score:" + score.ToString();




    }

    public void LosePoints()
    {
        score -= 5;
        scoreText.text = "Score:" + score.ToString();



    }

    public void PackageDeliverSucess()
    {
        packagesDelivered += 1;
        packagesDeliveredText.text = ": X" + packagesDelivered.ToString();
    }
}
