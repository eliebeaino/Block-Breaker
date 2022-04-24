using UnityEngine;

public class Ball : MonoBehaviour
{
    //config parameters
    [SerializeField] Paddle Paddle1;
    [SerializeField] float xPush= 2f;     //placeholder not used for now
    [SerializeField] float yPush= 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor =2f;

    [SerializeField] float gameSize = 16f;

    //state
    bool hasStarted = false;
    Vector2 paddleToBallDistane;

    //cached component references
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallDistane = transform.position - Paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockMyBall();
            LaunchMyBall();
        }
    }

    private void LaunchMyBall()
    {
        if (Input.GetMouseButton(0))
        {
            myRigidBody.velocity = new Vector2(((Input.mousePosition.x / Screen.width)-0.5f) * gameSize, yPush);
            hasStarted = true;
        }
    }

    private void LockMyBall()
    {
        Vector2 paddlePos = new Vector2(Paddle1.transform.position.x, Paddle1.transform.position.y);
        transform.position = paddleToBallDistane + paddlePos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Vector2 velocityTweak = new Vector2(Random.Range(0f, randomFactor),Random.Range(0f, randomFactor));
        if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            //myRigidBody.velocity += velocityTweak;
        }
    }
}
