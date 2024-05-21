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

    }

    private void decryptBtnClick(object sender, EventArgs e)
    {

    }

    private void SelectedEncryptChanged(object sender, EventArgs e)
    {
        if (encryptWay.SelectedValue is int selectedValue)
        {
            var selectedEncryption = (EncryptWayEnum)selectedValue;
            MessageBox.Show($"Selected encryption method: {selectedEncryption} selectedValue"+ selectedValue);
        }
    }
}