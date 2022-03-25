using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed;
    private GameManager gameManager;
    private float leftBound = -40f;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //move left
        if (gameManager.isGameActive)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
            //destroy obstacles
            if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle (Not Deadly)"))
            {
                Destroy (gameObject);
            }
        }

        
    }
}
