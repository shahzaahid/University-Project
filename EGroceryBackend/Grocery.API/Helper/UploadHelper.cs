namespace Grocery.API.Helper
{
    public static class UploadHelper
    {
        public static async Task UploadMultipleImages(int ProductId, List<IFormFile> images, string baseDirectory)
        {
            var validImageTypes = new[] { "image/jpeg", "image/png", "image/gif" }; // Add more if needed
            var productDirectory = Path.Combine(baseDirectory, ProductId.ToString());

            if (!Directory.Exists(productDirectory))
            {
                Directory.CreateDirectory(productDirectory);
            }

            var tasks = images
                .Where(image => image.Length > 0 && validImageTypes.Contains(image.ContentType))
                .Select(async image =>
                {
                    var filePath = Path.Combine(productDirectory, $"{Guid.NewGuid()}{Path.GetExtension(image.FileName)}");

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }
                });

            await Task.WhenAll(tasks);
        }
    }
}
