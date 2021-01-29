using UnityEngine;

public class BallTexture : MonoBehaviour
{
    public BallSkin Skin { get; private set; }

    [Space]
    [SerializeField] Material _ballMaterial;
    [SerializeField] Material _rimMaterial;

    private static BallTexture _ballTextureInstance;

    private void Awake()
    {
        _ballTextureInstance = this;
    }

    public static BallTexture GetInstance()
    {
        return _ballTextureInstance;
    }

    public void SetSkin(BallSkin skin)
    {
        Skin = skin;
        UpdateMaterials();
    }

    [ContextMenu("Update Skin")]
    private void UpdateMaterials()
    {
        _ballMaterial.SetTexture("_MainTexture", Skin.Texture.BallTexture);
        _ballMaterial.SetColor("_MainColor", Skin.Texture.BallColor);

        _rimMaterial.color = Skin.Texture.RimColor;
    }
}
