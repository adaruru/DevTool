using System.Security.Cryptography;
using System.Text;
using Properties = EncryptTool.Properties;

public partial class EncryptToolForm : Form
{
    public EncryptToolForm()
    {
        InitializeComponent();
    }
    private void BeforeBoxChange(object sender, EventArgs e)
    {
        Properties.Settings.Default.beforeText = beforeBox.Text;
        Properties.Settings.Default.Save();
    }

    private void AfterBoxChange(object sender, EventArgs e)
    {
        Properties.Settings.Default.afterText = afterBox.Text;
        Properties.Settings.Default.Save();
    }

    private bool IsCheckKeyAndIvLength()
    {
        errorTextLbl.Text = "";
        var sKey = keyBox.Text;
        var sIv = ivBox.Text;
        var result = true;

        switch ((EncryptWayEnum)encryptWayBox.SelectedIndex)
        {
            case EncryptWayEnum.AES:
                if (sKey.Length != 16 && sKey.Length != 24 && sKey.Length != 32)
                {
                    errorTextLbl.Text = "Key 密鑰必須是16, 24, 或 32位";
                    result = false;
                }
                if (sIv.Length != 16)
                {
                    errorTextLbl.Text += " Iv 初始向量必須是16位";
                    result = false;
                }
                break;
            case EncryptWayEnum.DES_Unsafe:
                if (sKey.Length != 8)
                {
                    errorTextLbl.Text = "Key 密鑰必須是8位";
                    result = false;
                }
                if (sIv.Length != 8)
                {
                    errorTextLbl.Text += " Iv 初始向量必須是8位";
                    result = false;
                }
                break;
            case EncryptWayEnum.MD5:
            case EncryptWayEnum.SHA256:
                break;
            default:
                errorTextLbl.Text = "未實作加密內容";
                result = false;
                break;
        }
        return result;
    }
    private void EncryptClick(object sender, EventArgs e)
    {
        try
        {
            if (!IsCheckKeyAndIvLength()) return;

            var raw = beforeBox.Text;
            if (string.IsNullOrEmpty(raw))
            {
                errorTextLbl.Text = "未輸入加密前資料";
            }
            else
            {
                byte[] key = Encoding.ASCII.GetBytes(keyBox.Text);
                byte[] iv = Encoding.ASCII.GetBytes(ivBox.Text);
                switch ((EncryptWayEnum)encryptWayBox.SelectedValue)
                {
                    case EncryptWayEnum.AES:
                        afterBox.Text = AES.Encrypt(raw, key, iv, (CipherMode)CipherModeBox.SelectedValue);
                        break;
                    case EncryptWayEnum.DES_Unsafe:
                        afterBox.Text = DES.Encrypt(raw, key, iv);
                        break;
                    case EncryptWayEnum.MD5:
                        afterBox.Text = MD5.Encrypt(raw);
                        break;
                    case EncryptWayEnum.SHA256:
                        afterBox.Text = SHA256.Encrypt(raw);
                        break;
                    default:
                        errorTextLbl.Text = "未實作加密內容";
                        break;
                }
            }
        }
        catch (Exception es)
        {
            errorTextLbl.Text += $"出現其他異常錯誤:{es.Message}";
        }
    }

    private void DecryptBtnClick(object sender, EventArgs e)
    {
        try
        {
            if (!IsCheckKeyAndIvLength()) return;
            var raw = afterBox.Text;
            if (string.IsNullOrEmpty(raw))
            {
                errorTextLbl.Text = "未輸入加密後資料";
            }
            else
            {
                byte[] key = Encoding.ASCII.GetBytes(keyBox.Text);
                byte[] iv = Encoding.ASCII.GetBytes(ivBox.Text);
                switch ((EncryptWayEnum)encryptWayBox.SelectedIndex)
                {
                    case EncryptWayEnum.AES:
                        beforeBox.Text = AES.Decrypt(raw, key, iv, (CipherMode)CipherModeBox.SelectedValue);
                        break;
                    case EncryptWayEnum.DES_Unsafe:
                        beforeBox.Text = DES.Decrypt(raw, key, iv);
                        break;
                    case EncryptWayEnum.MD5:
                    case EncryptWayEnum.SHA256:
                        errorTextLbl.Text = $"{(EncryptWayEnum)encryptWayBox.SelectedIndex}雜湊法無法解密";
                        break;
                    default:
                        errorTextLbl.Text = "未實作加密內容";
                        break;
                }
            }
        }
        catch (Exception es)
        {
            errorTextLbl.Text += $"出現其他異常錯誤:{es.Message}";
        }
    }
    private void KeyBoxTextChanged(object sender, EventArgs e)
    {
        string newDESKey = keyBox.Text;
        Properties.Settings.Default.Key = newDESKey;
        Properties.Settings.Default.Save();
    }

