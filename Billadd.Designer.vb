<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Billadd
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
        components = New ComponentModel.Container()
        Label1 = New Label()
        Panel1 = New Panel()
        PictureBox2 = New PictureBox()
        ComboBox1 = New ComboBox()
        Button6 = New Button()
        Label21 = New Label()
        Label20 = New Label()
        GroupBox1 = New GroupBox()
        DateTimePicker1 = New DateTimePicker()
        Label13 = New Label()
        TextBox10 = New TextBox()
        Label12 = New Label()
        TextBox9 = New TextBox()
        Label11 = New Label()
        TextBox8 = New TextBox()
        Label10 = New Label()
        TextBox7 = New TextBox()
        Label9 = New Label()
        TextBox6 = New TextBox()
        Label8 = New Label()
        TextBox5 = New TextBox()
        Label7 = New Label()
        TextBox4 = New TextBox()
        Label6 = New Label()
        TextBox3 = New TextBox()
        Label5 = New Label()
        TextBox2 = New TextBox()
        Label4 = New Label()
        TextBox1 = New TextBox()
        Label3 = New Label()
        pid = New TextBox()
        Label2 = New Label()
        Button4 = New Button()
        Button2 = New Button()
        Button1 = New Button()
        ListView1 = New ListView()
        Panel2 = New Panel()
        TextBox17 = New TextBox()
        Label22 = New Label()
        Button5 = New Button()
        Label19 = New Label()
        TextBox16 = New TextBox()
        TextBox15 = New TextBox()
        Label18 = New Label()
        TextBox14 = New TextBox()
        Label17 = New Label()
        TextBox13 = New TextBox()
        Label16 = New Label()
        TextBox12 = New TextBox()
        Label15 = New Label()
        TextBox11 = New TextBox()
        Label14 = New Label()
        Label24 = New Label()
        Label25 = New Label()
        Label26 = New Label()
        Timer1 = New Timer(components)
        Label27 = New Label()
        Label28 = New Label()
        PictureBox3 = New PictureBox()
        PictureBox1 = New PictureBox()
        Panel1.SuspendLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox1.SuspendLayout()
        Panel2.SuspendLayout()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Javanese Text", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(638, 10)
        Label1.Name = "Label1"
        Label1.Size = New Size(112, 47)
        Label1.TabIndex = 35
        Label1.Text = "BILLING"
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Panel1.AutoSize = True
        Panel1.BackColor = Color.DarkTurquoise
        Panel1.BorderStyle = BorderStyle.Fixed3D
        Panel1.Controls.Add(PictureBox2)
        Panel1.Controls.Add(ComboBox1)
        Panel1.Controls.Add(Button6)
        Panel1.Controls.Add(Label21)
        Panel1.Controls.Add(Label20)
        Panel1.Controls.Add(GroupBox1)
        Panel1.Controls.Add(TextBox7)
        Panel1.Controls.Add(Label9)
        Panel1.Controls.Add(TextBox6)
        Panel1.Controls.Add(Label8)
        Panel1.Controls.Add(TextBox5)
        Panel1.Controls.Add(Label7)
        Panel1.Controls.Add(TextBox4)
        Panel1.Controls.Add(Label6)
        Panel1.Controls.Add(TextBox3)
        Panel1.Controls.Add(Label5)
        Panel1.Controls.Add(TextBox2)
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(TextBox1)
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(pid)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(Button4)
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(Button2)
        Panel1.Controls.Add(Button1)
        Panel1.Location = New Point(10, 21)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1350, 287)
        Panel1.TabIndex = 18
        ' 
        ' PictureBox2
        ' 
        PictureBox2.BackgroundImage = My.Resources.Resources.backbtn2
        PictureBox2.BackgroundImageLayout = ImageLayout.Zoom
        PictureBox2.Location = New Point(-5, -3)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(62, 46)
        PictureBox2.TabIndex = 92
        PictureBox2.TabStop = False
        ' 
        ' ComboBox1
        ' 
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New Point(1123, 240)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(121, 23)
        ComboBox1.TabIndex = 61
        ' 
        ' Button6
        ' 
        Button6.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Button6.BackColor = SystemColors.ButtonFace
        Button6.FlatStyle = FlatStyle.Flat
        Button6.Font = New Font("Adobe Fan Heiti Std B", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button6.ForeColor = SystemColors.ActiveCaptionText
        Button6.Location = New Point(944, 240)
        Button6.Name = "Button6"
        Button6.Size = New Size(120, 23)
        Button6.TabIndex = 60
        Button6.Text = "HOLD BILL  (F10)"
        Button6.UseVisualStyleBackColor = False
        ' 
        ' Label21
        ' 
        Label21.AutoSize = True
        Label21.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        Label21.Location = New Point(192, 22)
        Label21.Name = "Label21"
        Label21.Size = New Size(64, 21)
        Label21.TabIndex = 59
        Label21.Text = "Label21"
        ' 
        ' Label20
        ' 
        Label20.AutoSize = True
        Label20.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        Label20.Location = New Point(96, 23)
        Label20.Name = "Label20"
        Label20.Size = New Size(67, 21)
        Label20.TabIndex = 58
        Label20.Text = "Label20"
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(DateTimePicker1)
        GroupBox1.Controls.Add(Label13)
        GroupBox1.Controls.Add(TextBox10)
        GroupBox1.Controls.Add(Label12)
        GroupBox1.Controls.Add(TextBox9)
        GroupBox1.Controls.Add(Label11)
        GroupBox1.Controls.Add(TextBox8)
        GroupBox1.Controls.Add(Label10)
        GroupBox1.Location = New Point(893, 23)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(385, 198)
        GroupBox1.TabIndex = 57
        GroupBox1.TabStop = False
        GroupBox1.Text = "Customer Details"
        ' 
        ' DateTimePicker1
        ' 
        DateTimePicker1.Location = New Point(230, 145)
        DateTimePicker1.Name = "DateTimePicker1"
        DateTimePicker1.Size = New Size(138, 23)
        DateTimePicker1.TabIndex = 81
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Font = New Font("Segoe UI", 9.75F)
        Label13.Location = New Point(40, 149)
        Label13.Name = "Label13"
        Label13.Size = New Size(53, 17)
        Label13.TabIndex = 80
        Label13.Text = "Label13"
        ' 
        ' TextBox10
        ' 
        TextBox10.Font = New Font("Segoe UI", 9.75F)
        TextBox10.Location = New Point(230, 104)
        TextBox10.Name = "TextBox10"
        TextBox10.Size = New Size(138, 25)
        TextBox10.TabIndex = 77
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Font = New Font("Segoe UI", 9.75F)
        Label12.Location = New Point(40, 112)
        Label12.Name = "Label12"
        Label12.Size = New Size(53, 17)
        Label12.TabIndex = 78
        Label12.Text = "Label12"
        ' 
        ' TextBox9
        ' 
        TextBox9.Font = New Font("Segoe UI", 9.75F)
        TextBox9.Location = New Point(230, 62)
        TextBox9.Name = "TextBox9"
        TextBox9.Size = New Size(138, 25)
        TextBox9.TabIndex = 75
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Segoe UI", 9.75F)
        Label11.Location = New Point(40, 70)
        Label11.Name = "Label11"
        Label11.Size = New Size(53, 17)
        Label11.TabIndex = 76
        Label11.Text = "Label11"
        ' 
        ' TextBox8
        ' 
        TextBox8.Font = New Font("Segoe UI", 9.75F)
        TextBox8.Location = New Point(230, 23)
        TextBox8.Name = "TextBox8"
        TextBox8.Size = New Size(138, 25)
        TextBox8.TabIndex = 73
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Segoe UI", 9.75F)
        Label10.Location = New Point(40, 31)
        Label10.Name = "Label10"
        Label10.Size = New Size(53, 17)
        Label10.TabIndex = 74
        Label10.Text = "Label10"
        ' 
        ' TextBox7
        ' 
        TextBox7.Font = New Font("Segoe UI", 9.75F)
        TextBox7.Location = New Point(648, 164)
        TextBox7.Name = "TextBox7"
        TextBox7.Size = New Size(138, 25)
        TextBox7.TabIndex = 55
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Segoe UI", 9.75F)
        Label9.Location = New Point(458, 172)
        Label9.Name = "Label9"
        Label9.Size = New Size(46, 17)
        Label9.TabIndex = 56
        Label9.Text = "Label9"
        ' 
        ' TextBox6
        ' 
        TextBox6.Font = New Font("Segoe UI", 9.75F)
        TextBox6.Location = New Point(648, 127)
        TextBox6.Name = "TextBox6"
        TextBox6.Size = New Size(138, 25)
        TextBox6.TabIndex = 53
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Segoe UI", 9.75F)
        Label8.Location = New Point(458, 135)
        Label8.Name = "Label8"
        Label8.Size = New Size(46, 17)
        Label8.TabIndex = 54
        Label8.Text = "Label8"
        ' 
        ' TextBox5
        ' 
        TextBox5.Font = New Font("Segoe UI", 9.75F)
        TextBox5.Location = New Point(648, 91)
        TextBox5.Name = "TextBox5"
        TextBox5.Size = New Size(138, 25)
        TextBox5.TabIndex = 51
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Segoe UI", 9.75F)
        Label7.Location = New Point(458, 99)
        Label7.Name = "Label7"
        Label7.Size = New Size(46, 17)
        Label7.TabIndex = 52
        Label7.Text = "Label7"
        ' 
        ' TextBox4
        ' 
        TextBox4.Font = New Font("Segoe UI", 9.75F)
        TextBox4.Location = New Point(648, 55)
        TextBox4.Name = "TextBox4"
        TextBox4.Size = New Size(138, 25)
        TextBox4.TabIndex = 49
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 9.75F)
        Label6.Location = New Point(458, 63)
        Label6.Name = "Label6"
        Label6.Size = New Size(46, 17)
        Label6.TabIndex = 50
        Label6.Text = "Label6"
        ' 
        ' TextBox3
        ' 
        TextBox3.Font = New Font("Segoe UI", 9.75F)
        TextBox3.Location = New Point(242, 164)
        TextBox3.Name = "TextBox3"
        TextBox3.Size = New Size(138, 25)
        TextBox3.TabIndex = 47
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 9.75F)
        Label5.Location = New Point(52, 172)
        Label5.Name = "Label5"
        Label5.Size = New Size(46, 17)
        Label5.TabIndex = 48
        Label5.Text = "Label5"
        ' 
        ' TextBox2
        ' 
        TextBox2.Font = New Font("Segoe UI", 9.75F)
        TextBox2.Location = New Point(242, 127)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(138, 25)
        TextBox2.TabIndex = 45
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 9.75F)
        Label4.Location = New Point(52, 135)
        Label4.Name = "Label4"
        Label4.Size = New Size(46, 17)
        Label4.TabIndex = 46
        Label4.Text = "Label4"
        ' 
        ' TextBox1
        ' 
        TextBox1.Font = New Font("Segoe UI", 9.75F)
        TextBox1.Location = New Point(242, 91)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(138, 25)
        TextBox1.TabIndex = 43
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 9.75F)
        Label3.Location = New Point(52, 99)
        Label3.Name = "Label3"
        Label3.Size = New Size(46, 17)
        Label3.TabIndex = 44
        Label3.Text = "Label3"
        ' 
        ' pid
        ' 
        pid.Font = New Font("Segoe UI", 9.75F)
        pid.Location = New Point(242, 55)
        pid.Name = "pid"
        pid.Size = New Size(138, 25)
        pid.TabIndex = 41
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 9.75F)
        Label2.Location = New Point(52, 63)
        Label2.Name = "Label2"
        Label2.Size = New Size(46, 17)
        Label2.TabIndex = 42
        Label2.Text = "Label2"
        ' 
        ' Button4
        ' 
        Button4.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Button4.BackColor = SystemColors.ButtonFace
        Button4.FlatStyle = FlatStyle.Flat
        Button4.Location = New Point(457, 229)
        Button4.Name = "Button4"
        Button4.Size = New Size(140, 34)
        Button4.TabIndex = 40
        Button4.Text = "Button4"
        Button4.UseVisualStyleBackColor = False
        ' 
        ' Button2
        ' 
        Button2.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Button2.BackColor = SystemColors.ButtonFace
        Button2.FlatStyle = FlatStyle.Flat
        Button2.Location = New Point(266, 229)
        Button2.Name = "Button2"
        Button2.Size = New Size(140, 34)
        Button2.TabIndex = 13
        Button2.Text = "Button2"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' Button1
        ' 
        Button1.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Button1.BackColor = SystemColors.ButtonFace
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Location = New Point(75, 229)
        Button1.Name = "Button1"
        Button1.Size = New Size(140, 34)
        Button1.TabIndex = 11
        Button1.Text = "Button1"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' ListView1
        ' 
        ListView1.FullRowSelect = True
        ListView1.GridLines = True
        ListView1.Location = New Point(11, 314)
        ListView1.Name = "ListView1"
        ListView1.Size = New Size(917, 391)
        ListView1.TabIndex = 19
        ListView1.UseCompatibleStateImageBehavior = False
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.DarkTurquoise
        Panel2.BorderStyle = BorderStyle.Fixed3D
        Panel2.Controls.Add(TextBox17)
        Panel2.Controls.Add(Label22)
        Panel2.Controls.Add(Button5)
        Panel2.Controls.Add(Label19)
        Panel2.Controls.Add(TextBox16)
        Panel2.Controls.Add(TextBox15)
        Panel2.Controls.Add(Label18)
        Panel2.Controls.Add(TextBox14)
        Panel2.Controls.Add(Label17)
        Panel2.Controls.Add(TextBox13)
        Panel2.Controls.Add(Label16)
        Panel2.Controls.Add(TextBox12)
        Panel2.Controls.Add(Label15)
        Panel2.Controls.Add(TextBox11)
        Panel2.Controls.Add(Label14)
        Panel2.Location = New Point(934, 303)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(426, 402)
        Panel2.TabIndex = 20
        ' 
        ' TextBox17
        ' 
        TextBox17.BackColor = SystemColors.Window
        TextBox17.Font = New Font("Segoe UI", 9.75F)
        TextBox17.Location = New Point(239, 114)
        TextBox17.Name = "TextBox17"
        TextBox17.ReadOnly = True
        TextBox17.Size = New Size(138, 25)
        TextBox17.TabIndex = 64
        ' 
        ' Label22
        ' 
        Label22.AutoSize = True
        Label22.Font = New Font("Segoe UI", 9.75F)
        Label22.Location = New Point(49, 122)
        Label22.Name = "Label22"
        Label22.Size = New Size(53, 17)
        Label22.TabIndex = 65
        Label22.Text = "Label22"
        ' 
        ' Button5
        ' 
        Button5.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Button5.BackColor = SystemColors.ButtonFace
        Button5.FlatStyle = FlatStyle.Flat
        Button5.Location = New Point(256, 333)
        Button5.Name = "Button5"
        Button5.Size = New Size(131, 34)
        Button5.TabIndex = 63
        Button5.Text = "Button5"
        Button5.UseVisualStyleBackColor = False
        ' 
        ' Label19
        ' 
        Label19.AutoSize = True
        Label19.Font = New Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label19.Location = New Point(49, 299)
        Label19.Name = "Label19"
        Label19.Size = New Size(76, 25)
        Label19.TabIndex = 62
        Label19.Text = "Label19"
        ' 
        ' TextBox16
        ' 
        TextBox16.BackColor = SystemColors.Window
        TextBox16.Font = New Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        TextBox16.ForeColor = Color.Red
        TextBox16.Location = New Point(49, 332)
        TextBox16.Multiline = True
        TextBox16.Name = "TextBox16"
        TextBox16.ReadOnly = True
        TextBox16.Size = New Size(165, 41)
        TextBox16.TabIndex = 61
        ' 
        ' TextBox15
        ' 
        TextBox15.BackColor = SystemColors.Window
        TextBox15.Font = New Font("Segoe UI", 9.75F)
        TextBox15.Location = New Point(239, 243)
        TextBox15.Name = "TextBox15"
        TextBox15.ReadOnly = True
        TextBox15.Size = New Size(138, 25)
        TextBox15.TabIndex = 59
        ' 
        ' Label18
        ' 
        Label18.AutoSize = True
        Label18.Font = New Font("Segoe UI", 9.75F)
        Label18.Location = New Point(49, 251)
        Label18.Name = "Label18"
        Label18.Size = New Size(53, 17)
        Label18.TabIndex = 60
        Label18.Text = "Label18"
        ' 
        ' TextBox14
        ' 
        TextBox14.BackColor = SystemColors.Window
        TextBox14.Font = New Font("Segoe UI", 9.75F)
        TextBox14.Location = New Point(239, 200)
        TextBox14.Name = "TextBox14"
        TextBox14.ReadOnly = True
        TextBox14.Size = New Size(138, 25)
        TextBox14.TabIndex = 57
        ' 
        ' Label17
        ' 
        Label17.AutoSize = True
        Label17.Font = New Font("Segoe UI", 9.75F)
        Label17.Location = New Point(49, 208)
        Label17.Name = "Label17"
        Label17.Size = New Size(53, 17)
        Label17.TabIndex = 58
        Label17.Text = "Label17"
        ' 
        ' TextBox13
        ' 
        TextBox13.BackColor = SystemColors.Window
        TextBox13.Font = New Font("Segoe UI", 9.75F)
        TextBox13.Location = New Point(239, 157)
        TextBox13.Name = "TextBox13"
        TextBox13.ReadOnly = True
        TextBox13.Size = New Size(138, 25)
        TextBox13.TabIndex = 55
        ' 
        ' Label16
        ' 
        Label16.AutoSize = True
        Label16.Font = New Font("Segoe UI", 9.75F)
        Label16.Location = New Point(49, 165)
        Label16.Name = "Label16"
        Label16.Size = New Size(53, 17)
        Label16.TabIndex = 56
        Label16.Text = "Label16"
        ' 
        ' TextBox12
        ' 
        TextBox12.BackColor = SystemColors.Window
        TextBox12.Font = New Font("Segoe UI", 9.75F)
        TextBox12.Location = New Point(239, 71)
        TextBox12.Name = "TextBox12"
        TextBox12.ReadOnly = True
        TextBox12.Size = New Size(138, 25)
        TextBox12.TabIndex = 53
        ' 
        ' Label15
        ' 
        Label15.AutoSize = True
        Label15.Font = New Font("Segoe UI", 9.75F)
        Label15.Location = New Point(49, 79)
        Label15.Name = "Label15"
        Label15.Size = New Size(53, 17)
        Label15.TabIndex = 54
        Label15.Text = "Label15"
        ' 
        ' TextBox11
        ' 
        TextBox11.BackColor = SystemColors.Window
        TextBox11.Font = New Font("Segoe UI", 9.75F)
        TextBox11.Location = New Point(239, 28)
        TextBox11.Name = "TextBox11"
        TextBox11.ReadOnly = True
        TextBox11.Size = New Size(138, 25)
        TextBox11.TabIndex = 51
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.Font = New Font("Segoe UI", 9.75F)
        Label14.Location = New Point(49, 36)
        Label14.Name = "Label14"
        Label14.Size = New Size(53, 17)
        Label14.TabIndex = 52
        Label14.Text = "Label14"
        ' 
        ' Label24
        ' 
        Label24.AutoSize = True
        Label24.Font = New Font("Arial Narrow", 11.25F, FontStyle.Bold)
        Label24.Location = New Point(50, 716)
        Label24.Name = "Label24"
        Label24.Size = New Size(57, 20)
        Label24.TabIndex = 60
        Label24.Text = "Label24"
        ' 
        ' Label25
        ' 
        Label25.AutoSize = True
        Label25.Font = New Font("Arial Narrow", 11.25F, FontStyle.Bold)
        Label25.Location = New Point(349, 716)
        Label25.Name = "Label25"
        Label25.Size = New Size(57, 20)
        Label25.TabIndex = 61
        Label25.Text = "Label25"
        ' 
        ' Label26
        ' 
        Label26.AutoSize = True
        Label26.Font = New Font("Arial Narrow", 11.25F, FontStyle.Bold)
        Label26.Location = New Point(447, 716)
        Label26.Name = "Label26"
        Label26.Size = New Size(57, 20)
        Label26.TabIndex = 62
        Label26.Text = "Label26"
        ' 
        ' Timer1
        ' 
        ' 
        ' Label27
        ' 
        Label27.AutoSize = True
        Label27.Font = New Font("Arial Narrow", 11.25F, FontStyle.Bold)
        Label27.Location = New Point(673, 716)
        Label27.Name = "Label27"
        Label27.Size = New Size(57, 20)
        Label27.TabIndex = 64
        Label27.Text = "Label27"
        ' 
        ' Label28
        ' 
        Label28.AutoSize = True
        Label28.Font = New Font("Arial Narrow", 11.25F, FontStyle.Bold)
        Label28.Location = New Point(553, 716)
        Label28.Name = "Label28"
        Label28.Size = New Size(57, 20)
        Label28.TabIndex = 63
        Label28.Text = "Label28"
        ' 
        ' PictureBox3
        ' 
        PictureBox3.BackColor = Color.Transparent
        PictureBox3.BackgroundImage = My.Resources.Resources.calender
        PictureBox3.BackgroundImageLayout = ImageLayout.Zoom
        PictureBox3.Location = New Point(15, 712)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(24, 27)
        PictureBox3.TabIndex = 65
        PictureBox3.TabStop = False
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.Transparent
        PictureBox1.BackgroundImage = My.Resources.Resources.customers
        PictureBox1.BackgroundImageLayout = ImageLayout.Zoom
        PictureBox1.Location = New Point(308, 708)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(32, 34)
        PictureBox1.TabIndex = 66
        PictureBox1.TabStop = False
        ' 
        ' Billadd
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1370, 749)
        Controls.Add(PictureBox1)
        Controls.Add(PictureBox3)
        Controls.Add(Label27)
        Controls.Add(Label28)
        Controls.Add(Label26)
        Controls.Add(Label25)
        Controls.Add(Label24)
        Controls.Add(ListView1)
        Controls.Add(Panel1)
        Controls.Add(Panel2)
        Name = "Billadd"
        Text = "Billadd"
        TopMost = True
        WindowState = FormWindowState.Maximized
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button4 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents pid As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox6 As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBox7 As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label13 As Label
    Friend WithEvents TextBox10 As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents TextBox9 As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents TextBox8 As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents ListView1 As ListView
    Friend WithEvents Button1 As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents PRODUCT_ID As ColumnHeader
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents TextBox15 As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents TextBox14 As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents TextBox13 As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents TextBox12 As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents TextBox11 As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents TextBox16 As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Button5 As Button
    Friend WithEvents TextBox17 As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Label27 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents Button6 As Button
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
End Class
