using DofGMTool.Enums;
using DofGMTool.Models;
using Microsoft.UI.Xaml.Media.Imaging;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Windows.Storage;

namespace DofGMTool.Helpers;

public static class NPKHelper
{
    private const string ImagePacks2PathKey = "ImagePacks2Path";
    public static string? ImagePacks2Path { get; set; }
    public static BitmapImage? BitMap { get; set; }

    public static ObservableCollection<Equipments> EquipmentsCollection { get; set; } = [];

    public static bool DetailIsOpen { get; set; }
    public static string? DetailInfo { get; set; }

    public static List<NpkIndex>? _npkIndexes = [];

    /// <summary>
    /// 从NPK中获取图片
    /// </summary>
    /// <param name="equipments"></param>
    public static void GetBitMap(ObservableCollection<Equipments> equipments)
    {
        // 懒得弄了，手动GC
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
        EquipmentsCollection.Clear();
        BitMap = null;

        if (equipments == null || equipments.Count == 0)
        {
            return;
        }

        foreach (Equipments selectedItem in equipments)
        {
            if (selectedItem == null)
            {
                continue;
            }

            if (!string.IsNullOrWhiteSpace(selectedItem.Description))
            {
                DetailIsOpen = true;
                DetailInfo = selectedItem.Description;
            }

            string? npkPath = selectedItem.NpkPath;
            if (string.IsNullOrEmpty(npkPath))
            {
                continue;
            }

            string[] arr = npkPath.Split("/", StringSplitOptions.RemoveEmptyEntries);
            string imgName = arr[arr.Length - 1];
            NpkIndex? imgFile = _npkIndexes?.FirstOrDefault(t => t.Name.ToLower() == $"sprite/{npkPath}".ToLower());
            if (imgFile == null)
            {
                continue;
            }
            // **添加了对 selectedItem.FrameNo 是否超出范围的检查**
            if (imgFile.Images == null || imgFile.Images.Count <= selectedItem.FrameNo)
            {
                Debug.WriteLine($"imgFile.Images 列表中没有索引为 {selectedItem.FrameNo} 的项。");
                continue;
            }
            if (imgFile.Images.Count() < selectedItem.FrameNo)
            {
                continue;
            }
            ImageIndex img = imgFile.Images[(int)selectedItem.FrameNo];
            if (img.VectorIndex != null)
            {
                // **添加了对 img.VectorIndex 是否超出范围的检查**
                if (imgFile.Images.Count <= img.VectorIndex)
                {
                    Debug.WriteLine($"imgFile.Images 列表中没有索引为 {img.VectorIndex} 的项。");
                    continue;
                }
                img = imgFile.Images[(int)img.VectorIndex];
            }

            string imgPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "ImagePacks");
            if (!Directory.Exists(imgPath))
                Directory.CreateDirectory(imgPath);
            imgPath = Path.Combine(imgPath, $"{selectedItem.ItemId}.png");
            if (File.Exists(imgPath))
            {
                BitMap = new BitmapImage(new Uri(imgPath));
                selectedItem.BitMap = BitMap;
                continue;
            }

            var size = new System.Drawing.Size((int)img.Width, (int)img.Height);
            var bits = (ColorBits)Enum.Parse(typeof(ColorBits), img.ColorBytes[0].ToString());
            byte[] data = img.ImageBytes;
            if (img.IsZib)
                data = SharpZipHelper.SharpZipLibDecompress(data);
            using System.Drawing.Bitmap bitmap = Bitmaps.FromArray(data, size, bits);
            bitmap.Save(imgPath);
            BitMap = new BitmapImage(new Uri(imgPath));
            selectedItem.BitMap = BitMap;
        }
    }

    /// <summary>
    /// 从本地获取图片
    /// </summary>
    /// <param name="equipments"></param>
    public static void GetBitMaps(ObservableCollection<Equipments> equipments)
    {
        foreach (Equipments item in equipments)
        {
            string imgPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "ImagePacks");
            imgPath = Path.Combine(imgPath, $"{item.ItemId}.png");

            if (File.Exists(imgPath))
            {
                BitMap = new BitmapImage(new Uri(imgPath));
                item.BitMap = BitMap;
            }
        }
    }
    public static async Task GetBitMapsAsync(ObservableCollection<Equipments> equipments)
    {
        // 获取或创建存放图片的文件夹
        StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
        StorageFolder imageFolder = await localFolder.CreateFolderAsync("ImagePacks", Windows.Storage.CreationCollisionOption.OpenIfExists);

        foreach (Equipments item in equipments)
        {
            try
            {
                // 异步获取图片文件而无需使用同步的 File.Exists
                var fileOrNull = await imageFolder.TryGetItemAsync($"{item.ItemId}.png") as Windows.Storage.StorageFile;
                if (fileOrNull != null)
                {
                    var bitmap = new BitmapImage();
                    using (Windows.Storage.Streams.IRandomAccessStream stream = await fileOrNull.OpenAsync(Windows.Storage.FileAccessMode.Read))
                    {
                        await bitmap.SetSourceAsync(stream);
                    }
                    item.BitMap = bitmap;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
    public static void SaveImagePacks2Path(string path)
    {
        ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
        localSettings.Values[ImagePacks2PathKey] = path;
        ImagePacks2Path = path;
    }

    public static string? LoadImagePacks2Path()
    {
        ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
        if (localSettings.Values.ContainsKey(ImagePacks2PathKey))
        {
            ImagePacks2Path = localSettings.Values[ImagePacks2PathKey] as string;
            return ImagePacks2Path;
        }
        return null;
    }
}
