﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class form_selectTarget
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
        Me.lb_descFolderTarget = New System.Windows.Forms.Label()
        Me.tb_folderTarget = New System.Windows.Forms.TextBox()
        Me.btn_selectFolderTarget = New System.Windows.Forms.Button()
        Me.btn_run = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lb_descFolderTarget
        '
        Me.lb_descFolderTarget.AutoSize = True
        Me.lb_descFolderTarget.Location = New System.Drawing.Point(13, 28)
        Me.lb_descFolderTarget.Name = "lb_descFolderTarget"
        Me.lb_descFolderTarget.Size = New System.Drawing.Size(219, 13)
        Me.lb_descFolderTarget.TabIndex = 8
        Me.lb_descFolderTarget.Text = "Select a directory to save the resource pack:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'tb_folderTarget
        '
        Me.tb_folderTarget.Location = New System.Drawing.Point(12, 47)
        Me.tb_folderTarget.Name = "tb_folderTarget"
        Me.tb_folderTarget.Size = New System.Drawing.Size(289, 20)
        Me.tb_folderTarget.TabIndex = 7
        '
        'btn_selectFolderTarget
        '
        Me.btn_selectFolderTarget.BackgroundImage = Global.Soartex_Texture_Zipper.My.Resources.Resources.openfolder
        Me.btn_selectFolderTarget.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btn_selectFolderTarget.Location = New System.Drawing.Point(301, 46)
        Me.btn_selectFolderTarget.Name = "btn_selectFolderTarget"
        Me.btn_selectFolderTarget.Size = New System.Drawing.Size(22, 22)
        Me.btn_selectFolderTarget.TabIndex = 6
        Me.btn_selectFolderTarget.UseVisualStyleBackColor = True
        '
        'btn_run
        '
        Me.btn_run.Location = New System.Drawing.Point(11, 93)
        Me.btn_run.Name = "btn_run"
        Me.btn_run.Size = New System.Drawing.Size(311, 23)
        Me.btn_run.TabIndex = 9
        Me.btn_run.Text = "OK"
        Me.btn_run.UseVisualStyleBackColor = True
        '
        'form_selectTarget
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(334, 137)
        Me.Controls.Add(Me.btn_run)
        Me.Controls.Add(Me.lb_descFolderTarget)
        Me.Controls.Add(Me.tb_folderTarget)
        Me.Controls.Add(Me.btn_selectFolderTarget)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "form_selectTarget"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "form_selectTarget"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lb_descFolderTarget As System.Windows.Forms.Label
    Friend WithEvents tb_folderTarget As System.Windows.Forms.TextBox
    Friend WithEvents btn_selectFolderTarget As System.Windows.Forms.Button
    Friend WithEvents btn_run As System.Windows.Forms.Button
End Class
