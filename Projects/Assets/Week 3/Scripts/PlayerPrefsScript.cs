using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsScript : MonoBehaviour
{
    //the key, or reference name, of our playerpref for sound
    //this is a thing that never needs to change, so we're making it a const
    const string SOUND_VOL_KEY = "soundVolKey";

    //the int that holds the sound volume
    private int soundVolume;

    //the property for setting the sound volume
    //the advantage of the property structure is that it's more secure
    //and it also allows us to execute multiple lines of code when setting a variable
    public int SoundVolume
    {
        get
        {
            //read the sound from playerprefs
            //if it can't find it, then set the playerpref to 20
            soundVolume = PlayerPrefs.GetInt(SOUND_VOL_KEY, 20);
            //return the variable
            return soundVolume;
        }
        set
        {
            //set the variable to whatever value is
            //we get value from using the property
            //so if i write SoundVolume = 2;
            //then value is 2
            soundVolume = value;
            //set the playerprefs with the new value
            PlayerPrefs.SetInt(SOUND_VOL_KEY, soundVolume);
        }

    }


    // Start is called before the first frame update
    void Start()
    {
        //set a new playerpref called blahBlahBlah to 2
        PlayerPrefs.SetInt("blahBlahBlah", 2);
        //read that playerpref
        Debug.Log(PlayerPrefs.GetInt("blahBlahBlah", 5));

        //read the playerpref anotherKeyGoesHere
        Debug.Log(PlayerPrefs.GetInt("anotherKeyGoesHere"));

        //use the SoundVolume property to set the volume to 3
        SoundVolume = 3;
        //or set the SoundVolume property using the playerprefs
        SoundVolume = PlayerPrefs.GetInt(SOUND_VOL_KEY, 20);
    }
}
