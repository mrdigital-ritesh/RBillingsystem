﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Barcodegenerate
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
        Timer1 = New Timer(components)
        Panel1 = New Panel()
        PictureBox1 = New PictureBox()
        Label27 = New Label()
        PictureBox3 = New PictureBox()
        Label24 = New Label()
        Label25 = New Label()
        Label28 = New Label()
        Label26 = New Label()
        PrintDocument1 = New Printing.PrintDocument()
        DataGridViewProducts = New DataGridView()
        Panel2 = New Panel()
        Button3 = New Button()
        Button2 = New Button()
        Button1 = New Button()
        ButtonSearch = New Button()
        Label1 = New Label()
        TextBox1 = New TextBox()
        FlowLayoutPanelPreview = New FlowLayoutPanel()
        Label2 = New Label()
        PictureBox2 = New PictureBox()
        Panel1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        CType(DataGridViewProducts, ComponentModel.ISupportInitialize).BeginInit()
        Panel2.SuspendLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Timer1
        ' 
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = SystemColors.Control
        Panel1.Controls.Add(PictureBox1)
        Panel1.Controls.Add(Label27)
        Panel1.Controls.Add(PictureBox3)
        Panel1.Controls.Add(Label24)
        Panel1.Controls.Add(Label25)
        Panel1.Controls.Add(Label28)
        Panel1.Controls.Add(Label26)
        Panel1.Location = New Point(-7, 704)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1410, 113)
        Panel1.TabIndex = 0
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.Transparent
        PictureBox1.BackgroundImage = My.Resources.Resources.customers
        PictureBox1.BackgroundImageLayout = ImageLayout.Zoom
        PictureBox1.Location = New Point(317, 5)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(32, 34)
        PictureBox1.TabIndex = 73
        PictureBox1.TabStop = False
        ' 
        ' Label27
        ' 
        Label27.AutoSize = True
        Label27.Font = New Font("Arial Narrow", 11.25F, FontStyle.Bold)
        Label27.Location = New Point(682, 13)
        Label27.Name = "Label27"
        Label27.Size = New Size(57, 20)
        Label27.TabIndex = 71
        Label27.Text = "Label27"
        ' 
        ' PictureBox3
        ' 
        PictureBox3.BackColor = Color.Transparent
        PictureBox3.BackgroundImage = My.Resources.Resources.calender
        PictureBox3.BackgroundImageLayout = ImageLayout.Zoom
        PictureBox3.Location = New Point(26, 9)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(24, 27)
        PictureBox3.TabIndex = 72
        PictureBox3.TabStop = False
        ' 
        ' Label24
        ' 
        Label24.AutoSize = True
        Label24.Font = New Font("Arial Narrow", 11.25F, FontStyle.Bold)
        Label24.Location = New Point(59, 13)
        Label24.Name = "Label24"
        Label24.Size = New Size(57, 20)
        Label24.TabIndex = 67
        Label24.Text = "Label24"
        ' 
        ' Label25
        ' 
        Label25.AutoSize = True
        Label25.Font = New Font("Arial Narrow", 11.25F, FontStyle.Bold)
        Label25.Location = New Point(358, 13)
        Label25.Name = "Label25"
        Label25.Size = New Size(57, 20)
        Label25.TabIndex = 68
        Label25.Text = "Label25"
        ' 
        ' Label28
        ' 
        Label28.AutoSize = True
        Label28.Font = New Font("Arial Narrow", 11.25F, FontStyle.Bold)
        Label28.Location = New Point(562, 13)
        Label28.Name = "Label28"
        Label28.Size = New Size(57, 20)
        Label28.TabIndex = 70
        Label28.Text = "Label28"
        ' 
        ' Label26
        ' 
        Label26.AutoSize = True
        Label26.Font = New Font("Arial Narrow", 11.25F, FontStyle.Bold)
        Label26.Location = New Point(456, 13)
        Label26.Name = "Label26"
        Label26.Size = New Size(57, 20)
        Label26.TabIndex = 69
        Label26.Text = "Label26"
        ' 
        ' DataGridViewProducts
        ' 
        DataGridViewProducts.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        DataGridViewProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewProducts.BackgroundColor = Color.Azure
        DataGridViewProducts.BorderStyle = BorderStyle.Fixed3D
        DataGridViewProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewProducts.Location = New Point(12, 258)
        DataGridViewProducts.Name = "DataGridViewProducts"
        DataGridViewProducts.ReadOnly = True
        DataGridViewProducts.Size = New Size(486, 440)
        DataGridViewProducts.TabIndex = 18
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(Button3)
        Panel2.Controls.Add(Button2)
        Panel2.Controls.Add(Button1)
        Panel2.Controls.Add(ButtonSearch)
        Panel2.Controls.Add(Label1)
        Panel2.Controls.Add(TextBox1)
        Panel2.Location = New Point(12, 48)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(486, 204)
        Panel2.TabIndex = 19
        ' 
        ' Button3
        ' 
        Button3.Location = New Point(313, 128)
        Button3.Name = "Button3"
        Button3.Size = New Size(151, 40)
        Button3.TabIndex = 4
        Button3.Text = "CLEAR PAGE (ESC)"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(313, 82)
        Button2.Name = "Button2"
        Button2.Size = New Size(151, 40)
        Button2.TabIndex = 3
        Button2.Text = "PRINT PAGE (F5)"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(313, 36)
        Button1.Name = "Button1"
        Button1.Size = New Size(151, 40)
        Button1.TabIndex = 2
        Button1.Text = "GENERATE BARCODE (F1)"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' ButtonSearch
        ' 
        ButtonSearch.Location = New Point(36, 117)
        ButtonSearch.Name = "ButtonSearch"
        ButtonSearch.Size = New Size(89, 40)
        ButtonSearch.TabIndex = 1
        ButtonSearch.Text = "SEARCH"
        ButtonSearch.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(36, 37)
        Label1.Name = "Label1"
        Label1.Size = New Size(116, 16)
        Label1.TabIndex = 1
        Label1.Text = "ENTER PRODUCT"
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(36, 64)
        TextBox1.Multiline = True
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(247, 36)
        TextBox1.TabIndex = 0
        ' 
        ' FlowLayoutPanelPreview
        ' 
        FlowLayoutPanelPreview.AutoScroll = True
        FlowLayoutPanelPreview.BorderStyle = BorderStyle.FixedSingle
        FlowLayoutPanelPreview.Location = New Point(504, 48)
        FlowLayoutPanelPreview.Name = "FlowLayoutPanelPreview"
        FlowLayoutPanelPreview.Size = New Size(854, 650)
        FlowLayoutPanelPreview.TabIndex = 20
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Times New Roman", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.White
        Label2.Location = New Point(556, 9)
        Label2.Name = "Label2"
        Label2.Size = New Size(258, 24)
        Label2.TabIndex = 2
        Label2.Text = "BARCODE GENERATION"
        ' 
        ' PictureBox2
        ' 
        PictureBox2.BackColor = Color.Transparent
        PictureBox2.BackgroundImage = My.Resources.Resources.backbtn2
        PictureBox2.BackgroundImageLayout = ImageLayout.Zoom
        PictureBox2.Location = New Point(10, 2)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(62, 46)
        PictureBox2.TabIndex = 93
        PictureBox2.TabStop = False
        ' 
        ' Barcodegenerate
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1370, 749)
        Controls.Add(PictureBox2)
        Controls.Add(Label2)
        Controls.Add(FlowLayoutPanelPreview)
        Controls.Add(Panel2)
        Controls.Add(DataGridViewProducts)
        Controls.Add(Panel1)
        Name = "Barcodegenerate"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Barcodegenerate"
        WindowState = FormWindowState.Maximized
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        CType(DataGridViewProducts, ComponentModel.ISupportInitialize).EndInit()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Timer1 As Timer
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label27 As Label
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents Label24 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents DataGridViewProducts As DataGridView
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents FlowLayoutPanelPreview As FlowLayoutPanel
    Friend WithEvents ButtonSearch As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox2 As PictureBox
End Class
