using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsScript : MonoBehaviour
{

    const string SOUND_VOL_KEY = "soundVolKey";

    private int soundVolume;

    public int SoundVolume
    {
        get
        {
            soundVolume = PlayerPrefs.GetInt(SOUND_VOL_KEY, 20);
            return soundVolume;
        }
        set
        {
            soundVolume = value;
            PlayerPrefs.SetInt(SOUND_VOL_KEY, soundVolume);
        }

    }


    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("blahBlahBlah", 2);
        Debug.Log(PlayerPrefs.GetInt("blahBlahBlah", 5));

        Debug.Log(PlayerPrefs.GetInt("anotherKeyGoesHere"));

        SoundVolume = 3;
        SoundVolume = PlayerPrefs.GetInt(SOUND_VOL_KEY, 20);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
