
using System.Drawing;
#pragma warning disable CA1416
public class EncryptionManager : ConsoleController
{

    /**
    * classify every color with xy cordinates
    * for example :
        <data>
            author="encrypted text"
            links[]={"encrypted text","encrypted text","encrypted text"}
        </data>
        #454545<-encrypted {(4,4),(5,5),(10,4)}
        #A5F3F3<-encrypted {(1,3),
        (4,9),
        (10,25)}
        #FFFFFF {(0,0)}
    * Encrypt color code and x,y values
    * sytnax characthers 
        { } ( ) ,
    */

    private Dictionary<Color, string> imageColors = new Dictionary<Color, string>();

    public string Encrypt(string filePath, string? saveTo = null)
    {
        string result = "";
        Bitmap bmp = new Bitmap(filePath);
        Thread EncingThread = new Thread(() =>
        {
            cwl("Encrypting ...");
            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmp.Width; j++)
                {
                    Color pixel = bmp.GetPixel(j, i);
                    if (imageColors.Keys.Contains(pixel) == false)
                    {
                        imageColors.Add(pixel, $"({j},{i})");
                        //cwl("pixel added : " + $"{pixel.R},{pixel.G},{pixel.B}");
                        //cwl(ColorEncryption(pixel));
                    }
                    else
                    {
                        //cwl("---> pixel exists: " + $"{pixel.R},{pixel.G},{pixel.B}");
                        imageColors[pixel] += $",({j},{i})";
                    }

                }
                //cwl("%" + ((float)((i + 1) * 100) / bmp.Height));
            }
            cwl("Encryption Completed");
            cwl(createLine(20, "="));

        });
        EncingThread.Start();
        EncingThread.Join();

        if (saveTo != null)
        {
            Thread savingThread = new Thread(() =>
            {
                cwl("Writing to file ...");
                StreamWriter wr = new StreamWriter(saveTo);
                for (int i = 0; i < imageColors.Count; i++)
                {
                    wr.WriteLine(ColorEncryption(imageColors.ElementAt(i).Key) + ":" + imageColors.ElementAt(i).Value);
                    //cwl("Enc>Write : %" + ((float)(i + 1) * 100 / imageColors.Count));
                }
                wr.Close();
                cwl("Encryption saved");
            });
            savingThread.Start();
            savingThread.Join();
        }

        for (int i = 0; i < imageColors.Count; i++)
        {
            result += ColorEncryption(imageColors.ElementAt(i).Key) + ":" + imageColors.ElementAt(i).Value;
            result += (i + 1 < imageColors.Count) ? "\n" : "";
        }


        return result;
    }

    private (int, string, bool) multiParam()
    {
        return (0, "multi", true);
    }


    private string ColorEncryption(Color color)
    {
        string result = "", r, g, b, a;
        r = Convert.ToString(color.R, 2).PadLeft(8, '0');
        g = Convert.ToString(color.G, 2).PadLeft(8, '0');
        b = Convert.ToString(color.B, 2).PadLeft(8, '0');
        a = Convert.ToString(color.A, 2).PadLeft(8, '0');
        result = "(" + CharicEncrypter(r) + "," + CharicEncrypter(g) + "," + CharicEncrypter(b) + "," + CharicEncrypter(a) + ")";
        return result;
    }

    private string CharicEncrypter(string binaryString)
    {
        int count = 1;
        char last = binaryString[0];
        string encres = "";//encryiption result
                           // using X for 0 , Y for 1 at stacking values
        Thread encTh = new Thread(() =>
        {

            for (int i = 1; i < binaryString.Length; i++)
            {
                if (last == binaryString[i])
                {
                    count += 1;
                }
                else
                {
                    encres += count + ((last == '0') ? 'x' : 'y').ToString();
                    count = 1;
                    last = binaryString[i];
                }
            }
            encres += count + ((last == '0') ? 'x' : 'y').ToString();
        });
        encTh.Start();
        encTh.Join();

        return encres;
    }
}