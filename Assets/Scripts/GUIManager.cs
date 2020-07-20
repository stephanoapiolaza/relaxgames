using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{
    public static GUIManager sharedInstance = null;
    public Text movesText, scoreText;
    private int moveCounter;
    private int score;

    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            scoreText.text = "Score: " + score;
        }
    }

    public int MoveCounter
    {
        get
        {
            return moveCounter;
        }
        set
        {
            moveCounter = value;
            movesText.text = "Moves: " + moveCounter;
            if ( moveCounter <= 0)
            {
                moveCounter = 0;
                StartCoroutine(this.GameOver());
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if ( sharedInstance == null )
        {
            sharedInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        moveCounter = 5;
        movesText.text = "Moves: " + moveCounter;
        scoreText.text = "Score: " + score;
    }

    private IEnumerator GameOver()
    {
        yield return new WaitUntil(() => !BoardManager.sharedInstance.isShifting);
        yield return new WaitForSeconds(0.025f);
        //TODO: invocar a una pantalla diseñada para el Game Over
    }

}
