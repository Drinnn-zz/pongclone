using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour{
    private BallController _ball;
    private int _score1, _score2;

    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private TextMeshProUGUI score1Text;
    [SerializeField] private TextMeshProUGUI score2Text;
    [SerializeField] private float horizontalBound = 3.18f;

    private void Start(){
        SpawnBall();
        UpdateScoreTexts();
    }

    private void Update(){
        BallListener();
        InputListener();
    }

    private void SpawnBall(){
        GameObject ballInstantiate = Instantiate(ballPrefab, transform);

        _ball = ballInstantiate.GetComponent<BallController>();
        _ball.transform.position = Vector3.zero;
    }

    private void UpdateScoreTexts(){
        score1Text.text = _score1.ToString();
        score2Text.text = _score2.ToString();
    }

    private void BallListener(){
        if (_ball){
            if (_ball.transform.position.x > horizontalBound)
                HandleScore(ref _score1);
            else if (_ball.transform.position.x < -horizontalBound)
                HandleScore(ref _score2);
        }
    }

    private void HandleScore(ref int scoreNumber){
        scoreNumber++;
        UpdateScoreTexts();
        Destroy(_ball.gameObject);
        SpawnBall();
    }

    private void InputListener(){
        if (Input.GetButtonDown("Cancel")){
            SceneManager.LoadScene(1);
        }
    }
}