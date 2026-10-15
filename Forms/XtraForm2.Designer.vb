<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class XtraForm2
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.lstTools = New DevExpress.XtraEditors.ListBoxControl()
        Me.lstStations = New DevExpress.XtraEditors.ListBoxControl()
        Me.sbCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.sbSearch = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.fldrVw = New LogicNP.FolderViewControl.FolderView()
        Me.fgList = New LogicNP.FileViewControl.FileView(Me.components)
        CType(Me.lstTools, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lstStations, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lstTools
        '
        Me.lstTools.Location = New System.Drawing.Point(0, 0)
        Me.lstTools.Name = "lstTools"
        Me.lstTools.Size = New System.Drawing.Size(223, 409)
        Me.lstTools.TabIndex = 0
        '
        'lstStations
        '
        Me.lstStations.Location = New System.Drawing.Point(229, 0)
        Me.lstStations.Name = "lstStations"
        Me.lstStations.Size = New System.Drawing.Size(239, 409)
        Me.lstStations.TabIndex = 1
        '
        'sbCancel
        '
        Me.sbCancel.Location = New System.Drawing.Point(474, 386)
        Me.sbCancel.Name = "sbCancel"
        Me.sbCancel.Size = New System.Drawing.Size(75, 23)
        Me.sbCancel.TabIndex = 2
        Me.sbCancel.Text = "Cancel"
        '
        'sbSearch
        '
        Me.sbSearch.Location = New System.Drawing.Point(555, 386)
        Me.sbSearch.Name = "sbSearch"
        Me.sbSearch.Size = New System.Drawing.Size(75, 23)
        Me.sbSearch.TabIndex = 3
        Me.sbSearch.Text = "Search"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Location = New System.Drawing.Point(496, 38)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(75, 23)
        Me.SimpleButton1.TabIndex = 4
        Me.SimpleButton1.Text = "SimpleButton1"
        '
        'fldrVw
        '
        Me.fldrVw.FileView = Me.fgList
        Me.fldrVw.Location = New System.Drawing.Point(496, 67)
        Me.fldrVw.Name = "fldrVw"
        Me.fldrVw.Padding = New System.Windows.Forms.Padding(3)
        Me.fldrVw.Size = New System.Drawing.Size(299, 129)
        Me.fldrVw.TabIndex = 5
        Me.fldrVw.Text = "FolderView1"
        '
        'fgList
        '
        Me.fgList.AllowFileExecution = False
        Me.fgList.FilePattern = "*.mdb"
        Me.fgList.Location = New System.Drawing.Point(496, 202)
        Me.fgList.Name = "fgList"
        Me.fgList.Padding = New System.Windows.Forms.Padding(3)
        Me.fgList.ShowBackgroundMenu = False
        Me.fgList.ShowFolders = False
        Me.fgList.ShowHiddenItems = False
        Me.fgList.Size = New System.Drawing.Size(435, 129)
        Me.fgList.TabIndex = 6
        Me.fgList.Text = "FileView1"
        Me.fgList.ViewStyle = LogicNP.FileViewControl.ViewStyles.Report
        '
        'XtraForm2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1070, 421)
        Me.Controls.Add(Me.fldrVw)
        Me.Controls.Add(Me.fgList)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.sbSearch)
        Me.Controls.Add(Me.sbCancel)
        Me.Controls.Add(Me.lstStations)
        Me.Controls.Add(Me.lstTools)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "XtraForm2"
        Me.Text = "XtraForm2"
        CType(Me.lstTools, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lstStations, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lstTools As ListBoxControl
    Friend WithEvents lstStations As ListBoxControl
    Friend WithEvents sbCancel As SimpleButton
    Friend WithEvents sbSearch As SimpleButton
    Friend WithEvents SimpleButton1 As SimpleButton
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents fldrVw As LogicNP.FolderViewControl.FolderView
    Friend WithEvents fgList As LogicNP.FileViewControl.FileView
End Class
