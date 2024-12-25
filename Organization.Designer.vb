<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Organization
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Panel1 = New Panel()
        Panel2 = New Panel()
        PictureBox1 = New PictureBox()
        Button2 = New Button()
        GroupBox3 = New GroupBox()
        TextBoxland = New TextBox()
        Label8 = New Label()
        Label9 = New Label()
        TextBoxmail = New TextBox()
        TextBoxmobile = New TextBox()
        Label10 = New Label()
        closebt = New PictureBox()
        GroupBox2 = New GroupBox()
        TextBoxcity = New TextBox()
        Label13 = New Label()
        TextBoxstate = New TextBox()
        Label12 = New Label()
        TextBoxcountry = New TextBox()
        Label11 = New Label()
        TextBoxgst = New TextBox()
        Label4 = New Label()
        TextBoxbranch = New TextBox()
        Label3 = New Label()
        Textboxname = New TextBox()
        Label1 = New Label()
        GroupBox1 = New GroupBox()
        TextBoxifsc = New TextBox()
        Label7 = New Label()
        Label5 = New Label()
        TextBoxacc = New TextBox()
        TextBoxbank = New TextBox()
        Label6 = New Label()
        Button1 = New Button()
        Label2 = New Label()
        MySqlCommand1 = New MySql.Data.MySqlClient.MySqlCommand()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox3.SuspendLayout()
        CType(closebt, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox2.SuspendLayout()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(Panel2)
        Panel1.Controls.Add(Button2)
        Panel1.Controls.Add(GroupBox3)
        Panel1.Controls.Add(closebt)
        Panel1.Controls.Add(GroupBox2)
        Panel1.Controls.Add(GroupBox1)
        Panel1.Controls.Add(Button1)
        Panel1.Controls.Add(Label2)
        Panel1.Location = New Point(10, 11)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(861, 517)
        Panel1.TabIndex = 71
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = SystemColors.Desktop
        Panel2.Controls.Add(PictureBox1)
        Panel2.Location = New Point(22, 62)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(148, 139)
        Panel2.TabIndex = 79
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = SystemColors.ControlText
        PictureBox1.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox1.InitialImage = My.Resources.Resources.comapanydefault
        PictureBox1.Location = New Point(3, 1)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(143, 136)
        PictureBox1.TabIndex = 72
        PictureBox1.TabStop = False
        ' 
        ' Button2
        ' 
        Button2.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button2.Location = New Point(706, 466)
        Button2.Name = "Button2"
        Button2.Size = New Size(108, 40)
        Button2.TabIndex = 78
        Button2.Text = "SAVE"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' GroupBox3
        ' 
        GroupBox3.BackColor = Color.Transparent
        GroupBox3.Controls.Add(TextBoxland)
        GroupBox3.Controls.Add(Label8)
        GroupBox3.Controls.Add(Label9)
        GroupBox3.Controls.Add(TextBoxmail)
        GroupBox3.Controls.Add(TextBoxmobile)
        GroupBox3.Controls.Add(Label10)
        GroupBox3.Font = New Font("Segoe UI Semibold", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        GroupBox3.Location = New Point(453, 253)
        GroupBox3.Name = "GroupBox3"
        GroupBox3.Size = New Size(376, 198)
        GroupBox3.TabIndex = 77
        GroupBox3.TabStop = False
        GroupBox3.Text = "CONTACT"
        ' 
        ' TextBoxland
        ' 
        TextBoxland.Font = New Font("Segoe UI", 9.75F)
        TextBoxland.Location = New Point(174, 144)
        TextBoxland.Name = "TextBoxland"
        TextBoxland.Size = New Size(169, 25)
        TextBoxland.TabIndex = 57
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Arial", 9.75F)
        Label8.Location = New Point(26, 35)
        Label8.Name = "Label8"
        Label8.Size = New Size(50, 16)
        Label8.TabIndex = 54
        Label8.Text = "EMAIL:"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Arial", 9.75F)
        Label9.Location = New Point(26, 152)
        Label9.Name = "Label9"
        Label9.Size = New Size(96, 16)
        Label9.TabIndex = 58
        Label9.Text = "LANDLINE NO."
        ' 
        ' TextBoxmail
        ' 
        TextBoxmail.Font = New Font("Segoe UI", 9.75F)
        TextBoxmail.Location = New Point(174, 27)
        TextBoxmail.Name = "TextBoxmail"
        TextBoxmail.Size = New Size(169, 25)
        TextBoxmail.TabIndex = 53
        ' 
        ' TextBoxmobile
        ' 
        TextBoxmobile.Font = New Font("Segoe UI", 9.75F)
        TextBoxmobile.Location = New Point(174, 82)
        TextBoxmobile.Name = "TextBoxmobile"
        TextBoxmobile.Size = New Size(169, 25)
        TextBoxmobile.TabIndex = 55
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Arial", 9.75F)
        Label10.Location = New Point(26, 90)
        Label10.Name = "Label10"
        Label10.Size = New Size(83, 16)
        Label10.TabIndex = 56
        Label10.Text = "MOBILE NO:"
        ' 
        ' closebt
        ' 
        closebt.BackColor = Color.Transparent
        closebt.BackgroundImage = My.Resources.Resources.close
        closebt.BackgroundImageLayout = ImageLayout.Stretch
        closebt.Location = New Point(814, 8)
        closebt.Name = "closebt"
        closebt.Size = New Size(35, 35)
        closebt.TabIndex = 71
        closebt.TabStop = False
        ' 
        ' GroupBox2
        ' 
        GroupBox2.BackColor = Color.Transparent
        GroupBox2.Controls.Add(TextBoxcity)
        GroupBox2.Controls.Add(Label13)
        GroupBox2.Controls.Add(TextBoxstate)
        GroupBox2.Controls.Add(Label12)
        GroupBox2.Controls.Add(TextBoxcountry)
        GroupBox2.Controls.Add(Label11)
        GroupBox2.Controls.Add(TextBoxgst)
        GroupBox2.Controls.Add(Label4)
        GroupBox2.Controls.Add(TextBoxbranch)
        GroupBox2.Controls.Add(Label3)
        GroupBox2.Controls.Add(Textboxname)
        GroupBox2.Controls.Add(Label1)
        GroupBox2.Font = New Font("Segoe UI Semibold", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        GroupBox2.Location = New Point(188, 62)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New Size(647, 171)
        GroupBox2.TabIndex = 76
        GroupBox2.TabStop = False
        GroupBox2.Text = "COMPANY DETAILS"
        ' 
        ' TextBoxcity
        ' 
        TextBoxcity.Font = New Font("Segoe UI", 9.75F)
        TextBoxcity.Location = New Point(502, 123)
        TextBoxcity.Name = "TextBoxcity"
        TextBoxcity.Size = New Size(124, 25)
        TextBoxcity.TabIndex = 63
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Font = New Font("Arial", 9.75F)
        Label13.Location = New Point(406, 127)
        Label13.Name = "Label13"
        Label13.Size = New Size(38, 16)
        Label13.TabIndex = 64
        Label13.Text = "CITY:"
        ' 
        ' TextBoxstate
        ' 
        TextBoxstate.Font = New Font("Segoe UI", 9.75F)
        TextBoxstate.Location = New Point(502, 76)
        TextBoxstate.Name = "TextBoxstate"
        TextBoxstate.Size = New Size(124, 25)
        TextBoxstate.TabIndex = 61
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Font = New Font("Arial", 9.75F)
        Label12.Location = New Point(406, 80)
        Label12.Name = "Label12"
        Label12.Size = New Size(50, 16)
        Label12.TabIndex = 62
        Label12.Text = "STATE:"
        ' 
        ' TextBoxcountry
        ' 
        TextBoxcountry.Font = New Font("Segoe UI", 9.75F)
        TextBoxcountry.Location = New Point(502, 33)
        TextBoxcountry.Name = "TextBoxcountry"
        TextBoxcountry.Size = New Size(124, 25)
        TextBoxcountry.TabIndex = 59
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Arial", 9.75F)
        Label11.Location = New Point(406, 37)
        Label11.Name = "Label11"
        Label11.Size = New Size(72, 16)
        Label11.TabIndex = 60
        Label11.Text = "COUNTRY:"
        ' 
        ' TextBoxgst
        ' 
        TextBoxgst.Font = New Font("Segoe UI", 9.75F)
        TextBoxgst.Location = New Point(169, 123)
        TextBoxgst.Name = "TextBoxgst"
        TextBoxgst.Size = New Size(161, 25)
        TextBoxgst.TabIndex = 57
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Arial", 9.75F)
        Label4.Location = New Point(21, 131)
        Label4.Name = "Label4"
        Label4.Size = New Size(49, 16)
        Label4.TabIndex = 58
        Label4.Text = "GSTIN:"
        ' 
        ' TextBoxbranch
        ' 
        TextBoxbranch.Font = New Font("Segoe UI", 9.75F)
        TextBoxbranch.Location = New Point(169, 77)
        TextBoxbranch.Name = "TextBoxbranch"
        TextBoxbranch.Size = New Size(161, 25)
        TextBoxbranch.TabIndex = 55
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Arial", 9.75F)
        Label3.Location = New Point(21, 85)
        Label3.Name = "Label3"
        Label3.Size = New Size(65, 16)
        Label3.TabIndex = 56
        Label3.Text = "BRANCH:"
        ' 
        ' Textboxname
        ' 
        Textboxname.Font = New Font("Segoe UI", 9.75F)
        Textboxname.Location = New Point(169, 34)
        Textboxname.Name = "Textboxname"
        Textboxname.Size = New Size(161, 25)
        Textboxname.TabIndex = 53
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Arial", 9.75F)
        Label1.Location = New Point(21, 42)
        Label1.Name = "Label1"
        Label1.Size = New Size(119, 16)
        Label1.TabIndex = 54
        Label1.Text = "BUSINESS NAME:"
        ' 
        ' GroupBox1
        ' 
        GroupBox1.BackColor = Color.Transparent
        GroupBox1.Controls.Add(TextBoxifsc)
        GroupBox1.Controls.Add(Label7)
        GroupBox1.Controls.Add(Label5)
        GroupBox1.Controls.Add(TextBoxacc)
        GroupBox1.Controls.Add(TextBoxbank)
        GroupBox1.Controls.Add(Label6)
        GroupBox1.Font = New Font("Segoe UI Semibold", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        GroupBox1.Location = New Point(33, 253)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(376, 198)
        GroupBox1.TabIndex = 75
        GroupBox1.TabStop = False
        GroupBox1.Text = "BANK DETAILS"
        ' 
        ' TextBoxifsc
        ' 
        TextBoxifsc.Font = New Font("Segoe UI", 9.75F)
        TextBoxifsc.Location = New Point(174, 143)
        TextBoxifsc.Name = "TextBoxifsc"
        TextBoxifsc.Size = New Size(169, 25)
        TextBoxifsc.TabIndex = 57
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Arial", 9.75F)
        Label7.Location = New Point(26, 35)
        Label7.Name = "Label7"
        Label7.Size = New Size(96, 16)
        Label7.TabIndex = 54
        Label7.Text = "ACCOUNT NO:"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Arial", 9.75F)
        Label5.Location = New Point(26, 151)
        Label5.Name = "Label5"
        Label5.Size = New Size(81, 16)
        Label5.TabIndex = 58
        Label5.Text = "IFSC CODE:"
        ' 
        ' TextBoxacc
        ' 
        TextBoxacc.Font = New Font("Segoe UI", 9.75F)
        TextBoxacc.Location = New Point(174, 27)
        TextBoxacc.Name = "TextBoxacc"
        TextBoxacc.Size = New Size(169, 25)
        TextBoxacc.TabIndex = 53
        ' 
        ' TextBoxbank
        ' 
        TextBoxbank.Font = New Font("Segoe UI", 9.75F)
        TextBoxbank.Location = New Point(174, 82)
        TextBoxbank.Name = "TextBoxbank"
        TextBoxbank.Size = New Size(169, 25)
        TextBoxbank.TabIndex = 55
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Arial", 9.75F)
        Label6.Location = New Point(26, 90)
        Label6.Name = "Label6"
        Label6.Size = New Size(89, 16)
        Label6.TabIndex = 56
        Label6.Text = "BANK NAME:"
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(57, 210)
        Button1.Name = "Button1"
        Button1.Size = New Size(75, 23)
        Button1.TabIndex = 74
        Button1.Text = "Button1"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(377, 21)
        Label2.Name = "Label2"
        Label2.Size = New Size(161, 22)
        Label2.TabIndex = 73
        Label2.Text = "ORGANIZATION"
        ' 
        ' MySqlCommand1
        ' 
        MySqlCommand1.CacheAge = 0
        MySqlCommand1.Connection = Nothing
        MySqlCommand1.EnableCaching = False
        MySqlCommand1.Transaction = Nothing
        ' 
        ' Organization
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(880, 539)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.None
        KeyPreview = True
        Name = "Organization"
        ShowInTaskbar = False
        SizeGripStyle = SizeGripStyle.Hide
        StartPosition = FormStartPosition.CenterScreen
        Text = "Organization"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        GroupBox3.ResumeLayout(False)
        GroupBox3.PerformLayout()
        CType(closebt, ComponentModel.ISupportInitialize).EndInit()
        GroupBox2.ResumeLayout(False)
        GroupBox2.PerformLayout()
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button2 As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents TextBoxland As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents TextBoxmail As TextBox
    Friend WithEvents TextBoxmobile As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents closebt As PictureBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents TextBoxcity As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents TextBoxstate As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents TextBoxcountry As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents TextBoxgst As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBoxbranch As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Textboxname As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TextBoxifsc As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TextBoxacc As TextBox
    Friend WithEvents TextBoxbank As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents MySqlCommand1 As MySql.Data.MySqlClient.MySqlCommand
    Friend WithEvents Panel2 As Panel
End Class
