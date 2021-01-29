using UnityEngine;

public class Framerate : MonoBehaviour
{
    public bool ShowFps = true;
    [ShowIf("ShowFps", true, FieldType.DontDrawReadonly)] public int FPS;
    [SerializeField, Space] private int _targetFramerate = 60;

    private void Start()
    {
        Application.targetFrameRate = _targetFramerate;

        Data.SaveData(new PlayerData());
    }

    private void Update()
    {
        if (ShowFps)
        {
            FPS = Mathf.RoundToInt(
                1f / Time.smoothDeltaTime * Time.timeScale);
        }
    }

    private void OnGUI()
    {
        if (ShowFps)
        {
            var uiStyle = new GUIStyle
            {
                fontSize = 50
            };
            uiStyle.normal.textColor = Color.yellow;

            GUI.Label(
                new Rect(
                    Vector2.one * 20f,
                    Vector2.one * 50f),
                FPS.ToString(),
                uiStyle);
        }
    }
}
