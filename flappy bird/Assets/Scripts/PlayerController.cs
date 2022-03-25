using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //variables
    private Rigidbody2D rb;
    public float flapStrength;
    private GameManager gameManager;
    private int scoreToAdd = 1;
    public AudioClip flapClip;
    public float flapClipVolume = 1f;
    public AudioClip crashClip;
    public float crashClipVolume = 1f;
    public AudioClip scoreClip;
    public float scoreClipVolume = 1f;
    private AudioSource playerAudio;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAudio = GetComponent<AudioSource>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }
    // Update is called once per frame
    void Update()
    {
        //press space to make the bird gain hight
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.velocity = Vector2.up * flapStrength;
        playerAudio.PlayOneShot(flapClip, flapClipVolume);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            gameManager.GameOver();
            playerAudio.PlayOneShot(crashClip, crashClipVolume);
        }
        if (collider.gameObject.CompareTag("Ground"))
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            Debug.Log("Game Over");
            gameManager.GameOver();
            playerAudio.PlayOneShot(crashClip, crashClipVolume);
        }
        if (collider.gameObject.CompareTag("Obstacle (Not Deadly)"))
        {
            gameManager.UpdateScore(scoreToAdd);
            playerAudio.PlayOneShot(scoreClip, scoreClipVolume);
        }
    }
}
