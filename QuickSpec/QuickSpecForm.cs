// DevTool 1.1 
// Copyright (C) 2024, Adaruru

using Microsoft.Data.Sqlite;

namespace QuickSpec
{
    public partial class QuickSpecForm : Form
    {
        private SqliteConnection sqlite;

        public QuickSpecForm()
        {
            InitializeComponent();
        }
        private void GenQuickSpecClick(object sender, EventArgs e)
        {
            using var connection = new SqliteConnection("Data Source=QuickSpec");

            connection.Open();

            var classes = new List<Class>();
            var funcs = new List<Func>();
            // 獲取所有 Class
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT ClassName, ClassId FROM Class where ClassId <26";
                command.CommandText = "SELECT ClassName, ClassId ,Folder FROM Class where Folder in ('BatchServices') ";
                command.CommandText = "SELECT ClassName, ClassId ,Folder FROM Class where Folder in ('DomainServices') ";
                command.CommandText = "SELECT ClassName, ClassId ,Folder FROM Class where Folder in ('EntityServices') ";
                //command.CommandText = "SELECT ClassName, ClassId FROM Class where ClassId >=46 and ClassId <=55  and Folder ='EntityServices' ";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        classes.Add(new Class
                        {
                            ClassName = reader.GetString(0),
                            ClassId = reader.GetInt32(1),
                            Folder = reader.GetString(2),
                            Funcs = new List<Func>()
                        });
                    }
                }
            }

            // 獲取所有 Func
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT FuncName, Brif, UseRole, Flow, InputCon, OutputCon, SpecDes, ClassId FROM Funcs";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var func = new Func
                        {
                            FuncName = reader.GetString(0),
                            Brif = reader.GetString(1),
                            UseRole = reader.GetString(2),
                            Flow = reader.GetString(3),
                            InputCon = reader.GetString(4),
                            OutputCon = reader.GetString(5),
                            SpecDes = reader.GetString(6),
                            ClassId = reader.GetInt32(7)
                        };
                        funcs.Add(func);

                        // 將 Func 添加到對應的 Class
                        var parentClass = classes.Find(c => c.ClassId == func.ClassId);
                        if (parentClass != null)
                        {
                            parentClass.Funcs.Add(func);
                            func.Class = parentClass;
                        }
                    }
                }
            }

            var Expo = new ExportWordService();
            Expo.ExportWordSchema(classes);

        }
    }
}