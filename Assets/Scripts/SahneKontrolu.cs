using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SahneKontrolu : MonoBehaviour
{ 
    public void SonrakiSahne()
    {
        int mevcutSahneninIndeksi = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(mevcutSahneninIndeksi + 1);
    }
    public void OyunSahnesineYonlen()
    {
        SceneManager.LoadScene(1);
    }

    public void OyundanCik()
    {
        Application.Quit();
    }

    public void MenuSahnesineYonlen()
    {
        SceneManager.LoadScene(0);
    }

    public void SahneyeYonlen(string sahneIsmi)
    {
        SceneManager.LoadScene(sahneIsmi);
    }

    public void BlocklarinYokOlmasi()
    {
        if (BlockController.breakableBlocks <= 0)
        {
            SonrakiSahne();
        }
    }
}
