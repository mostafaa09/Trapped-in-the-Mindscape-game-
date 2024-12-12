using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    
public AudioSource efxSource;
public AudioSource musicSource;
public static AudioManager instance = null;
public float lowPitchRange = 0.95f;
public float highPitchRange = 1.05f;

	/////Create Awake():

void Awake(){

if(instance == null){

instance = this;
}else{

Destroy(gameObject);
DontDestroyOnLoad(gameObject);
}

}



	/////Create PlaySingle()

public void PlaySingle(AudioClip clip){

efxSource.clip = clip;
efxSource.Play();
}


	//////create RandomizeSfx() to run multi audio

public void RandomizeSfx(params AudioClip[] clips){

int randomIndex = Random.Range(0, clips.Length);

float randomPitch = Random.Range(lowPitchRange,highPitchRange);

efxSource.pitch = randomPitch;

efxSource.clip = clips[randomIndex];

efxSource.Play();


}
    // Start is called before the first frame update
    void Start()
    {
        Awake();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
