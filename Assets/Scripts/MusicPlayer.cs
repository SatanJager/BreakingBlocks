using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    static MusicPlayer OneMusicPlayer = null;

    private void Awake()
    {
        if (OneMusicPlayer != null) //müzik oynatıcısı varsa
        {
            Destroy(gameObject);
        }
        else //muzik oynatıcısı yoksa
        {
            OneMusicPlayer = this;
            //Debug.Log(OneMusicPlayer.GetInstanceID()); //objenin ID'sini çağırır
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }
}
