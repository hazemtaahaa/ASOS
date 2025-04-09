using Microsoft.AspNetCore.Http;

namespace ASOS.BL.Helpers
{
    public class DocumentSettings
    {
        public static string UploadFile(IFormFile file)
        {
            //1 get folder path

            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images");

            //2 unique file name

            string fileName = $"{Guid.NewGuid()}{file.FileName}";

            //3 file path
            string filePath = Path.Combine(folderPath, fileName);



            using (var fs = new FileStream(filePath, FileMode.Create))

                file.CopyTo(fs);
            return "Images/" + fileName;
        }
        public static void DeleteFile(string file)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", file);


            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

        }
    }
}
