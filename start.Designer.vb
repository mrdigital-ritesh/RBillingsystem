﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class start
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
        EMPLOYEE = New Label()
        MANAGER = New Label()
        ADMIN = New Label()
        PictureBox3 = New PictureBox()
        PictureBox2 = New PictureBox()
        PictureBox1 = New PictureBox()
        closebt = New PictureBox()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
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
        ' EMPLOYEE
        ' 
        EMPLOYEE.AutoSize = True
        EMPLOYEE.BackColor = Color.Transparent
        EMPLOYEE.Font = New Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        EMPLOYEE.ForeColor = SystemColors.ControlLightLight
        EMPLOYEE.Location = New Point(658, 345)
        EMPLOYEE.Name = "EMPLOYEE"
        EMPLOYEE.Size = New Size(121, 23)
        EMPLOYEE.TabIndex = 13
        EMPLOYEE.Text = "EMPLOYEE"
        ' 
        ' MANAGER
        ' 
        MANAGER.AutoSize = True
        MANAGER.BackColor = Color.Transparent
        MANAGER.Font = New Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        MANAGER.ForeColor = SystemColors.ControlLightLight
        MANAGER.Location = New Point(384, 345)
        MANAGER.Name = "MANAGER"
        MANAGER.Size = New Size(113, 23)
        MANAGER.TabIndex = 12
        MANAGER.Text = "MANAGER"
        ' 
        ' ADMIN
        ' 
        ADMIN.AutoSize = True
        ADMIN.BackColor = Color.Transparent
        ADMIN.Font = New Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ADMIN.ForeColor = SystemColors.ControlLightLight
        ADMIN.Location = New Point(114, 345)
        ADMIN.Name = "ADMIN"
        ADMIN.Size = New Size(78, 23)
        ADMIN.TabIndex = 11
        ADMIN.Text = "ADMIN"
        ' 
        ' PictureBox3
        ' 
        PictureBox3.BackColor = Color.Transparent
        PictureBox3.BackgroundImage = My.Resources.Resources.cashier
        PictureBox3.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox3.Location = New Point(614, 132)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(200, 200)
        PictureBox3.TabIndex = 10
        PictureBox3.TabStop = False
        ' 
        ' PictureBox2
        ' 
        PictureBox2.BackColor = Color.Transparent
        PictureBox2.BackgroundImage = My.Resources.Resources.manager
        PictureBox2.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox2.Location = New Point(338, 132)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(200, 200)
        PictureBox2.TabIndex = 9
        PictureBox2.TabStop = False
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.Transparent
        PictureBox1.BackgroundImage = My.Resources.Resources.admin
        PictureBox1.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox1.Location = New Point(54, 132)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(200, 200)
        PictureBox1.TabIndex = 8
        PictureBox1.TabStop = False
        ' 
        ' closebt
        ' 
        closebt.BackColor = Color.Transparent
        closebt.BackgroundImage = My.Resources.Resources.close
        closebt.BackgroundImageLayout = ImageLayout.Stretch
        closebt.Location = New Point(828, 8)
        closebt.Name = "closebt"
        closebt.Size = New Size(35, 35)
        closebt.TabIndex = 7
        closebt.TabStop = False
        ' 
        ' start
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.MenuHighlight
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(870, 481)
        Controls.Add(EMPLOYEE)
        Controls.Add(MANAGER)
        Controls.Add(ADMIN)
        Controls.Add(PictureBox3)
        Controls.Add(PictureBox2)
        Controls.Add(PictureBox1)
        Controls.Add(closebt)
        FormBorderStyle = FormBorderStyle.None
        MaximizeBox = False
        MinimizeBox = False
        Name = "start"
        ShowIcon = False
        SizeGripStyle = SizeGripStyle.Hide
        StartPosition = FormStartPosition.CenterScreen
        Text = "start"
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(closebt, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents MySqlCommand1 As MySql.Data.MySqlClient.MySqlCommand
    Friend WithEvents EMPLOYEE As Label
    Friend WithEvents MANAGER As Label
    Friend WithEvents ADMIN As Label
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents closebt As PictureBox
End Class
