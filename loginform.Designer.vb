<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class loginform
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
        MySqlCommand1 = New MySql.Data.MySqlClient.MySqlCommand()
        backbt = New PictureBox()
        closebt = New PictureBox()
        CType(backbt, ComponentModel.ISupportInitialize).BeginInit()
        CType(closebt, ComponentModel.ISupportInitialize).BeginInit()
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
        ' loginform
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.MenuHighlight
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(870, 481)
        Controls.Add(backbt)
        Controls.Add(closebt)
        FormBorderStyle = FormBorderStyle.None
        Name = "loginform"
        StartPosition = FormStartPosition.CenterScreen
        Text = "loginform"
        CType(backbt, ComponentModel.ISupportInitialize).EndInit()
        CType(closebt, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub
    Friend WithEvents MySqlCommand1 As MySql.Data.MySqlClient.MySqlCommand
    Friend WithEvents backbt As PictureBox
    Friend WithEvents closebt As PictureBox
End Class
