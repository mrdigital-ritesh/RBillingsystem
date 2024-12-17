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
        Loginbtn = New Button()
        TextBox2 = New TextBox()
        Label2 = New Label()
        TextBox1 = New TextBox()
        Label1 = New Label()
        loginlabel = New Label()
        CType(backbt, ComponentModel.ISupportInitialize).BeginInit()
        CType(closebt, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
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
        Panel1.Controls.Add(Loginbtn)
        Panel1.Controls.Add(TextBox2)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(TextBox1)
        Panel1.Controls.Add(Label1)
        Panel1.Location = New Point(148, 146)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(574, 252)
        Panel1.TabIndex = 5
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
        TextBox2.Location = New Point(281, 114)
        TextBox2.Multiline = True
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(180, 31)
        TextBox2.TabIndex = 3
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        Label2.Location = New Point(68, 124)
        Label2.Name = "Label2"
        Label2.Size = New Size(99, 21)
        Label2.TabIndex = 2
        Label2.Text = "PASSWORD:"
        ' 
        ' TextBox1
        ' 
        TextBox1.Font = New Font("Segoe UI", 12F)
        TextBox1.Location = New Point(281, 46)
        TextBox1.Multiline = True
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(180, 35)
        TextBox1.TabIndex = 1
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        Label1.Location = New Point(68, 60)
        Label1.Name = "Label1"
        Label1.Size = New Size(72, 21)
        Label1.TabIndex = 0
        Label1.Text = "USER ID:"
        ' 
        ' loginlabel
        ' 
        loginlabel.AutoSize = True
        loginlabel.BackColor = Color.Transparent
        loginlabel.Font = New Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        loginlabel.Location = New Point(391, 73)
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
        Controls.Add(loginlabel)
        Controls.Add(Panel1)
        Controls.Add(backbt)
        Controls.Add(closebt)
        FormBorderStyle = FormBorderStyle.None
        Name = "loginform"
        StartPosition = FormStartPosition.CenterScreen
        Text = "loginform"
        CType(backbt, ComponentModel.ISupportInitialize).EndInit()
        CType(closebt, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
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
End Class
