using System;

public class Class
{
    public int ClassId { get; set; }
    public string ClassName { get; set; }
    public bool IsActive { get; set; }

    // 導航屬性
    public virtual List<Func> Funcs { get; set; }
}
public class Func
{
    public int FuncId { get; set; }
    public string FuncName { get; set; }
    public string Brif { get; set; }        // 簡要說明
    public string UseRole { get; set; }     // 使用角色/功能
    public string Flow { get; set; }        // 事件的基本流程
    public string InputCon { get; set; }    // Input條件
    public string OutputCon { get; set; }   // Output條件
    public string SpecDes { get; set; }     // 規格描述(業務規格)
    public int ClassId { get; set; }

    // 導航屬性
    public virtual Class Class { get; set; }
}