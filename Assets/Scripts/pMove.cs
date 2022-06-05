
using UnityEngine;
using UnityEngine.SceneManagement;

public class pMove : MonoBehaviour
{
    bool alive = true;
    public float speed = 5;
    public Rigidbody rb;
    float horizontalInput;
    public float horizontalMultiplier = 2;
    public float speedIncreasePerPoint = 0.1f;
    [SerializeField] float jumpForce = 400f;
    [SerializeField] LayerMask groundMask;
    private void FixedUpdate()
    {
        if (!alive)
            return;
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime*horizontalMultiplier;
        rb.MovePosition(rb.position+forwardMove+horizontalMove);
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if(transform.position.y<-5)
        {
            die();
        }
        
    }
    public void die()
    {
        alive = false;
        Invoke("Restart", 2);
       // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void Jump()
    {
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, groundMask);
        rb.AddForce(Vector3.up * jumpForce);
    }
}
