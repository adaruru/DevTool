using Properties = 

public partial class EncryptToolForm : Form
{
    public EncryptToolForm()
    {
        InitializeComponent();
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
            switch (encryptWay.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    afterBox.Text = DES.Encrypt(raw, DESKeyBox.Text, DESIvBox.Text);
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
            switch (encryptWay.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    beforeBox.Text = DES.Decrypt(raw, DESKeyBox.Text, DESIvBox.Text);
                    break;
                default:
                    errorTextLbl.Text = "未實作加密內容";
                    break;
            }
        }
    }

    private void SelectedEncryptChanged(object sender, EventArgs e)
    {
        if (encryptWay.SelectedValue is int selectedValue)
        {
            var selectedEncryption = (EncryptWayEnum)selectedValue;
            MessageBox.Show($"Selected encryption method: {selectedEncryption} selectedValue" + selectedValue);
        }
    }

    private void EncryptToolForm_Load(object sender, EventArgs e)
    {

    }

    private void setting1Box_TextChanged(object sender, EventArgs e)
    {

    }

    private void DESIvBox_TextChanged(object sender, EventArgs e)
    {
        string newDESIv = DESIvBox.Text;
        Properties.Settings.Default.DESIv = newDESIv;
        Properties.Settings.Default.Save();
    }
}