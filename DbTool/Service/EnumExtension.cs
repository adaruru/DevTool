using System.ComponentModel.DataAnnotations;
using System.Resources;

public static class EnumExtensions
{
    public static string GetEnumName(this Enum e)
    {
        if (e == null)
        {
            return string.Empty;
        }

        DisplayAttribute displayAttribute = ((DisplayAttribute[])e.GetType().GetField(e.ToString()).GetCustomAttributes(typeof(DisplayAttribute), inherit: false)).FirstOrDefault();
        if (displayAttribute == null)
        {
            return string.Empty;
        }

        DisplayAttribute displayAttribute2 = displayAttribute;
        if (displayAttribute2.ResourceType == null)
        {
            return displayAttribute.Name;
        }

        ResourceManager resourceManager = new ResourceManager(displayAttribute2.ResourceType.FullName, displayAttribute2.ResourceType.GetType().Assembly);
        return resourceManager.GetString(displayAttribute2.Name);
    }

    public static string ToValueString(this Enum e)
    {
        if (e == null)
        {
            return "";
        }

        object obj = Enum.Parse(e.GetType(), e.ToString());
        try
        {
            return ((int)obj).ToString();
        }
        catch
        {
        }

        try
        {
            return ((byte)obj).ToString();
        }
        catch
        {
        }

        throw new Exception("轉換失敗");
    }

    public static string GetEnumGroupName(this Enum e)
    {
        if (e == null)
        {
            return string.Empty;
        }

        DisplayAttribute[] array = (DisplayAttribute[])e.GetType().GetField(e.ToString()).GetCustomAttributes(typeof(DisplayAttribute), inherit: false);
        return (array.Length != 0) ? array[0].GroupName : string.Empty;
    }

    public static string GetEnumDescription(this Enum e)
    {
        if (e == null)
        {
            return string.Empty;
        }

        DisplayAttribute[] array = (DisplayAttribute[])e.GetType().GetField(e.ToString()).GetCustomAttributes(typeof(DisplayAttribute), inherit: false);
        return (array.Length != 0) ? array[0].Description : string.Empty;
    }

    public static string GetEnumShortName(this Enum e)
    {
        if (e == null)
        {
            return string.Empty;
        }

        DisplayAttribute[] array = (DisplayAttribute[])e.GetType().GetField(e.ToString()).GetCustomAttributes(typeof(DisplayAttribute), inherit: false);
        return (array.Length != 0) ? array[0].ShortName : string.Empty;
    }

    //public static T GetAttribute<T>(this Enum e) where T : Attribute
    //{
    //    System.Reflection.FieldInfo[] fields = e.GetType().GetFields();
    //    System.Reflection.FieldInfo[] array = fields;
    //    foreach (FieldInfo fieldInfo in array)
    //    {
    //        T val = (T)Attribute.GetCustomAttribute(fieldInfo, typeof(T));
    //        if (val != null && fieldInfo.Name == e.ToString())
    //        {
    //            return val;
    //        }
    //    }

    //    return null;
    //}
}
