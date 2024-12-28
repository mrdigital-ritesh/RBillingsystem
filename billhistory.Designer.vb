<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class billhistory
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
        Label26 = New Label()
        PictureBox2 = New PictureBox()
        PictureBox3 = New PictureBox()
        Label27 = New Label()
        Label2 = New Label()
        PictureBox4 = New PictureBox()
        Label24 = New Label()
        Label25 = New Label()
        Label28 = New Label()
        Panel3 = New Panel()
        Timer1 = New Timer(components)
        Panel2 = New Panel()
        btnSearch = New Button()
        txtMobileNumber = New TextBox()
        Label11 = New Label()
        txtCustomerName = New TextBox()
        Label10 = New Label()
        DataGridView1 = New DataGridView()
        Panel1 = New Panel()
        Button3 = New Button()
        Button2 = New Button()
        ComboBox1 = New ComboBox()
        Label3 = New Label()
        Label1 = New Label()
        Button4 = New Button()
        DateTimePicker2 = New DateTimePicker()
        Label9 = New Label()
        DateTimePicker1 = New DateTimePicker()
        Label8 = New Label()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox4, ComponentModel.ISupportInitialize).BeginInit()
        Panel3.SuspendLayout()
        Panel2.SuspendLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label26
        ' 
        Label26.AutoSize = True
        Label26.Font = New Font("Arial Narrow", 11.25F, FontStyle.Bold)
        Label26.Location = New Point(469, 11)
        Label26.Name = "Label26"
        Label26.Size = New Size(57, 20)
        Label26.TabIndex = 69
        Label26.Text = "Label26"
        ' 
        ' PictureBox2
        ' 
        PictureBox2.BackgroundImage = My.Resources.Resources.backbtn2
        PictureBox2.BackgroundImageLayout = ImageLayout.Zoom
        PictureBox2.Location = New Point(3, 0)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(62, 46)
        PictureBox2.TabIndex = 90
        PictureBox2.TabStop = False
        ' 
        ' PictureBox3
        ' 
        PictureBox3.BackColor = Color.Transparent
        PictureBox3.BackgroundImage = My.Resources.Resources.customers
        PictureBox3.BackgroundImageLayout = ImageLayout.Zoom
        PictureBox3.Location = New Point(330, 3)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(32, 34)
        PictureBox3.TabIndex = 73
        PictureBox3.TabStop = False
        ' 
        ' Label27
        ' 
        Label27.AutoSize = True
        Label27.Font = New Font("Arial Narrow", 11.25F, FontStyle.Bold)
        Label27.Location = New Point(695, 11)
        Label27.Name = "Label27"
        Label27.Size = New Size(57, 20)
        Label27.TabIndex = 71
        Label27.Text = "Label27"
        ' 
        ' Label2
        ' 
        Label2.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Javanese Text", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(587, 8)
        Label2.Name = "Label2"
        Label2.Size = New Size(174, 47)
        Label2.TabIndex = 45
        Label2.Text = "BILL DETAILS"
        ' 
        ' PictureBox4
        ' 
        PictureBox4.BackColor = Color.Transparent
        PictureBox4.BackgroundImage = My.Resources.Resources.calender
        PictureBox4.BackgroundImageLayout = ImageLayout.Zoom
        PictureBox4.Location = New Point(37, 7)
        PictureBox4.Name = "PictureBox4"
        PictureBox4.Size = New Size(24, 27)
        PictureBox4.TabIndex = 72
        PictureBox4.TabStop = False
        ' 
        ' Label24
        ' 
        Label24.AutoSize = True
        Label24.Font = New Font("Arial Narrow", 11.25F, FontStyle.Bold)
        Label24.Location = New Point(72, 11)
        Label24.Name = "Label24"
        Label24.Size = New Size(57, 20)
        Label24.TabIndex = 67
        Label24.Text = "Label24"
        ' 
        ' Label25
        ' 
        Label25.AutoSize = True
        Label25.Font = New Font("Arial Narrow", 11.25F, FontStyle.Bold)
        Label25.Location = New Point(371, 11)
        Label25.Name = "Label25"
        Label25.Size = New Size(57, 20)
        Label25.TabIndex = 68
        Label25.Text = "Label25"
        ' 
        ' Label28
        ' 
        Label28.AutoSize = True
        Label28.Font = New Font("Arial Narrow", 11.25F, FontStyle.Bold)
        Label28.Location = New Point(575, 11)
        Label28.Name = "Label28"
        Label28.Size = New Size(57, 20)
        Label28.TabIndex = 70
        Label28.Text = "Label28"
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = SystemColors.Control
        Panel3.Controls.Add(PictureBox3)
        Panel3.Controls.Add(Label27)
        Panel3.Controls.Add(PictureBox4)
        Panel3.Controls.Add(Label24)
        Panel3.Controls.Add(Label25)
        Panel3.Controls.Add(Label28)
        Panel3.Controls.Add(Label26)
        Panel3.Location = New Point(-7, 704)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(1410, 113)
        Panel3.TabIndex = 10
        ' 
        ' Timer1
        ' 
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.LightSeaGreen
        Panel2.Controls.Add(btnSearch)
        Panel2.Controls.Add(txtMobileNumber)
        Panel2.Controls.Add(Label11)
        Panel2.Controls.Add(txtCustomerName)
        Panel2.Controls.Add(Label10)
        Panel2.Location = New Point(10, 213)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(1350, 43)
        Panel2.TabIndex = 8
        ' 
        ' btnSearch
        ' 
        btnSearch.Font = New Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnSearch.Location = New Point(1107, 4)
        btnSearch.Name = "btnSearch"
        btnSearch.Size = New Size(39, 30)
        btnSearch.TabIndex = 88
        btnSearch.Text = "GO"
        btnSearch.UseVisualStyleBackColor = True
        ' 
        ' txtMobileNumber
        ' 
        txtMobileNumber.Font = New Font("Segoe UI", 9.75F)
        txtMobileNumber.Location = New Point(881, 9)
        txtMobileNumber.Name = "txtMobileNumber"
        txtMobileNumber.Size = New Size(138, 25)
        txtMobileNumber.TabIndex = 87
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label11.ForeColor = SystemColors.HighlightText
        Label11.Location = New Point(682, 13)
        Label11.Name = "Label11"
        Label11.Size = New Size(185, 16)
        Label11.TabIndex = 86
        Label11.Text = "SEARCH BY CUSTOMER NO:"
        ' 
        ' txtCustomerName
        ' 
        txtCustomerName.Font = New Font("Segoe UI", 9.75F)
        txtCustomerName.Location = New Point(395, 9)
        txtCustomerName.Name = "txtCustomerName"
        txtCustomerName.Size = New Size(138, 25)
        txtCustomerName.TabIndex = 85
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label10.ForeColor = SystemColors.HighlightText
        Label10.Location = New Point(181, 14)
        Label10.Name = "Label10"
        Label10.Size = New Size(203, 16)
        Label10.TabIndex = 0
        Label10.Text = "SEARCH BY CUSTOMER NAME:"
        ' 
        ' DataGridView1
        ' 
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.BackgroundColor = SystemColors.ButtonFace
        DataGridView1.BorderStyle = BorderStyle.Fixed3D
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.GridColor = SystemColors.InfoText
        DataGridView1.Location = New Point(10, 263)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.Size = New Size(1350, 434)
        DataGridView1.TabIndex = 9
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.DarkTurquoise
        Panel1.Controls.Add(Button3)
        Panel1.Controls.Add(Button2)
        Panel1.Controls.Add(ComboBox1)
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(Button4)
        Panel1.Controls.Add(PictureBox2)
        Panel1.Controls.Add(DateTimePicker2)
        Panel1.Controls.Add(Label9)
        Panel1.Controls.Add(DateTimePicker1)
        Panel1.Controls.Add(Label8)
        Panel1.Controls.Add(Label2)
        Panel1.Location = New Point(11, 11)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1348, 195)
        Panel1.TabIndex = 7
        ' 
        ' Button3
        ' 
        Button3.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Button3.BackColor = SystemColors.ButtonFace
        Button3.FlatStyle = FlatStyle.Flat
        Button3.Location = New Point(1234, 130)
        Button3.Name = "Button3"
        Button3.Size = New Size(86, 34)
        Button3.TabIndex = 95
        Button3.Text = "PRINT"
        Button3.UseVisualStyleBackColor = False
        ' 
        ' Button2
        ' 
        Button2.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Button2.BackColor = SystemColors.ButtonFace
        Button2.FlatStyle = FlatStyle.Flat
        Button2.Location = New Point(1234, 42)
        Button2.Name = "Button2"
        Button2.Size = New Size(86, 34)
        Button2.TabIndex = 94
        Button2.Text = "SEARCH"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' ComboBox1
        ' 
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New Point(487, 134)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(144, 23)
        ComboBox1.TabIndex = 93
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold)
        Label3.Location = New Point(276, 136)
        Label3.Name = "Label3"
        Label3.Size = New Size(147, 20)
        Label3.TabIndex = 92
        Label3.Text = "PAYMENT METHOD"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold)
        Label1.Location = New Point(276, 87)
        Label1.Name = "Label1"
        Label1.Size = New Size(103, 20)
        Label1.TabIndex = 91
        Label1.Text = "DATE RANGE"
        ' 
        ' Button4
        ' 
        Button4.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Button4.BackColor = SystemColors.ButtonFace
        Button4.FlatStyle = FlatStyle.Flat
        Button4.Location = New Point(1234, 86)
        Button4.Name = "Button4"
        Button4.Size = New Size(86, 34)
        Button4.TabIndex = 88
        Button4.Text = "CLEAR"
        Button4.UseVisualStyleBackColor = False
        ' 
        ' DateTimePicker2
        ' 
        DateTimePicker2.Location = New Point(841, 84)
        DateTimePicker2.Name = "DateTimePicker2"
        DateTimePicker2.Size = New Size(138, 23)
        DateTimePicker2.TabIndex = 84
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Segoe UI", 11.25F)
        Label9.Location = New Point(791, 87)
        Label9.Name = "Label9"
        Label9.Size = New Size(30, 20)
        Label9.TabIndex = 83
        Label9.Text = "TO:"
        ' 
        ' DateTimePicker1
        ' 
        DateTimePicker1.Location = New Point(558, 84)
        DateTimePicker1.Name = "DateTimePicker1"
        DateTimePicker1.Size = New Size(138, 23)
        DateTimePicker1.TabIndex = 82
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Segoe UI", 11.25F)
        Label8.Location = New Point(482, 87)
        Label8.Name = "Label8"
        Label8.Size = New Size(52, 20)
        Label8.TabIndex = 57
        Label8.Text = "FROM:"
        ' 
        ' billhistory
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1370, 749)
        Controls.Add(Panel3)
        Controls.Add(Panel2)
        Controls.Add(DataGridView1)
        Controls.Add(Panel1)
        Name = "billhistory"
        StartPosition = FormStartPosition.CenterScreen
        Text = "billhistory"
        WindowState = FormWindowState.Maximized
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox4, ComponentModel.ISupportInitialize).EndInit()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Label26 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents Label27 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents Label24 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnSearch As Button
    Friend WithEvents txtMobileNumber As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtCustomerName As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents DateTimePicker2 As DateTimePicker
    Friend WithEvents Label9 As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Label8 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button4 As Button
End Class
