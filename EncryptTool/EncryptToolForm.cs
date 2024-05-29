using System.Security.Cryptography;
using System.Text;
using Properties = EncryptTool.Properties;

public partial class EncryptToolForm : Form
{
    public EncryptToolForm()
    {
        InitializeComponent();
        //this.Load += EncryptToolForm_Load; // 註冊載入事件處理程序
    }

    private void beforeLabelClick(object sender, EventArgs e)
    {

    }

    private void encryptTabClick(object sender, EventArgs e)
    {

    }

    private void encryptClick(object sender, EventArgs e)
    {
        var raw = beforeBox.Text;
        if (string.IsNullOrEmpty(raw))
        {
            errorTextLbl.Text = "未輸入加密前資料";
        }
        else
        {
            byte[] key = Encoding.ASCII.GetBytes(KeyBox.Text);
            byte[] iv = Encoding.ASCII.GetBytes(IvBox.Text);

            switch (encryptWayBox.SelectedIndex)
            {
                case 0:
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

    private void decryptBtnClick(object sender, EventArgs e)
    {
        var raw = afterBox.Text;
        if (string.IsNullOrEmpty(raw))
        {
            errorTextLbl.Text = "未輸入加密後資料";
        }
        else
        {
            byte[] key = Encoding.ASCII.GetBytes(KeyBox.Text);
            byte[] iv = Encoding.ASCII.GetBytes(IvBox.Text);
            switch (encryptWayBox.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    beforeBox.Text = DES.Decrypt(raw, key, iv);
                    break;
                default:
                    errorTextLbl.Text = "未實作加密內容";
                    break;
            }
        }
    }

    private void SelectedEncryptChanged(object sender, EventArgs e)
    {
        if (encryptWayBox.SelectedValue is int selectedValue)
        {
            var selectedEncryption = (EncryptWayEnum)selectedValue;
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

        LoadSettings();
    }

    private void KeyBoxTextChanged(object sender, EventArgs e)
    {
        string newDESKey = KeyBox.Text;
        Properties.Settings.Default.DESKey = newDESKey;
        Properties.Settings.Default.Save();
    }

    private void IvBox_TextChanged(object sender, EventArgs e)
    {
        Properties.Settings.Default.DESIv = IvBox.Text;
        Properties.Settings.Default.Save();
    }

    private void resetBtn_Click(object sender, EventArgs e)
    {
        var result = MessageBox.Show("你確定要重置所有設定嗎", "確認重置", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        if (result == DialogResult.Yes)
        {
            Properties.Settings.Default.Reset();
            Properties.Settings.Default.Save();
            LoadSettings();
        }
    }
    private void LoadSettings()
    {
        //處理所有預設值
        encryptWayBox.SelectedIndex = Convert.ToInt32(Properties.Settings.Default.encryptWay);
        IvBox.Text = Properties.Settings.Default.DESIv;
        KeyBox.Text = Properties.Settings.Default.DESKey;
    }

    private void genKeyBtnClick(object sender, EventArgs e)
    {
        var aes = Aes.Create();
        aes.GenerateKey();
        string key = Convert.ToBase64String(aes.Key);
        string iv = Convert.ToBase64String(aes.Key);
    }

    private void genIvBtnClick(object sender, EventArgs e)
    {
        var aes = Aes.Create();
        aes.GenerateKey();
        string key = Convert.ToBase64String(aes.Key);
        string iv = Convert.ToBase64String(aes.Key);
    }
}