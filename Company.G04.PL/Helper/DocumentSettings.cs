namespace Company.G04.PL.Helper
{
    public static class DocumentSettings
    {
        //1-Upload
        public static string Upload(IFormFile file, string foldernName)
        {
            //1. Get Location Of Folder 
            //string folderPath = $"D:\\route\\Projects of c#\\Asp.Net Core MVC\\Company.G04 Solution\\Company.G04.PL\\wwwroot\\files\\{foldernName}";
            //string folderpath = Directory.GetCurrentDirectory() + $"\\wwwroot\\files\\{foldernName}";
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(),$"wwwroot\\files\\{ foldernName}");
            //2- GetFileName

            string filename=$"{Guid.NewGuid()}{file.FileName}";

            //3- get file path :FolderPath + FileName 

            string filepath = Path.Combine(folderPath, filename);

            //4- File Stream

            using var FileStream =new FileStream (filepath,FileMode.Create);
            file.CopyTo(FileStream);

            return filename;
        }


        //2-Delete
        public static void Delete(string filName, string foldername)
        {
            string filepath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\files\\{foldername}", filName);
            if (File.Exists(filepath))
            {
                File.Delete(filepath);
            }
        }
    }
}
