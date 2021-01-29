using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerPresenter : MonoBehaviour
{
    public static event UnityAction OnPlayerValuesChanged;

    public static List<SkinInfo> PurchasedBallSkins
    {
        get
        {
            return _purchasedBallSkins;
        }
        set
        {
            _purchasedBallSkins = value;
            OnPlayerValuesChanged?.Invoke();
        }
    }

    public static SkinInfo SelectedBallSkin
    {
        private get
        {
            return _selectedBallSkin;
        }
        set
        {
            _selectedBallSkin = value;
            OnPlayerValuesChanged?.Invoke();
        }
    }

    public static int Coins
    {
        get
        {
            return _coins;
        }
        set
        {
            _coins = value;
            OnPlayerValuesChanged?.Invoke();
        }
    }

    public static int Record
    {
        private get
        {
            return _record;
        }
        set
        {
            _record = value;
            OnPlayerValuesChanged?.Invoke();
        }
    }

    public static int LocalizationID
    {
        private get
        {
            return _localizationID;
        }
        set
        {
            _localizationID = value;
            OnPlayerValuesChanged?.Invoke();
        }
    }

    public static float SoundsVolume
    {
        private get
        {
            return _soundsVolume;
        }
        set
        {
            _soundsVolume = value;
            OnPlayerValuesChanged?.Invoke();
        }
    }

    public static float MusicVolume
    {
        private get
        {
            return _musicVolume;
        }
        set
        {
            _musicVolume = value;
            OnPlayerValuesChanged?.Invoke();
        }
    }

    private static List<SkinInfo> _purchasedBallSkins = new List<SkinInfo>();
    private static SkinInfo _selectedBallSkin;

    private static int _record = 0;
    private static int _localizationID = 0;
    private static int _coins;

    private static float _soundsVolume = 1f;
    private static float _musicVolume = 1f;

    private void Awake()
    {
        Load();
        OnPlayerValuesChanged += Save;
    }

    public static void Load()
    {
        var loadedPlayer = Data.LoadData<PlayerData>();

        Coins = loadedPlayer.Coins;
        Record = loadedPlayer.Record;
        PurchasedBallSkins = loadedPlayer.PurchasedBallSkins;
        SelectedBallSkin = loadedPlayer.SelectedBallSkin;
        LocalizationID = loadedPlayer.LocalizationID;
        SoundsVolume = loadedPlayer.SoundsVolume;
        MusicVolume = loadedPlayer.MusicVolume;

        PlayerView.Update(loadedPlayer);
    }

    public static void Save()
    {
        var playerData = new PlayerData
        {
            Coins = Coins,
            Record = Record,
            PurchasedBallSkins = PurchasedBallSkins,
            SelectedBallSkin = SelectedBallSkin,
            LocalizationID = LocalizationID,
            SoundsVolume = SoundsVolume,
            MusicVolume = MusicVolume
        };

        Data.SaveData(playerData);
        PlayerView.Update(playerData);
    }

    [ContextMenu("Reset")]
    public void ResetData()
    {
        var playerData = new PlayerData();

        Data.ResetData(playerData);
        PlayerView.Update(playerData);
    }
}
