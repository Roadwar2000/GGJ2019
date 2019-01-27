using UnityEngine;

[CreateAssetMenu(fileName = "Instrument", menuName = "Instrument", order = 1)]
public class InstrumentsSO : ScriptableObject
{
    public string Name = "New Instrument";
    public int Number = 1;
    public float ForceMultiplier = 2f;
    public AudioClip Sound;
    public float SoundVolume=100f;
    public AudioClip Collision;
    public float CollisionVolume=100f;        
}
