// DevTool 1.1 
// Copyright (C) 2024, Adaruru

using Newtonsoft.Json;

public class Languages
{
    private static string _currentLanguage = "zh_TW";
    private static Dictionary<string, Dictionary<string, string>> _languages = new Dictionary<string, Dictionary<string, string>>();
    public static string Get(string key)
    {
        if (_languages.ContainsKey(_currentLanguage) && _languages[_currentLanguage].ContainsKey(key))
        {
            return _languages[_currentLanguage][key];
        }
        return key;
    }

    public static void LoadLanguage(string? languageCode)
    {
        if (string.IsNullOrEmpty(languageCode))
        {
            languageCode = _currentLanguage;
        }
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
}