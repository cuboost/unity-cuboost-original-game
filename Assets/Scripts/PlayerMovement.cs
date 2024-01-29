using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;

    public float forwardForce = 6000f;
    public float boost = 100f;
    public float sidewaysForce = 100f;
    public float panBorderThickness = 2000f;

    // float speed;
    // Vector3 oldPosition;

    // Update is called once per frame
    void Awake()
    {
        panBorderThickness = (Screen.width / 2) - 200f;
        Debug.Log(panBorderThickness);
    }
    void FixedUpdate()
    {
        rb.AddForce(0, 0, (forwardForce + boost) * Time.deltaTime);

        // Speed:
        // speed = Vector3.Distance(oldPosition, transform.position) * 100f;
        // oldPosition = transform.position;
        // Debug.Log("Speed: " + speed.ToString("0"));

        rb.AddForce((sidewaysForce * Input.GetAxisRaw("Horizontal")) * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

        if (Input.touchCount > 0)
        {
            Debug.Log("Touching Screen");
            Touch touch = Input.GetTouch(0);
            Debug.Log("The touch x coordinate is " + touch.position.x);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.position.x >= Screen.width - panBorderThickness)
            {
                rb.AddForce((sidewaysForce), 0, 0, ForceMode.VelocityChange);
            }
            if (touch.position.x <= panBorderThickness)
            {
                rb.AddForce((-sidewaysForce), 0, 0, ForceMode.VelocityChange);
            }
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            boost = 2000f;
        }
        else
        {
            boost = 0f;
        }

        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }

        if (rb.position.z == 40f)
        {
            Time.timeScale = 0.5f;
        }
        else if (rb.position.z > 70f)
        {
            Time.timeScale = 1f;
        }
    }
}