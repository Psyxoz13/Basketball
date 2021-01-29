using UnityEngine;

public class MenuActiveState : MonoBehaviour
{
    [SerializeField] private Menu[] _menus;

    private static MenuActiveState _menuActiveState;

    private void Awake()
    {
        _menuActiveState = this;
    }

    public static MenuActiveState GetInstance() => _menuActiveState;

    public void ShowMenu(string name)
    {
        for (int i = 0; i < _menus.Length; i++)
        {
            if (_menus[i].Name == name)
            {
                SetCurrentMenuActive(_menus[i].gameObject);
                continue;
            }

            DeactivateMenu(_menus[i].gameObject);
        }
    }

    private void SetCurrentMenuActive(GameObject menu)
    {
        if (menu.activeSelf)
        {
            menu.SetActive(false);
        }
        else
        {
            menu.SetActive(true);
        }
    }

    private void DeactivateMenu(GameObject menu)
    {
        if (menu.activeSelf)
        {
            menu.SetActive(false);
        }
    }
}
