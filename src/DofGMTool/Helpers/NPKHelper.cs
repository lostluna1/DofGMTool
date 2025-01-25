using DofGMTool.Enums;
using DofGMTool.Models;
using Microsoft.UI.Xaml.Media.Imaging;
using System.Collections.ObjectModel;

namespace DofGMTool.Helpers;

public static class NPKHelper
{
    public static BitmapImage? BitMap { get; set; }

    public static ObservableCollection<Equipments> EquipmentsCollection { get; set; } = new ObservableCollection<Equipments>();

    public static bool DetailIsOpen { get; set; }
    public static string? DetailInfo { get; set; }

    public static List<NpkIndex>? _npkIndexes = new();

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
            if (imgFile.Images.Count() < selectedItem.FrameNo)
            {
                continue;
            }
            ImageIndex img = imgFile.Images[(int)selectedItem.FrameNo];
            if (img.VectorIndex != null)
            {
                img = imgFile.Images[(int)img.VectorIndex];
            }

            string imgPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "ImagePacks");
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

}
