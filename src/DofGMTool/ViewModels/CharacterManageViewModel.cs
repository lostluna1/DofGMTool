using CommunityToolkit.Mvvm.ComponentModel;
using DofGMTool.Models;

namespace DofGMTool.ViewModels;

public partial class CharacterManageViewModel : ObservableRecipient
{
    //public ISqlSugarClient _sqlSugarClient;
    public IFreeSql<MySqlFlag> _fsql;

    //[ObservableProperty]
    //public partial CharacInfoSqlSugar? SelectedChr { get; set; }

    //[ObservableProperty]
    //public partial ObservableCollection<CharacInfoSqlSugar>? CharacInfo { get; set; }
    public CharacterManageViewModel(/*ISqlSugarClient sqlSugarClient,*/ IFreeSql<MySqlFlag> fsql)
    {

        //_sqlSugarClient = sqlSugarClient;
        //var characInfo = _sqlSugarClient.SqlQueryable<CharacInfoSqlSugar>("Set Charset latin1; select *  from charac_info;").ToList();
        //CharacInfo = new ObservableCollection<CharacInfoSqlSugar>(characInfo);
        _fsql = fsql;
        var chr = fsql.Select<CharacInfo>().ToList();
    }
}
