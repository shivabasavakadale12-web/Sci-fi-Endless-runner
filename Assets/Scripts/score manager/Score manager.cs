using TMPro;
using UnityEngine;

public class Scoremanager : MonoBehaviour
{
    [SerializeField] TMP_Text score;
    [SerializeField] TMP_Text scoretodisplay;

    int scoreamount = 0;

    public void increasescore(int ScoreNumber)
    {
        scoreamount += ScoreNumber;
        score.text = scoreamount.ToString();

        scoretodisplay.text = scoreamount.ToString();
    }
}
