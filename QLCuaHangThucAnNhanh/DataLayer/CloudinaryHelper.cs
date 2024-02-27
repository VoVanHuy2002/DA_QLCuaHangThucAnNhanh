using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace DataLayer
{
    public class CloudinaryHelper
    {
        public Cloudinary cloudinary;
        public const string CLOUD_NAME = "dxeladbkd";
        public const string API_KEY = "586539363589778";
        public const string API_SECRET = "F_RvoNjEEhJdfPvfbsypYuyx5FY";

        public CloudinaryHelper()
        {
            Account account = new Account(CLOUD_NAME, API_KEY, API_SECRET);
            cloudinary = new Cloudinary(account);
        }

        public string uploadImage(string path)
        {
            var UploadParams = new ImageUploadParams()
            {
                File = new FileDescription(path)
            };
            var uploadResult = cloudinary.Upload(UploadParams);
            return uploadResult.SecureUrl.ToString();
        }
    }
}
