public class AppManager : ConsoleController
{
    private ImageFileManager imageFileManager = new ImageFileManager();

    private string[]? startingArgs = null;
    public AppManager(string[]? args = null)
    {
        this.startingArgs = args;
        Introduction();
    }
    private void Introduction()
    {
        cls();
        cwl(createLine(26, "-"));
        cwl(createLine(7, " ") + "App Started");
        if (startingArgs?.Length > 0)
        {
            cwl("App started with arguments");
        }
        cwl(createLine(26, "-"));
        Run();
    }

    private void Run()
    {
        imageFileManager.EncryptData();
    }
}