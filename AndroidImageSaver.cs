namespace MauiApp1
{
    public static class AndroidImageSaver
    {
        public static async Task SaveImageFromUrlToGalleryAsync(string imageUrl, string fileNameWithoutExtension = "maui_image")
        {
            using var httpClient = new HttpClient();
            var bytes = await httpClient.GetByteArrayAsync(imageUrl);

            await SaveBytesToGalleryAsync(bytes, fileNameWithoutExtension + ".jpg");
        }

        public static async Task SaveBytesToGalleryAsync(byte[] imageBytes, string fileName)
        {
#if ANDROID
            var context = Android.App.Application.Context;

            Android.Net.Uri collection = Android.Provider.MediaStore.Images.Media.ExternalContentUri;

            var values = new Android.Content.ContentValues();
            values.Put(Android.Provider.MediaStore.IMediaColumns.DisplayName, fileName);
            values.Put(Android.Provider.MediaStore.IMediaColumns.MimeType, "image/jpeg");

            if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Q)
            {
                values.Put(
                    Android.Provider.MediaStore.IMediaColumns.RelativePath,
                    Android.OS.Environment.DirectoryPictures + "/MyMauiApp");
            }

            var url = context.ContentResolver.Insert(collection, values);

            if (url == null)
                throw new Exception();

            using (var stream = context.ContentResolver.OpenOutputStream(url))
            {
                if (stream == null)
                    throw new Exception();

                await stream.WriteAsync(imageBytes, 0, imageBytes.Length);
                await stream.FlushAsync();
            }

#else
            await Task.CompletedTask;
#endif
        }
    }
}