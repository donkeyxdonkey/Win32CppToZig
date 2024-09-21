namespace Win32ApiCppToZig;

partial class Main
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        TB_Output = new TextBox();
        BTN_Dump = new Button();
        TMR_Message = new System.Windows.Forms.Timer(components);
        LBL_Message = new Label();
        SuspendLayout();
        // 
        // TB_Output
        // 
        TB_Output.Font = new Font("Liberation Mono", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
        TB_Output.Location = new Point(12, 12);
        TB_Output.Margin = new Padding(0);
        TB_Output.Multiline = true;
        TB_Output.Name = "TB_Output";
        TB_Output.ReadOnly = true;
        TB_Output.Size = new Size(355, 198);
        TB_Output.TabIndex = 0;
        // 
        // BTN_Dump
        // 
        BTN_Dump.Font = new Font("Liberation Mono", 9F);
        BTN_Dump.Location = new Point(12, 210);
        BTN_Dump.Margin = new Padding(0);
        BTN_Dump.Name = "BTN_Dump";
        BTN_Dump.Size = new Size(355, 30);
        BTN_Dump.TabIndex = 1;
        BTN_Dump.Text = "Convert ClipboardText";
        BTN_Dump.UseVisualStyleBackColor = true;
        BTN_Dump.Click += BTN_Dump_Click;
        // 
        // TMR_Message
        // 
        TMR_Message.Interval = 3500;
        TMR_Message.Tick += TMR_Message_Tick;
        // 
        // LBL_Message
        // 
        LBL_Message.Anchor = AnchorStyles.Left;
        LBL_Message.Font = new Font("Liberation Mono", 9F);
        LBL_Message.ForeColor = Color.FromArgb(199, 199, 199);
        LBL_Message.Location = new Point(13, 241);
        LBL_Message.Name = "LBL_Message";
        LBL_Message.Size = new Size(355, 23);
        LBL_Message.TabIndex = 2;
        LBL_Message.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // Main
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(69, 69, 69);
        ClientSize = new Size(381, 277);
        Controls.Add(LBL_Message);
        Controls.Add(BTN_Dump);
        Controls.Add(TB_Output);
        MaximizeBox = false;
        Name = "Main";
        Text = "Win32 functions C++ to Zig";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private TextBox TB_Output;
    private Button BTN_Dump;
    private System.Windows.Forms.Timer TMR_Message;
    private Label LBL_Message;
}
