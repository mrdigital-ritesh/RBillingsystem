<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class loginform

    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        MySqlCommand1 = New MySql.Data.MySqlClient.MySqlCommand()
        backbt = New PictureBox()
        closebt = New PictureBox()
        Panel1 = New Panel()
        Panel2 = New Panel()
        Label4 = New Label()
        PictureBox3 = New PictureBox()
        TextBox3 = New TextBox()
        PictureBox1 = New PictureBox()
        PictureBox2 = New PictureBox()
        Button1 = New Button()
        Label3 = New Label()
        Loginbtn = New Button()
        TextBox2 = New TextBox()
        Label2 = New Label()
        TextBox1 = New TextBox()
        Label1 = New Label()
        PictureBox4 = New PictureBox()
        loginlabel = New Label()
        CType(backbt, ComponentModel.ISupportInitialize).BeginInit()
        CType(closebt, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox4, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' MySqlCommand1
        ' 
        MySqlCommand1.CacheAge = 0
        MySqlCommand1.Connection = Nothing
        MySqlCommand1.EnableCaching = False
        MySqlCommand1.Transaction = Nothing
        ' 
        ' backbt
        ' 
        backbt.BackColor = Color.Transparent
        backbt.BackgroundImage = My.Resources.Resources.previous
        backbt.BackgroundImageLayout = ImageLayout.Stretch
        backbt.Location = New Point(786, 8)
        backbt.Name = "backbt"
        backbt.Size = New Size(35, 35)
        backbt.TabIndex = 4
        backbt.TabStop = False
        ' 
        ' closebt
        ' 
        closebt.BackColor = Color.Transparent
        closebt.BackgroundImage = My.Resources.Resources.close
        closebt.BackgroundImageLayout = ImageLayout.Stretch
        closebt.Location = New Point(828, 8)
        closebt.Name = "closebt"
        closebt.Size = New Size(35, 35)
        closebt.TabIndex = 3
        closebt.TabStop = False
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = SystemColors.MenuBar
        Panel1.Controls.Add(PictureBox2)
        Panel1.Controls.Add(Button1)
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(Loginbtn)
        Panel1.Controls.Add(TextBox2)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(TextBox1)
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(PictureBox4)
        Panel1.Location = New Point(148, 97)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(574, 336)
        Panel1.TabIndex = 5
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.White
        Panel2.BorderStyle = BorderStyle.Fixed3D
        Panel2.Controls.Add(Label4)
        Panel2.Controls.Add(PictureBox3)
        Panel2.Controls.Add(TextBox3)
        Panel2.Controls.Add(PictureBox1)
        Panel2.Location = New Point(198, 94)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(474, 293)
        Panel2.TabIndex = 7
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Arial", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(178, 247)
        Label4.Name = "Label4"
        Label4.Size = New Size(172, 17)
        Label4.TabIndex = 8
        Label4.Text = "Please Scan Your Card..."
        ' 
        ' PictureBox3
        ' 
        PictureBox3.Image = My.Resources.Resources.scangif
        PictureBox3.Location = New Point(96, 17)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(279, 255)
        PictureBox3.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox3.TabIndex = 7
        PictureBox3.TabStop = False
        ' 
        ' TextBox3
        ' 
        TextBox3.BorderStyle = BorderStyle.None
        TextBox3.ForeColor = Color.Transparent
        TextBox3.Location = New Point(342, 244)
        TextBox3.Name = "TextBox3"
        TextBox3.Size = New Size(0, 16)
        TextBox3.TabIndex = 6
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.Transparent
        PictureBox1.BackgroundImage = My.Resources.Resources.previous
        PictureBox1.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox1.Location = New Point(441, 7)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(25, 25)
        PictureBox1.TabIndex = 5
        PictureBox1.TabStop = False
        ' 
        ' PictureBox2
        ' 
        PictureBox2.BackColor = Color.Transparent
        PictureBox2.BackgroundImage = My.Resources.Resources.rfid
        PictureBox2.BackgroundImageLayout = ImageLayout.Zoom
        PictureBox2.Location = New Point(328, 282)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(38, 25)
        PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox2.TabIndex = 8
        PictureBox2.TabStop = False
        ' 
        ' Button1
        ' 
        Button1.Font = New Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button1.Location = New Point(191, 275)
        Button1.Name = "Button1"
        Button1.Size = New Size(193, 38)
        Button1.TabIndex = 6
        Button1.Text = "USE RFID"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(267, 246)
        Label3.Name = "Label3"
        Label3.Size = New Size(41, 15)
        Label3.TabIndex = 5
        Label3.Text = "Label3"
        ' 
        ' Loginbtn
        ' 
        Loginbtn.Font = New Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Loginbtn.Location = New Point(226, 193)
        Loginbtn.Name = "Loginbtn"
        Loginbtn.Size = New Size(123, 38)
        Loginbtn.TabIndex = 4
        Loginbtn.Text = "SIGN IN"
        Loginbtn.UseVisualStyleBackColor = True
        ' 
        ' TextBox2
        ' 
        TextBox2.Font = New Font("Segoe UI", 12F)
        TextBox2.Location = New Point(303, 117)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(180, 29)
        TextBox2.TabIndex = 3
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        Label2.Location = New Point(91, 120)
        Label2.Name = "Label2"
        Label2.Size = New Size(99, 21)
        Label2.TabIndex = 2
        Label2.Text = "PASSWORD:"
        ' 
        ' TextBox1
        ' 
        TextBox1.Font = New Font("Segoe UI", 12F)
        TextBox1.Location = New Point(303, 53)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(180, 29)
        TextBox1.TabIndex = 1
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        Label1.Location = New Point(91, 56)
        Label1.Name = "Label1"
        Label1.Size = New Size(72, 21)
        Label1.TabIndex = 0
        Label1.Text = "USER ID:"
        ' 
        ' PictureBox4
        ' 
        PictureBox4.Image = My.Resources.Resources.show
        PictureBox4.Location = New Point(492, 121)
        PictureBox4.Name = "PictureBox4"
        PictureBox4.Size = New Size(24, 21)
        PictureBox4.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox4.TabIndex = 9
        PictureBox4.TabStop = False
        ' 
        ' loginlabel
        ' 
        loginlabel.AutoSize = True
        loginlabel.BackColor = Color.Transparent
        loginlabel.Font = New Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        loginlabel.Location = New Point(359, 32)
        loginlabel.Name = "loginlabel"
        loginlabel.Size = New Size(153, 40)
        loginlabel.TabIndex = 6
        loginlabel.Text = "loginlabel" & vbCrLf
        ' 
        ' loginform
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(870, 481)
        Controls.Add(Panel2)
        Controls.Add(loginlabel)
        Controls.Add(Panel1)
        Controls.Add(backbt)
        Controls.Add(closebt)
        FormBorderStyle = FormBorderStyle.None
        Name = "loginform"
        StartPosition = FormStartPosition.CenterScreen
        Text = "loginform"
        TopMost = True
        CType(backbt, ComponentModel.ISupportInitialize).EndInit()
        CType(closebt, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox4, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents MySqlCommand1 As MySql.Data.MySqlClient.MySqlCommand
    Friend WithEvents backbt As PictureBox
    Friend WithEvents closebt As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents loginlabel As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Loginbtn As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents Label4 As Label
    Friend WithEvents PictureBox4 As PictureBox
End Class
