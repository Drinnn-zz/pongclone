using UnityEngine;

public class BallController : MonoBehaviour{
    private Rigidbody2D _rb;
    private AudioSource _bounceSound;

    [SerializeField] private float minXSpeed = 0.8f;
    [SerializeField] private float maxXSpeed = 1.2f;
    [SerializeField] private float minYSpeed = 0.8f;
    [SerializeField] private float maxYSpeed = 1.2f;
    [SerializeField] private float speedIncreaseModifier = 1.3f;

    private void Awake(){
        _rb = GetComponent<Rigidbody2D>();
        _bounceSound = GetComponent<AudioSource>();
    }

    private void Start(){
     SetupBall();   
    }

    private void OnTriggerEnter2D(Collider2D other){
        _bounceSound.Play();
        if (other.CompareTag("Bound"))
            HandleBoundCollision(ref other);
        else if (other.CompareTag("Paddle"))
            HandlePaddleCollision(ref other);
    }

    private void HandleBoundCollision(ref Collider2D other){
        if (other.transform.position.y > transform.position.y && _rb.velocity.y > 0)
            // top bound
            _rb.velocity = new Vector2(_rb.velocity.x, -_rb.velocity.y);
        else if (other.transform.position.y < transform.position.y && _rb.velocity.y < 0)
            // bottom bound
            _rb.velocity = new Vector2(_rb.velocity.x, -_rb.velocity.y);
    }

    private void HandlePaddleCollision(ref Collider2D other){
        if (other.transform.position.x < transform.position.x && _rb.velocity.x < 0)
            // left paddle
            _rb.velocity = new Vector2(-_rb.velocity.x * speedIncreaseModifier, _rb.velocity.y * speedIncreaseModifier);
        else if (other.transform.position.x > transform.position.x && _rb.velocity.x > 0)
            // right paddle
            _rb.velocity = new Vector2(-_rb.velocity.x * speedIncreaseModifier, _rb.velocity.y * speedIncreaseModifier);
    }

    private void SetupBall(){
        _rb.velocity = new Vector2(Random.Range(minXSpeed, maxXSpeed) * (Random.value > 0.5f ? -1 : 1),
            Random.Range(minYSpeed, maxYSpeed) * (Random.value > 0.5f ? -1 : 1));
    }
}