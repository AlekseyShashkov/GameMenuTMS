using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    [SerializeField] private UIScreen _mainMenu = null;

    void Start()
    {
        _mainMenu.StartScreen();
    }
}