using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public GameBarController gameBar;
    private bool gameStarted;                    //oyun başladı mı?
    private Vector3 ballBarMesurement;

    // Start is called before the first frame update
    void Start()
    {
        ballBarMesurement = transform.position - gameBar.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted)
        {
            this.transform.position = gameBar.transform.position + ballBarMesurement;
            if (Input.GetMouseButtonDown(0))
            {
                gameStarted = true;
                this.GetComponent<Rigidbody2D>().velocity = new Vector3(3f, 9f, 0f); // vector2 de olabilir z'si olmaz.
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 ufakSapma = new Vector2(Random.Range(0f, 0.3f), Random.Range(0f, 0.3f));

        if (gameStarted)
        {
            GetComponent<AudioSource>().Play();
            GetComponent<Rigidbody2D>().velocity += ufakSapma;
        }
    }




}
