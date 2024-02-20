using UnityEngine;

public class Game : UIScreen
{
    [SerializeField] private MyButton _back = null, _shop = null;

    private UIScreen _previousScreen = null;
    [SerializeField] private UIScreen _shopScreen = null;

    public override void SetupScreen(UIScreen previousScreen)
    {
        if (_previousScreen == null)
            _previousScreen = previousScreen;

        _back.AddListener(BackToMenu);
        _shop.AddListener(OpenShop);
    }

    private void BackToMenu()
    {
        CloseScreen();
        _previousScreen.StartScreen();
    }

    private void OpenShop()
    {
        _shopScreen.SetupScreen(this);

        CloseScreen();
        _shopScreen.StartScreen();
    }
}
