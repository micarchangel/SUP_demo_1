using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GlobalParameters", menuName = "User parameters/New global parameter")]
public class GlobalParameters : ScriptableObject
{
    [SerializeField] private string _id;
    [SerializeField] private int _userQualityLevel;
    [SerializeField] private float _userVolumeLevel;
    

    public string id => this._id;
    public int userQualityLevel => this._userQualityLevel;
    public float userVolumeLevel => this._userVolumeLevel;

    private void setQuality(int q)
    {
        this._userQualityLevel = q;
    }

    private void setVolume(float level)
    {
        this._userVolumeLevel = level;
    }
}
