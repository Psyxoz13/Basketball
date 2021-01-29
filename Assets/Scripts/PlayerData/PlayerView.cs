using System.Collections.Generic;

public class PlayerView
{
    public static List<SkinInfo> PurchasedBallSkins { get; private set; }
    public static SkinInfo SelectedBallSkin { get; private set; }

    public static int Coins { get; private set; }
    public static int Record { get; private set; }

    public static int LocalizationID { get; private set; }
    public static float SoundsVolume { get; private set; }
    public static float MusicVolume { get; private set; }

    public static void Update(PlayerData playerData)
    {
        Coins = playerData.Coins;
        Record = playerData.Record;
        PurchasedBallSkins = playerData.PurchasedBallSkins;
        SelectedBallSkin = playerData.SelectedBallSkin;
        LocalizationID = playerData.LocalizationID;
        SoundsVolume = playerData.SoundsVolume;
        MusicVolume = playerData.MusicVolume;
    }
}
