namespace CodeGenerator.Main;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    private void buttonShowCommandGeneratorForm_Click(object sender, EventArgs e)
    {
        new CommandGeneratorForm().ShowDialog();
    }
}