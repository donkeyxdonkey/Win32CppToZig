using PrintDriveToTxt;
using System.Text;

namespace Win32ApiCppToZig;

public partial class Main : Form
{
    public Main()
    {
        InitializeComponent();
    }

    private void BTN_Dump_Click(object sender, EventArgs e)
    {
        if (!Clipboard.ContainsText())
        {
            ShowMessage("Clipboard does not contain any text");
            return;
        }

        ConvertClipboardText(Clipboard.GetText());
    }

    private static readonly char[] junk = [' ', '(', ')', '[', ']', ','];
    const string OPTIONAL = "optional";

    private void ConvertClipboardText(string text)
    {
        string[] tokens = text
            .Replace("\r\n", " ").Replace("\n", " ").Trim()
            .Split(junk, StringSplitOptions.RemoveEmptyEntries)
            .Where(x => x != "in" && x != "out")
            .ToArray();

        Dictionary<string, string> typeMap = LoadConfig();

        string returnType = tokens[0];
        string functionName = tokens[1];
        StringBuilder zigFunction = new($"pub extern \"\" fn {functionName}(");

        string dataType = string.Empty;
        bool isDataType = true;
        bool isOptional = false;

        try
        {
            for (int i = 2; i < tokens.Length; i++)
            {
                if (tokens[i] == OPTIONAL)
                {
                    isOptional = true;
                    continue;
                }

                switch (isDataType)
                {
                    case true:
                        dataType = $"{(isOptional ? "?" : "")}{(typeMap.TryGetValue(tokens[i], out string? value) ? value : tokens[i])}";
                        break;
                    case false:
                        string param = tokens[i];

                        zigFunction.Append($"{param}: {dataType}, ");
                        break;
                }

                isDataType = !isDataType;
                isOptional = false;
            }
            zigFunction.Length -= 2;
            zigFunction.Append($") callconv(WINAPI) {returnType};");

            TB_Output.Text = zigFunction.ToString();
            Clipboard.SetText(TB_Output.Text);
            ShowMessage("Conversion copied to clipboard");
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

    private void ShowMessage(string message)
    {
        TMR_Message.Start();
        LBL_Message.Text = message;
    }

    private void TMR_Message_Tick(object sender, EventArgs e)
    {
        TMR_Message.Stop();
        LBL_Message.Text = string.Empty;
    }

    private static Dictionary<string, string> LoadConfig()
    {
        try
        {
            FileInfo configPath = new(Path.Combine(AppContext.BaseDirectory, "config.yaml"));
            Config config = YamlParser.ParseConfig<Config>(configPath);
            return config.GetMap();
        }
        catch (Exception)
        {
            throw new ArgumentException("Invalid config provided");
        }
    }
}
