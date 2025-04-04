using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    public UnityEvent OnBallStop;

    [SerializeField]
    public UnityEvent OnStart;

    [SerializeField]
    private GameObject _ball;

    [SerializeField]
    private TextMeshProUGUI _ballDistanceText;

    [SerializeField]
    private TextMeshProUGUI _highscoretext;

    private Rigidbody _ballRigidbody;
    private BallBehaviour _ballScript;
    private bool _started;

    private float _ballStartingPosition;
    private float _ballCurrentPosition;
    private float _longestDistance;
    private const string _highScore = "HighScore";


    public void IsStarted(bool started)
    {
        _started = started;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey(_highScore))
            PlayerPrefs.SetFloat(_highScore, 0);
        _longestDistance = 0;
        if (!_ball)
            return;
        
        _started = false;

        _ballRigidbody = _ball.GetComponent<Rigidbody>();
        _ballScript = _ball.GetComponent<BallBehaviour>();
        _ballStartingPosition = _ball.transform.position.x;

    }

    // Update is called once per frame
    private void Update()
    {
        if (!_ball)
            return;
        if (!_ballRigidbody)
            return;
        _ballCurrentPosition = _ball.transform.position.x;
        
        //Sets the Retry Screen to active
        if (Mathf.Approximately(_ballRigidbody.velocity.x, 0) && _ballScript.IsHit && _ball.transform.position.x != _ballStartingPosition)
        {
            if (_highscoretext)
            {
                _highscoretext.text = GetScore().ToString("0.0");
            }
            else
                Debug.LogWarning("GameManager: Highscore text is not set!");

            OnBallStop.Invoke();
        }

        //Set the Distance Text
        if (_ballDistanceText)
        {
            float currentDistance = (Mathf.Abs(_ballCurrentPosition - _ballStartingPosition) / 3);

            if (currentDistance > _longestDistance)
               _longestDistance = currentDistance;

            _ballDistanceText.text = _longestDistance.ToString("0.0") + " ft";
        }
        else
            Debug.LogWarning("GameManager: No Text object inserted!");
      
    }


    public void ResetGame()
    {
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private float GetScore()
    {
        if (PlayerPrefs.GetFloat(_highScore) > _longestDistance)
            return PlayerPrefs.GetFloat(_highScore);
        else
        {
            PlayerPrefs.SetFloat(_highScore, _longestDistance);
            PlayerPrefs.Save();
            return _longestDistance;
        }
    }
}
