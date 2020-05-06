using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBarController : MonoBehaviour
{
    public bool autoGame = false;
    private BallController gameBall;

    // Start is called before the first frame update
    void Start()
    {
        gameBall = GameObject.FindObjectOfType<BallController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (autoGame)
        {
            AutoMove();
        }
        else
        {
            FareHareketleri();
        }
    }

    void FareHareketleri()
    {
        Vector3 oyunBariKonumu = new Vector3(0f, this.transform.position.y, 0f);
        float mouseKonumX = Input.mousePosition.x / Screen.width * 16; //oyun barının ekran içinde başlamasını sağladık.
        oyunBariKonumu.x = Mathf.Clamp(mouseKonumX, 1.78f, 14.23f);
        this.transform.position = oyunBariKonumu;
    }

    void AutoMove()
    {
        Vector3 oyunBariKonumu = new Vector3(0f, this.transform.position.y, 0f);
        Vector3 ballPosition = gameBall.transform.position;
        oyunBariKonumu.x = Mathf.Clamp(ballPosition.x, 1.78f, 14.23f);
        this.transform.position = oyunBariKonumu;
    }
}
