using UnityEngine;

[CreateAssetMenu(fileName = "CropData", menuName = "ScriptableObjects/Crop", order = 1)]
public class Crop : ScriptableObject
{
    [SerializeField] private float timeToYield;
    public float TimeToYield => timeToYield;
}
