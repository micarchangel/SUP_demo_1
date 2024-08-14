using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private AudioSource slowRowing;

    private PersRBController rbController;

    void Start()
    {
        rbController = player.GetComponent<PersRBController>(); 
    }

    void Update()
    {
        if (rbController.IsKeyDown)
        {
            if (!slowRowing.isPlaying)
            {
                slowRowing.Play();
            }
        }
        else
        {
            if (slowRowing.isPlaying)
            {
                slowRowing.Stop();
            }
        }
    }
}
