using UnityEngine;

public class PaddleController : MonoBehaviour{
    private float _input;
    private Rigidbody2D _rb;

    [SerializeField] private float moveSpeed = 1.0f;
    [SerializeField] private int playerIndex = 1;

    private void Awake(){
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update(){
        InputListener();
    }

    private void InputListener(){
        _input = Input.GetAxis("Vertical" + playerIndex);
        _rb.velocity = new Vector2(0, _input) * moveSpeed;
    }
}