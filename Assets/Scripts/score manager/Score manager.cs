using TMPro;
using UnityEngine;

public class Scoremanager : MonoBehaviour
{
    [SerializeField] TMP_Text score;

    int scoreamount = 0;

    public void increasescore(int ScoreNumber)
    {
        scoreamount += ScoreNumber;
        score.text = scoreamount.ToString();
    }
}
