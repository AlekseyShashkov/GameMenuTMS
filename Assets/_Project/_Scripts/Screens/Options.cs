using UnityEngine;

public class Options : UIScreen
{
    [SerializeField] private MyButton _back = null;

    private UIScreen _previousScreen = null;

    public override void SetupScreen(UIScreen previousScreen)
    {
        if (_previousScreen == null)
            _previousScreen = previousScreen;

        _back.AddListener(BackToMenu);
    }

    private void BackToMenu()
    {
        CloseScreen();
        _previousScreen.StartScreen();
    }
}