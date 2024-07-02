using Newtonsoft.Json;
using System.IO;

public class LanguageManager
{
    private static Dictionary<string, Dictionary<string, string>> _languages = new Dictionary<string, Dictionary<string, string>>();
    private static string _currentLanguage = "zh_TW";  // 默認語言

    public static void LoadLanguage(string languageCode)
    {
        if (!_languages.ContainsKey(languageCode))
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Languages", $"{languageCode}.json");
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                var languageData = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                _languages[languageCode] = languageData;
            }
            else
            {
                throw new FileNotFoundException($"Language file not found: {filePath}");
            }
        }
        _currentLanguage = languageCode;
    }

    public static string GetString(string key)
    {
        if (_languages.ContainsKey(_currentLanguage) && _languages[_currentLanguage].ContainsKey(key))
        {
            return _languages[_currentLanguage][key];
        }
        return key;  // 如果找不到翻譯，返回鍵名
    }

    public static void ChangeLanguage(string languageCode)
    {
        LoadLanguage(languageCode);
    }
}