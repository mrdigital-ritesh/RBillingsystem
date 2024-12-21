<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class product
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
        DataGridView1 = New DataGridView()
        Panel1 = New Panel()
        Button4 = New Button()
        stockdate = New TextBox()
        Label11 = New Label()
        disc = New TextBox()
        Label10 = New Label()
        category = New ComboBox()
        Label9 = New Label()
        Button3 = New Button()
        Button2 = New Button()
        Button1 = New Button()
        Label8 = New Label()
        qty = New TextBox()
        Label7 = New Label()
        Label6 = New Label()
        mrp = New TextBox()
        Label5 = New Label()
        purprice = New TextBox()
        Label4 = New Label()
        pbrand = New TextBox()
        Label3 = New Label()
        pname = New TextBox()
        Label2 = New Label()
        pid = New TextBox()
        Label1 = New Label()
        ComboBox1 = New ComboBox()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' DataGridView1
        ' 
        DataGridView1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.BackgroundColor = Color.Azure
        DataGridView1.BorderStyle = BorderStyle.Fixed3D
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(12, 382)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.ReadOnly = True
        DataGridView1.Size = New Size(1121, 160)
        DataGridView1.TabIndex = 15
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Panel1.AutoSize = True
        Panel1.BackColor = Color.DarkTurquoise
        Panel1.BorderStyle = BorderStyle.Fixed3D
        Panel1.Controls.Add(ComboBox1)
        Panel1.Controls.Add(Button4)
        Panel1.Controls.Add(stockdate)
        Panel1.Controls.Add(Label11)
        Panel1.Controls.Add(disc)
        Panel1.Controls.Add(Label10)
        Panel1.Controls.Add(category)
        Panel1.Controls.Add(Label9)
        Panel1.Controls.Add(Button3)
        Panel1.Controls.Add(Button2)
        Panel1.Controls.Add(Button1)
        Panel1.Controls.Add(Label8)
        Panel1.Controls.Add(qty)
        Panel1.Controls.Add(Label7)
        Panel1.Controls.Add(Label6)
        Panel1.Controls.Add(mrp)
        Panel1.Controls.Add(Label5)
        Panel1.Controls.Add(purprice)
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(pbrand)
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(pname)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(pid)
        Panel1.Controls.Add(Label1)
        Panel1.Location = New Point(12, 12)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1125, 364)
        Panel1.TabIndex = 17
        ' 
        ' Button4
        ' 
        Button4.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Button4.BackColor = SystemColors.ButtonFace
        Button4.FlatStyle = FlatStyle.Flat
        Button4.Location = New Point(1023, 196)
        Button4.Name = "Button4"
        Button4.Size = New Size(86, 34)
        Button4.TabIndex = 40
        Button4.Text = "Button4"
        Button4.UseVisualStyleBackColor = False
        ' 
        ' stockdate
        ' 
        stockdate.Font = New Font("Segoe UI", 12F)
        stockdate.Location = New Point(791, 300)
        stockdate.Name = "stockdate"
        stockdate.Size = New Size(159, 29)
        stockdate.TabIndex = 10
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Segoe UI", 12F)
        Label11.Location = New Point(666, 300)
        Label11.Name = "Label11"
        Label11.Size = New Size(65, 21)
        Label11.TabIndex = 39
        Label11.Text = "Label11"
        ' 
        ' disc
        ' 
        disc.Font = New Font("Segoe UI", 12F)
        disc.Location = New Point(418, 245)
        disc.Name = "disc"
        disc.Size = New Size(159, 29)
        disc.TabIndex = 7
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Segoe UI", 12F)
        Label10.Location = New Point(228, 300)
        Label10.Name = "Label10"
        Label10.Size = New Size(65, 21)
        Label10.TabIndex = 37
        Label10.Text = "Label10"
        ' 
        ' category
        ' 
        category.AllowDrop = True
        category.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        category.FormattingEnabled = True
        category.Location = New Point(791, 141)
        category.Name = "category"
        category.Size = New Size(159, 29)
        category.TabIndex = 4
        ' 
        ' Label9
        ' 
        Label9.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Label9.AutoSize = True
        Label9.BackColor = Color.Transparent
        Label9.Font = New Font("Rockwell", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label9.Location = New Point(580, 12)
        Label9.Name = "Label9"
        Label9.Size = New Size(69, 21)
        Label9.TabIndex = 35
        Label9.Text = "Label9"
        ' 
        ' Button3
        ' 
        Button3.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Button3.BackColor = SystemColors.ButtonFace
        Button3.FlatStyle = FlatStyle.Flat
        Button3.Location = New Point(1023, 142)
        Button3.Name = "Button3"
        Button3.Size = New Size(86, 34)
        Button3.TabIndex = 12
        Button3.Text = "Button3"
        Button3.UseVisualStyleBackColor = False
        ' 
        ' Button2
        ' 
        Button2.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Button2.BackColor = SystemColors.ButtonFace
        Button2.FlatStyle = FlatStyle.Flat
        Button2.Location = New Point(1023, 86)
        Button2.Name = "Button2"
        Button2.Size = New Size(86, 34)
        Button2.TabIndex = 13
        Button2.Text = "Button2"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' Button1
        ' 
        Button1.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Button1.BackColor = SystemColors.ButtonFace
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Location = New Point(1023, 29)
        Button1.Name = "Button1"
        Button1.Size = New Size(86, 34)
        Button1.TabIndex = 11
        Button1.Text = "Button1"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Segoe UI", 12F)
        Label8.Location = New Point(666, 248)
        Label8.Name = "Label8"
        Label8.Size = New Size(56, 21)
        Label8.TabIndex = 30
        Label8.Text = "Label8"
        ' 
        ' qty
        ' 
        qty.Font = New Font("Segoe UI", 12F)
        qty.Location = New Point(791, 245)
        qty.Name = "qty"
        qty.Size = New Size(159, 29)
        qty.TabIndex = 8
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Segoe UI", 12F)
        Label7.Location = New Point(228, 248)
        Label7.Name = "Label7"
        Label7.Size = New Size(56, 21)
        Label7.TabIndex = 28
        Label7.Text = "Label7"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 12F)
        Label6.Location = New Point(666, 203)
        Label6.Name = "Label6"
        Label6.Size = New Size(56, 21)
        Label6.TabIndex = 26
        Label6.Text = "Label6"
        ' 
        ' mrp
        ' 
        mrp.Font = New Font("Segoe UI", 12F)
        mrp.Location = New Point(791, 195)
        mrp.Name = "mrp"
        mrp.Size = New Size(159, 29)
        mrp.TabIndex = 6
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 12F)
        Label5.Location = New Point(228, 203)
        Label5.Name = "Label5"
        Label5.Size = New Size(56, 21)
        Label5.TabIndex = 24
        Label5.Text = "Label5"
        ' 
        ' purprice
        ' 
        purprice.Font = New Font("Segoe UI", 12F)
        purprice.Location = New Point(418, 195)
        purprice.Name = "purprice"
        purprice.Size = New Size(159, 29)
        purprice.TabIndex = 5
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 12F)
        Label4.Location = New Point(666, 149)
        Label4.Name = "Label4"
        Label4.Size = New Size(56, 21)
        Label4.TabIndex = 22
        Label4.Text = "Label4"
        ' 
        ' pbrand
        ' 
        pbrand.Font = New Font("Segoe UI", 12F)
        pbrand.Location = New Point(418, 138)
        pbrand.Name = "pbrand"
        pbrand.Size = New Size(159, 29)
        pbrand.TabIndex = 3
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 12F)
        Label3.Location = New Point(228, 149)
        Label3.Name = "Label3"
        Label3.Size = New Size(56, 21)
        Label3.TabIndex = 20
        Label3.Text = "Label3"
        ' 
        ' pname
        ' 
        pname.Font = New Font("Segoe UI", 12F)
        pname.Location = New Point(791, 91)
        pname.Name = "pname"
        pname.Size = New Size(159, 29)
        pname.TabIndex = 2
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 12F)
        Label2.Location = New Point(666, 99)
        Label2.Name = "Label2"
        Label2.Size = New Size(56, 21)
        Label2.TabIndex = 18
        Label2.Text = "Label2"
        ' 
        ' pid
        ' 
        pid.Font = New Font("Segoe UI", 12F)
        pid.Location = New Point(418, 91)
        pid.Name = "pid"
        pid.Size = New Size(159, 29)
        pid.TabIndex = 1
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 12F)
        Label1.Location = New Point(228, 99)
        Label1.Name = "Label1"
        Label1.Size = New Size(56, 21)
        Label1.TabIndex = 16
        Label1.Text = "Label1"
        ' 
        ' ComboBox1
        ' 
        ComboBox1.AllowDrop = True
        ComboBox1.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New Point(418, 300)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(159, 29)
        ComboBox1.TabIndex = 41
        ' 
        ' product
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSize = True
        ClientSize = New Size(1145, 554)
        Controls.Add(Panel1)
        Controls.Add(DataGridView1)
        Name = "product"
        StartPosition = FormStartPosition.CenterScreen
        Text = "product"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents qty As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents mrp As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents purprice As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents pbrand As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents pname As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents pid As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents category As ComboBox
    Friend WithEvents disc As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents stockdate As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Button4 As Button
    Friend WithEvents ComboBox1 As ComboBox

End Class
