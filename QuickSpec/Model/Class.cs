﻿// DevTool 1.1 
// Copyright (C) 2024, Adaruru

public class Class
{
    public int ClassId { get; set; }
    public string ClassName { get; set; }
    public string Folder { get; set; }
    public virtual List<Func> Funcs { get; set; }
    public bool IsActive { get; set; }
}
public class Func
{
    /// <summary>
    /// 簡要說明
    /// </summary>
    public string Brif { get; set; }

    public virtual Class Class { get; set; }
    public int ClassId { get; set; }
    /// <summary>
    /// 事件的基本流程
    /// </summary>
    public string Flow { get; set; }

    public int FuncId { get; set; }
    public string FuncName { get; set; }
    /// <summary>
    /// Input條件
    /// </summary>
    public string InputCon { get; set; }

    /// <summary>
    /// Output條件
    /// </summary>
    public string OutputCon { get; set; }

    /// <summary>
    /// 規格描述(業務規格)
    /// </summary>
    public string SpecDes { get; set; }

    /// <summary>
    /// 使用角色/功能
    /// </summary>
    public string UseRole { get; set; }
}