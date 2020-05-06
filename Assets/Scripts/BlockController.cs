using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    public static int breakableBlocks = 0; //blokları saymak için
    private int hitMark;
    private SahneKontrolu sahneYoneticisi; 
    public Sprite[] blockViews;
    bool canBreakable; //blokları saymak için
    public GameObject effect;

    // Start is called before the first frame update
    void Start()
    {
        canBreakable = (CompareTag("Breakable")); //blokları saymak için

        if (canBreakable)
        {
            breakableBlocks++;
        }
        hitMark = 0;
        sahneYoneticisi = GameObject.FindObjectOfType<SahneKontrolu>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<AudioSource>().Play();

        if (canBreakable)
        {
            HitControl();
        }
    }

    public void HitControl()
    {
        int health = blockViews.Length + 1;
        hitMark++;  //hitMark = hitMark + 1; hitMark += 1; // Şeklinde de yazılabilir :)

        if (hitMark >= health)
        {
            CreatEffect();
        }
        else
        {
            ChangeBlockView();
        }
    }

    public void ChangeBlockView()
    {
        this.GetComponent<SpriteRenderer>().sprite = blockViews[hitMark - 1];
    }

    public void SonrakiSahne()
    {
        sahneYoneticisi.SonrakiSahne();
    }

    void CreatEffect()
    {
        breakableBlocks--;
        GameObject createdEffect = Instantiate(effect, gameObject.transform.position, Quaternion.identity) as GameObject;
        createdEffect.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;  //kod bloğu eski obsolete
        Destroy(gameObject);
        sahneYoneticisi.BlocklarinYokOlmasi();
    }

}
