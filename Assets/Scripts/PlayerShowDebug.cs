using System.Collections.Generic;
using UnityEngine;

public class PlayerShowDebug : MonoBehaviour
{
    [Readonly] public List<SkinInfo> _purchasedBallSkins = new List<SkinInfo>();
    [Readonly] public SkinInfo _selectedBallSkin;

    [Readonly] public int LocalizationID;
    [Readonly] public int Record;
    [Readonly] public int Coins;

    [Readonly] public float SoundsVolume;
    [Readonly] public float MusicVolume;

    [ContextMenu("Show")]
    private void Start()
    {
        var loadedPlayer = Data.LoadData<PlayerData>();

        Coins = loadedPlayer.Coins;
        Record = loadedPlayer.Record;
        _purchasedBallSkins = loadedPlayer.PurchasedBallSkins;
        _selectedBallSkin = loadedPlayer.SelectedBallSkin;
        LocalizationID = loadedPlayer.LocalizationID;
        SoundsVolume = loadedPlayer.SoundsVolume;
        MusicVolume = loadedPlayer.MusicVolume;
    }
}
