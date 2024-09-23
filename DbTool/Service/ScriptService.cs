using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Namotion.Reflection;
using System.Linq;

interface IDBDescription
{
    public void Parse();
}
public class ScriptService
{
    public ScriptService()
    {
    }


    public string GenColumnDescScriptFromDal(Type dbContextType)
    {
        Dictionary<string, Type> listType = new Dictionary<string, Type>();
        var types = dbContextType.GetProperties()
            .Where(p => p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>));

        foreach (var type in types)
        {
            listType.Add(type.Name, type.PropertyType.GetGenericArguments().First());
        }
                                     ;
        Dictionary<string, Type> baseTableTypes = listType.Where(r => listType.All(x => !r.Value.IsSubclassOf(x.Value))).ToDictionary(k => k.Key, v => v.Value);
        List<FieldInfo> fieldInfos = new List<FieldInfo>();
        foreach (var baseTableType in baseTableTypes)
        {
            string baseTableName = (baseTableType.Value.CustomAttributes
                .Any((CustomAttributeData r) => r.AttributeType == typeof(TableAttribute))
                ? baseTableType.Value.CustomAttributes.First((CustomAttributeData r) => r.AttributeType == typeof(TableAttribute)).ConstructorArguments[0].Value.ToString()
                : baseTableType.Key);
            List<Type> baseTableTypeAndChilds = listType.Where(r => r.Value.IsSubclassOf(baseTableType.Value) || r.Value == baseTableType.Value).Select(x => x.Value).ToList();
            foreach (Type tabletype in baseTableTypeAndChilds)
            {
                PropertyInfo[] fieldTypes = tabletype.GetProperties();
                PropertyInfo[] array = fieldTypes;
                foreach (PropertyInfo fieldType in array)
                {
                    if (!fieldType.CustomAttributes.Any((CustomAttributeData r) => r.AttributeType == typeof(NotMappedAttribute))
                        && (!fieldType.PropertyType.IsGenericType || fieldType.PropertyType.Name == "Nullable`1")
                        && (!(fieldType.GetMethod != null) || !(fieldType.SetMethod == null)) && !listType.Any(r => r.Value == fieldType.PropertyType))
                    {
                        string displayName = GetDisplayName(fieldType);
                        if (string.IsNullOrEmpty(displayName))
                            displayName = GetSummary(fieldType);

                        fieldInfos.Add(new FieldInfo(baseTableName, fieldType.Name, fieldType.PropertyType, displayName));
                    }
                }
            }
        }
        List<string> updateDescriptionTSQLs = fieldInfos.Select((FieldInfo r) => r.getUpdateDescriptionTSQL()).ToList();
        string ans = string.Join("\r\n", updateDescriptionTSQLs);

        var path = Path.Combine(Directory.GetCurrentDirectory(), $"description_{DateTime.Now.ToString("yyyyMMddHHmmss")}.sql");
        File.WriteAllText(path, ans);
        return path;
    }

    public string GetDisplayName(PropertyInfo propertyInfo)
    {
        CustomAttributeData displayAttribute = propertyInfo.CustomAttributes.FirstOrDefault((CustomAttributeData r) => r.AttributeType == typeof(DisplayAttribute));
        if (displayAttribute == null)
        {
            return "";
        }
        CustomAttributeNamedArgument namedArgument = displayAttribute.NamedArguments.First((CustomAttributeNamedArgument r) => r.MemberName == "Name");
        bool flag = false;
        _ = namedArgument.TypedValue;
        if (false)
        {
            return "";
        }
        if (namedArgument.TypedValue.Value == null)
        {
            return "";
        }
        return namedArgument.TypedValue.Value.ToString();
    }
    public string GetSummary(PropertyInfo pInfio)
    {
        return pInfio.GetXmlDocsSummary();
    }
}

public class FieldInfo
{
    private string tableName { get; set; }

    private string fieldName { get; set; }

    private Type fieldType { get; set; }

    private string displayName { get; set; }

    public FieldInfo(string tableName, string fieldName, Type fieldType, string displayName)
    {
        this.tableName = tableName;
        this.fieldName = fieldName;
        this.fieldType = fieldType;
        this.displayName = displayName;
    }

    public string getDescription()
    {
        if (fieldType.IsSubclassOf(typeof(Enum)))
        {
            List<System.Reflection.FieldInfo> enumFields = fieldType.GetFields(BindingFlags.Static | BindingFlags.Public).ToList();
            List<string> strEnumFieldInfos = new List<string>();
            foreach (System.Reflection.FieldInfo enumField in enumFields)
            {
                string value = "";
                try
                {
                    value = ((int)enumField.GetValue(null)).ToString();
                }
                catch
                {
                }
                try
                {
                    value = ((byte)enumField.GetValue(null)).ToString();
                }
                catch
                {
                }
                string name = ((Enum)enumField.GetValue(null)).GetEnumName();
                strEnumFieldInfos.Add(value + "=" + name);
            }
            return displayName + " (" + string.Join(",", strEnumFieldInfos) + ")";
        }
        return displayName;
    }

    public string getUpdateDescriptionTSQL()
    {
        string template = "IF not exists(SELECT * FROM ::fn_listextendedproperty (NULL, 'user', 'dbo', 'table', '{0}', 'column', '{1}')) BEGIN exec sp_addextendedproperty 'MS_Description', '{2}', 'user', 'dbo', 'table', '{0}', 'column', '{1}' END ELSE BEGIN  exec sp_updateextendedproperty 'MS_Description', '{2}', 'user', 'dbo', 'table', '{0}', 'column', '{1}' END";
        return string.Format(template, tableName, fieldName, getDescription());
    }
}