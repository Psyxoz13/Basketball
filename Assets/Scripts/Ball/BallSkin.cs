using System;
using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "BallSkin", menuName = "Ball Skin", order = 51)]
public class BallSkin : ScriptableObject
{
    public Sprite Icon;

    public SkinInfo SkinInfo;
    public Texture Texture;
}

[Serializable]
public class SkinInfo : IEquatable<SkinInfo>
{
    public string Name = "Standard";
    public int Cost = 0;

    public bool Equals(SkinInfo skinInfo)
    {
        return skinInfo.Name == Name && skinInfo.Cost == Cost;
    }
}

[Serializable]
public class Texture
{
    public Color BallColor = Color.white;
    public Texture2D BallTexture;

    [Space]
    public Color RimColor = Color.black;
}
