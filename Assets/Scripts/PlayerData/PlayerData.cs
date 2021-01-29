using System;
using System.Collections.Generic;

[Serializable]
public class PlayerData
{
    public int Coins = 100;

    public List<SkinInfo> PurchasedBallSkins = new List<SkinInfo>() { new SkinInfo() };
    public SkinInfo SelectedBallSkin = new SkinInfo();

    public int Record = 0;
    public int LocalizationID = 0;
    public float SoundsVolume = 1f;
    public float MusicVolume = 1f;
}
