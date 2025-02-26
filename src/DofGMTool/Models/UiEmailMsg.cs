using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;

namespace DofGMTool.Models;
public class Message
{
    public string MsgText { get; private set; }
    public DateTime MsgDateTime { get; private set; }

    public string ItemInfo { get; set; }
    public HorizontalAlignment MsgAlignment { get; set; }
    public Brush Background { get; set; }
    public Message(string text, DateTime dateTime, HorizontalAlignment align, int id, string itemInfo, Brush brush)
    {
        MsgText = text;
        MsgDateTime = dateTime;
        MsgAlignment = align;
        PostId = id;
        ItemInfo = itemInfo;
        Background = brush;
    }
    public int PostId { get; set; }
    public override string ToString()
    {
        return MsgDateTime.ToString() + " " + MsgText;
    }
}
