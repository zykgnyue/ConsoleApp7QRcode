using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;

namespace ConsoleApp7QRcode
{
    class Program
    {
        static void Main(string[] args)
        {
            QrEncoder qr = new QrEncoder(ErrorCorrectionLevel.M);
            QrCode myQrCode = new QrCode();
            bool isSuccess = qr.TryEncode("This is a test",out myQrCode);
            if (isSuccess == true)
            {
                Console.WriteLine($"QrCode Matrix Height:{myQrCode.Matrix.Height}, Wide={myQrCode.Matrix.Width}");
                int qrsize = myQrCode.Matrix.Width;
                if (qrsize < 600)
                {
                    qrsize = 600;
                }
                else
                {
                    qrsize += 600;
                }


                ImageFormat imageFormat = ImageFormat.Png;


                GraphicsRenderer qrRender = new GraphicsRenderer(
                    new FixedCodeSize(qrsize, QuietZoneModules.Two));

                FileStream imgFile = new FileStream($".\\abc3.{imageFormat}", FileMode.Create);
                qrRender.WriteToStream(myQrCode.Matrix, imageFormat, imgFile);


                imgFile.Close();
            }
        }
    }
}
