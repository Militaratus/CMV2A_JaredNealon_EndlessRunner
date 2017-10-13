public class MainMenuLevel : BaseLevel
{
    // Play Game button calls this
    public void PlayGame()
    {
        managerGame.LoadLevel("Transition");
    }
}
