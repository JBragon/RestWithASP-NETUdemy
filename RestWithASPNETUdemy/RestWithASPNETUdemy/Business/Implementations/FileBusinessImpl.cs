using System.IO;

namespace RestWithASPNETUdemy.Business.Implementations
{
    public class FileBusinessImpl : IFileBusiness
    {
        public byte[] GetPDFFile()
        {
            string path = Directory.GetCurrentDirectory();
            var fullPath = path += "\\Files\\perceptionsAusGPs.pdf";

            return File.ReadAllBytes(fullPath);
        }
    }
}
