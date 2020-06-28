using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManage : MonoBehaviour {
    public AudioClip towerAShootClip;
    public AudioClip towerBShootClip;
    public AudioClip towerCShootClip;
  
    void Start () { 
		
	}
    public void PlayAudioClip(string towerTag, Vector3 pos, float volume)
    {
        AudioClip clip = null;
        switch (towerTag)
        {
            case "A":
                clip = towerAShootClip;
                break;
            case "B":
                clip = towerBShootClip;
                break;
            case "C":
                clip = towerCShootClip;
                break;
      
        }
        AudioSource.PlayClipAtPoint(clip, pos, volume);
    }
	void Update () {
		
	}
}
