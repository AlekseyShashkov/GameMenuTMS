using UnityEngine;

public class MainMenu : UIScreen
{
    [SerializeField] private MyButton _startGame = null, _options = null;
    [SerializeField] private UIScreen _gameScreen = null, _optionsScreen = null;

    public override void SetupScreen(UIScreen previousScreen)
    {
        Debug.Log("Nothig to setup");
    }

    public override void StartScreen()
    {
        base.StartScreen();

        _startGame.AddListener(OpenGame);
        _options.AddListener(Options);
    }

    private void OpenGame()
    {
        _gameScreen.SetupScreen(this);
        
        CloseScreen();
        _gameScreen.StartScreen();
    }

    private void Options()
    {
        _optionsScreen.SetupScreen(this);
        
        CloseScreen();
        _optionsScreen.StartScreen();
    }
}