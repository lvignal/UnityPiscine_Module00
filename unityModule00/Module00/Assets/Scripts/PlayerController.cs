using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _playerRb;
    private float _speed = 0.8f;
    private float _jumpForce = 3.5f;
    private bool _isOnGround = true;

    void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        _playerRb.AddForce(Vector3.forward * verticalInput * _speed);
        _playerRb.AddForce(Vector3.right * horizontalInput * _speed);

        if (Input.GetKeyDown(KeyCode.Space) && _isOnGround)
        {
            _playerRb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            Debug.Log("Game Over !");
            Destroy(gameObject);
        }

        else if (other.gameObject.CompareTag("Path"))
            _isOnGround = true;
    }
}