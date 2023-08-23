public class ImageFileManager : ConsoleController
{
    EncryptionManager encryptionManager=new EncryptionManager();
    public void EncryptData()
    {
        //cw("File Path :");
        //encryptionManager.Encrypt(Console.ReadLine()+"");
        encryptionManager.Encrypt(@"C:\Users\Computer\Documents\Software\CSharp\ImageFormatTest1\Resources\ColorMix.png");
    }
}