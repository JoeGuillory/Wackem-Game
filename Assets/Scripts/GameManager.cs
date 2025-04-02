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
    private GameObject _ball;

    [SerializeField]
    private TextMeshProUGUI _ballDistanceText;

    private Rigidbody _ballRigidbody;

    private bool _started;

    private float _ballStartingPosition;
    private float _ballCurrentPosition;
    private float _longestDistance;


    public void IsStarted(bool started)
    {
        _started = started;
    }

    // Start is called before the first frame update
    void Start()
    {
        _longestDistance = 0;
        if (!_ball)
            return;
        _started = false;

        _ballRigidbody = _ball.GetComponent<Rigidbody>();
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
        
        if (Mathf.Approximately(_ballRigidbody.velocity.x, 0) && _started)
        {
            OnBallStop.Invoke();
        }

        if(_ball.transform.localPosition.z < 0)
        {
            _ballRigidbody.isKinematic = true;
        }

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


}
