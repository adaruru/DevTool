using System.Buffers.Text;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Properties = EncryptTool.Properties;

public partial class EncryptToolForm : Form
{
    public EncryptToolForm()
    {
        InitializeComponent();
        //this.Load += EncryptToolForm_Load; // 註冊載入事件處理程序
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

    private void EncryptClick(object sender, EventArgs e)
    {
        errorTextLbl.Text = "";
        var raw = beforeBox.Text;
        if (string.IsNullOrEmpty(raw))
        {
            errorTextLbl.Text = "未輸入加密前資料";
        }
        else
        {
            var sKey = keyBox.Text;
            var sIv = ivBox.Text;
            byte[] key = Encoding.ASCII.GetBytes(sKey);
            byte[] iv = Encoding.ASCII.GetBytes(sIv);

            switch (encryptWayBox.SelectedIndex)
            {
                case 0:
                    if (sKey.Length < 16)
                    {
                        errorTextLbl.Text = "Key 密鑰小於16位";
                    }
                    if (sIv.Length < 16)
                    {
                        errorTextLbl.Text += "Iv 初始向量小於16位";
                    }
                    if (sKey.Length < 16 || sIv.Length < 16)
                    {
                        return;
                    }

                    afterBox.Text = AES.Encrypt(raw, key, iv, (CipherMode)CipherModeBox.SelectedValue);
                    break;
                case 1:
                    afterBox.Text = DES.Encrypt(raw, key, iv);
                    break;
                default:
                    errorTextLbl.Text = "未實作加密內容";
                    break;
            }
        }
    }

    private void DecryptBtnClick(object sender, EventArgs e)
    {
        errorTextLbl.Text = "";
        var raw = afterBox.Text;
        if (string.IsNullOrEmpty(raw))
        {
            errorTextLbl.Text = "未輸入加密後資料";
        }
        else
        {
            var sKey = keyBox.Text;
            var sIv = ivBox.Text;
            byte[] key = Encoding.ASCII.GetBytes(sKey);
            byte[] iv = Encoding.ASCII.GetBytes(sIv);

            switch (encryptWayBox.SelectedIndex)
            {
                case 0:
                    if (sKey.Length != 16 && sKey.Length != 24 && sKey.Length != 32)
                    {
                        errorTextLbl.Text = "Key 密鑰必須是16, 24, 或 32位";
                    }
                    if (sIv.Length != 16)
                    {
                        errorTextLbl.Text += " Iv 初始向量必須是16位";
                    }
                    if (sKey.Length != 16 && sKey.Length != 24 && sKey.Length != 32 || sIv.Length != 16)
                    {
                        return;
                    }
                    beforeBox.Text = AES.Decrypt(raw, key, iv, (CipherMode)CipherModeBox.SelectedValue);
                    break;
                case 1:
                    if (sKey.Length != 8)
                    {
                        errorTextLbl.Text = "Key 密鑰必須是8位";
                    }
                    if (sIv.Length != 8)
                    {
                        errorTextLbl.Text += " Iv 初始向量必須是8位";
                    }
                    if (sKey.Length != 8 || sIv.Length != 8)
                    {
                        return;
                    }
                    beforeBox.Text = DES.Decrypt(raw, key, iv);
                    break;
                default:
                    errorTextLbl.Text = "未實作加密內容";
                    break;
            }
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
            LoadSettings();
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
        if ((EncryptWayEnum)encryptWayBox.SelectedValue == EncryptWayEnum.AES)
        {
            CipherModeBox.ValueMember = "Key";
            CipherModeBox.DataSource = new BindingSource(GetEnumDictionary<CipherMode>(), null);
        }
        else
        {
            CipherModeBox.DataSource = null;
        }
    }
    private void EncryptToolForm_Load(object sender, EventArgs e)
    {
        encryptWayBox.ValueMember = "Key";
        encryptWayBox.DataSource = new BindingSource(GetEnumDictionary<EncryptWayEnum>(), null);
        if ((EncryptWayEnum)encryptWayBox.SelectedValue != EncryptWayEnum.AES)
        {
            CipherModeBox.ValueMember = "Key";
            CipherModeBox.DataSource = new BindingSource(GetEnumDictionary<CipherMode>(), null);
        }
        LoadSettings(); //訂閱事件前先載入值
        BindEvent();
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