using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml.Media.Imaging;

namespace DofGMTool.Models;

public partial class EquipSlotModel : ObservableObject
{
    /// <summary>
    /// ��װ/ħ����ӡ
    /// </summary>
    [ObservableProperty]
    public partial ulong Enchantment { get; set; }

    /// <summary>
    /// ����:1װ�� 8ʱװ
    /// </summary>
    [ObservableProperty]
    public partial ulong Type { get; set; }

    /// <summary>
    /// װ��id
    /// </summary>
    [ObservableProperty]
    public partial ulong EquipId { get; set; }

    /// <summary>
    /// ǿ���ȼ�
    /// </summary>
    [ObservableProperty]
    public partial ulong EnhancementLevel { get; set; }

    /// <summary>
    /// װ��Ʒ��
    /// </summary>
    [ObservableProperty]
    public partial ulong EquipGrade { get; set; }

    /// <summary>
    /// �;ö�
    /// </summary>
    [ObservableProperty]
    public partial ulong Durability { get; set; }

    /// <summary>
    /// ����
    /// </summary>
    [ObservableProperty]
    public partial ulong Orb { get; set; }

    /// <summary>
    /// ����: 1���� 2���� 3���� 4����
    /// </summary>
    [ObservableProperty]
    public partial ulong AmplificationType { get; set; }

    /// <summary>
    /// ��������ֵ ���65536
    /// </summary>
    [ObservableProperty]
    public partial ulong AmplificationValue { get; set; }

    /// <summary>
    /// �����Ϣ
    /// </summary>
    [ObservableProperty]
    public partial ulong AbyssalBreath { get; set; }

    /// <summary>
    /// ħ����ӡ
    /// </summary>
    [ObservableProperty]
    public partial ulong MagicSeal { get; set; }

    /// <summary>
    /// ����ȼ�
    /// </summary>
    [ObservableProperty]
    public partial ulong ForgingLevel { get; set; }

    /// <summary>
    /// װ��ͼ��
    /// </summary>
    [ObservableProperty]
    public partial BitmapImage? BitMap { get; set; }
}

