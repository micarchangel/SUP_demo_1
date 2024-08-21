using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EnvironmentAudioController : MonoBehaviour
{
    private Transform audioController;

    private void Start()
    {
        audioController = transform.Find("EnvironmentAudio");
    }

    public void SeaMine()
    {
        //Debug.Log("Звук взрыва");
        Transform obj = audioController.Find("SeaMineAudio");
        obj.GetComponent<AudioSource>().Play();
    }

    public void BoosterBottle()
    {
        Transform obj = audioController.Find("BoosterBottleAudio");
        obj.GetComponent<AudioSource>().Play();
    }

    public void ColaCan()
    {
        Transform obj = audioController.Find("ColaCanAudio");
        obj.GetComponent<AudioSource>().Play();
    }

    public void MoneySack() 
    {
        Transform obj = audioController.Find("MoneySackAudio");
        obj.GetComponent<AudioSource>().Play();
    }
}
