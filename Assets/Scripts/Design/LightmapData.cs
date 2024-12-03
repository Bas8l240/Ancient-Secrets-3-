using UnityEngine;

[CreateAssetMenu(fileName = "LightmapData", menuName = "ScriptableObjects/LightmapData", order = 1)]

public class LightmapData : ScriptableObject 
{
    public int lightmapIndex;
    public Vector4 lightmapScaleOffset;
}