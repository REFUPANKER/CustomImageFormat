public class ImageFileManager : ConsoleController
{
    EncryptionManager encryptionManager = new EncryptionManager();
    public void EncryptData()
    {
        cw("File Path :");
        string path = Console.ReadLine() + "";
        string enced = encryptionManager.Encrypt(path,
        @"C:\Users\Computer\Documents\Software\CSharp\ImageFormatTest1\Outputs\test.ref");
        //cwl(enced);
        

        //File.WriteAllText(@"C:\Users\Computer\Documents\Software\CSharp\ImageFormatTest1\Outputs\test.ref", enced);
        //cwl(encryptionManager.Encrypt(@"C:\Users\Computer\Documents\Software\CSharp\ImageFormatTest1\Resources\ColorMix.png"));
    }
}