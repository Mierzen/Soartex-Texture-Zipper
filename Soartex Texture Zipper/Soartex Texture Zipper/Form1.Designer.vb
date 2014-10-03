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
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripProgressBar_zipProgress = New System.Windows.Forms.ToolStripProgressBar()
        Me.ToolStripStatusLabel_appVersion = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStrip1.SuspendLayout()
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
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripProgressBar_zipProgress, Me.ToolStripStatusLabel_appVersion})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 199)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(334, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 7
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripProgressBar_zipProgress
        '
        Me.ToolStripProgressBar_zipProgress.MarqueeAnimationSpeed = 50
        Me.ToolStripProgressBar_zipProgress.Name = "ToolStripProgressBar_zipProgress"
        Me.ToolStripProgressBar_zipProgress.Size = New System.Drawing.Size(100, 16)
        Me.ToolStripProgressBar_zipProgress.Step = 1
        Me.ToolStripProgressBar_zipProgress.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.ToolStripProgressBar_zipProgress.Visible = False
        '
        'ToolStripStatusLabel_appVersion
        '
        Me.ToolStripStatusLabel_appVersion.AutoSize = False
        Me.ToolStripStatusLabel_appVersion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripStatusLabel_appVersion.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel_appVersion.Name = "ToolStripStatusLabel_appVersion"
        Me.ToolStripStatusLabel_appVersion.Size = New System.Drawing.Size(229, 17)
        Me.ToolStripStatusLabel_appVersion.Text = "version"
        Me.ToolStripStatusLabel_appVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'form_main
        '
        Me.AcceptButton = Me.btn_run
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(334, 221)
        Me.Controls.Add(Me.StatusStrip1)
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
        Me.Text = "Soartex texture zipper"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
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
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripProgressBar_zipProgress As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents ToolStripStatusLabel_appVersion As System.Windows.Forms.ToolStripStatusLabel

End Class