    private void IvBox_TextChanged(object sender, EventArgs e)
    {
        Properties.Settings.Default.Iv = ivBox.Text;
        Properties.Settings.Default.Save();
    }

    private void ResetBtnClick(object sender, EventArgs e)
    {
        var result = MessageBox.Show("你確定要重置所有設定嗎", "確認重置", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        if (result == DialogResult.Yes)
        {
            Properties.Settings.Default.Reset();
            Properties.Settings.Default.Save();
            LoadSettings(); //ResetBtn
        }
    }
    private void GenKeyBtnClick(object sender, EventArgs e)
    {
        var aes = Aes.Create();
        aes.GenerateKey();
        string key;
        switch (encryptWayBox.SelectedIndex)
        {
            case 0:
                key = Convert.ToBase64String(aes.Key).Substring(0, 32);
                break;
            case 1:
                key = Convert.ToBase64String(aes.Key).Substring(0, 8);
                break;
            default:
                errorTextLbl.Text = "未實作 genKey 內容";
                return;
        }
        keyBox.Text = key;
        Properties.Settings.Default.Key = key;
        Properties.Settings.Default.Save();
    }

    private void GenIvBtnClick(object sender, EventArgs e)
    {
        var aes = Aes.Create();
        aes.GenerateIV();
        string iv;
        switch (encryptWayBox.SelectedIndex)
        {
            case 0:
                iv = Convert.ToBase64String(aes.IV).Substring(0, 16);
                break;
            case 1:
                iv = Convert.ToBase64String(aes.IV).Substring(0, 8);
                break;
            default:
                errorTextLbl.Text = "未實作 gen IV 內容";
                return;
        }
        ivBox.Text = iv;
        Properties.Settings.Default.Iv = iv;
        Properties.Settings.Default.Save();
    }
    private void SelectedEncryptChanged(object sender, EventArgs e)
    {
        var selectedValue = encryptWayBox.SelectedValue;
        Properties.Settings.Default.encryptWay = selectedValue.ToString();
        Properties.Settings.Default.Save();
        LoadCipherMode();
    }
    private void EncryptToolFormLoad(object sender, EventArgs e)
    {
        encryptWayBox.ValueMember = "Key";
        encryptWayBox.DataSource = new BindingSource(GetEnumDictionary<EncryptWayEnum>(), null);
        LoadCipherMode();
        LoadSettings(); //Form_Load 訂閱事件前先載入值
        BindEvent();
    }
    private void LoadCipherMode()
    {
        if ((EncryptWayEnum)encryptWayBox.SelectedValue == EncryptWayEnum.AES)
        {
            CipherModeBox.ValueMember = "Key";
            var dic = GetEnumDictionary<CipherMode>().Where(d => (CipherMode)d.Key != CipherMode.OFB && (CipherMode)d.Key != CipherMode.CTS); //排除 3、5
            CipherModeBox.DataSource = new BindingSource(dic, null);
        }
        else
        {
            CipherModeBox.DataSource = null;
        }
    }
    private Dictionary<int, string> GetEnumDictionary<T>() where T : Enum
    {
        var encryptionMethods = new Dictionary<int, string>();
        encryptionMethods = Enum.GetValues(typeof(T))
              .Cast<T>()
              .ToDictionary(e => Convert.ToInt32(e), e => e.ToString());
        return encryptionMethods;
    }
    private void LoadSettings()
    {
        //處理所有預設值
        encryptWayBox.SelectedValue = Convert.ToInt32(Properties.Settings.Default.encryptWay);
        ivBox.Text = Properties.Settings.Default.Iv;
        keyBox.Text = Properties.Settings.Default.Key;
        beforeBox.Text = Properties.Settings.Default.beforeText;
        afterBox.Text = Properties.Settings.Default.afterText;
    }
    private void BindEvent()
    {
        //處理所有事件
        decryptBtn.Click += DecryptBtnClick;
        encryptBtn.Click += EncryptClick;
        afterBox.TextChanged += AfterBoxChange;
        beforeBox.TextChanged += BeforeBoxChange;
        genIvBtn.Click += GenIvBtnClick;
        genKeyBtn.Click += GenKeyBtnClick;
        resetBtn.Click += ResetBtnClick;
        encryptWayBox.SelectedIndexChanged += SelectedEncryptChanged;
        keyBox.TextChanged += KeyBoxTextChanged;
    }
}