<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class form_main
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(form_main))
        Me.FolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.tb_folderSource = New System.Windows.Forms.TextBox()
        Me.lb_descFolderSource = New System.Windows.Forms.Label()
        Me.lb_descFolderTarget = New System.Windows.Forms.Label()
        Me.tb_folderTarget = New System.Windows.Forms.TextBox()
        Me.btn_run = New System.Windows.Forms.Button()
        Me.btn_selectFolderTarget = New System.Windows.Forms.Button()
        Me.btn_selectFolderSource = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'tb_folderSource
        '
        Me.tb_folderSource.Location = New System.Drawing.Point(11, 40)
        Me.tb_folderSource.Name = "tb_folderSource"
        Me.tb_folderSource.Size = New System.Drawing.Size(289, 20)
        Me.tb_folderSource.TabIndex = 1
        '
        'lb_descFolderSource
        '
        Me.lb_descFolderSource.AutoSize = True
        Me.lb_descFolderSource.Location = New System.Drawing.Point(12, 21)
        Me.lb_descFolderSource.Name = "lb_descFolderSource"
        Me.lb_descFolderSource.Size = New System.Drawing.Size(236, 13)
        Me.lb_descFolderSource.TabIndex = 2
        Me.lb_descFolderSource.Text = "Select a directory to make a resource pack from:"
        '
        'lb_descFolderTarget
        '
        Me.lb_descFolderTarget.AutoSize = True
        Me.lb_descFolderTarget.Location = New System.Drawing.Point(12, 100)
        Me.lb_descFolderTarget.Name = "lb_descFolderTarget"
        Me.lb_descFolderTarget.Size = New System.Drawing.Size(219, 13)
        Me.lb_descFolderTarget.TabIndex = 5
        Me.lb_descFolderTarget.Text = "Select a directory to save the resource pack:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'tb_folderTarget
        '
        Me.tb_folderTarget.Location = New System.Drawing.Point(11, 119)
        Me.tb_folderTarget.Name = "tb_folderTarget"
        Me.tb_folderTarget.Size = New System.Drawing.Size(289, 20)
        Me.tb_folderTarget.TabIndex = 4
        '
        'btn_run
        '
        Me.btn_run.Location = New System.Drawing.Point(11, 160)
        Me.btn_run.Name = "btn_run"
        Me.btn_run.Size = New System.Drawing.Size(311, 23)
        Me.btn_run.TabIndex = 6
        Me.btn_run.Text = "Make resource pack!"
        Me.btn_run.UseVisualStyleBackColor = True
        '
        'btn_selectFolderTarget
        '
        Me.btn_selectFolderTarget.BackgroundImage = Global.Soartex_Texture_Zipper.My.Resources.Resources.openfolder
        Me.btn_selectFolderTarget.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btn_selectFolderTarget.Location = New System.Drawing.Point(300, 118)
        Me.btn_selectFolderTarget.Name = "btn_selectFolderTarget"
        Me.btn_selectFolderTarget.Size = New System.Drawing.Size(22, 22)
        Me.btn_selectFolderTarget.TabIndex = 3
        Me.btn_selectFolderTarget.UseVisualStyleBackColor = True
        '
        'btn_selectFolderSource
        '
        Me.btn_selectFolderSource.BackgroundImage = Global.Soartex_Texture_Zipper.My.Resources.Resources.openfolder
        Me.btn_selectFolderSource.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btn_selectFolderSource.Location = New System.Drawing.Point(300, 39)
        Me.btn_selectFolderSource.Name = "btn_selectFolderSource"
        Me.btn_selectFolderSource.Size = New System.Drawing.Size(22, 22)
        Me.btn_selectFolderSource.TabIndex = 0
        Me.btn_selectFolderSource.UseVisualStyleBackColor = True
        '
        'form_main
        '
        Me.AcceptButton = Me.btn_run
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(334, 201)
        Me.Controls.Add(Me.btn_run)
        Me.Controls.Add(Me.lb_descFolderTarget)
        Me.Controls.Add(Me.tb_folderTarget)
        Me.Controls.Add(Me.btn_selectFolderTarget)
        Me.Controls.Add(Me.lb_descFolderSource)
        Me.Controls.Add(Me.tb_folderSource)
        Me.Controls.Add(Me.btn_selectFolderSource)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "form_main"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Soartex resource pack creator"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FolderBrowserDialog As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents btn_selectFolderSource As System.Windows.Forms.Button
    Friend WithEvents tb_folderSource As System.Windows.Forms.TextBox
    Friend WithEvents lb_descFolderSource As System.Windows.Forms.Label
    Friend WithEvents lb_descFolderTarget As System.Windows.Forms.Label
    Friend WithEvents tb_folderTarget As System.Windows.Forms.TextBox
    Friend WithEvents btn_selectFolderTarget As System.Windows.Forms.Button
    Friend WithEvents btn_run As System.Windows.Forms.Button

End Class
