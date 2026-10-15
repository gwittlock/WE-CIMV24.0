<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class dlgHeatTransfer
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
        Me.beMaterialDB = New DevExpress.XtraEditors.ButtonEdit()
        Me.lblMaterialDB = New DevExpress.XtraEditors.LabelControl()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.beCFGManDB = New DevExpress.XtraEditors.ButtonEdit()
        Me.lbcMatTypes = New DevExpress.XtraEditors.ListBoxControl()
        Me.XtraFolderBrowserDialog1 = New DevExpress.XtraEditors.XtraFolderBrowserDialog(Me.components)
        Me.sbFindFIles = New DevExpress.XtraEditors.SimpleButton()
        Me.lbFoundFIles = New DevExpress.XtraEditors.ListBoxControl()
        Me.lbNotFound = New DevExpress.XtraEditors.ListBoxControl()
        Me.XtraFolderBrowserDialog2 = New DevExpress.XtraEditors.XtraFolderBrowserDialog(Me.components)
        Me.lblPath = New DevExpress.XtraEditors.LabelControl()
        Me.fcbRemnantPath = New DevExpress.XtraEditors.ButtonEdit()
        Me.ListBoxControl1 = New DevExpress.XtraEditors.ListBoxControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.sbAddStations = New DevExpress.XtraEditors.SimpleButton()
        Me.lbcTlDescrip = New DevExpress.XtraEditors.ListBoxControl()
        Me.lbcTlCurrStations = New DevExpress.XtraEditors.ListBoxControl()
        Me.lbcTlStationsToAdd = New DevExpress.XtraEditors.ListBoxControl()
        Me.lblTlDescrip = New DevExpress.XtraEditors.LabelControl()
        Me.lblTlCurrStations = New DevExpress.XtraEditors.LabelControl()
        Me.lblTlStationsToAdd = New DevExpress.XtraEditors.LabelControl()
        Me.sbBrass = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.beMaterialDB.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.beCFGManDB.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbcMatTypes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbFoundFIles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbNotFound, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fcbRemnantPath.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ListBoxControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbcTlDescrip, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbcTlCurrStations, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbcTlStationsToAdd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'beMaterialDB
        '
        Me.beMaterialDB.Location = New System.Drawing.Point(99, 12)
        Me.beMaterialDB.Name = "beMaterialDB"
        Me.beMaterialDB.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.beMaterialDB.Size = New System.Drawing.Size(426, 20)
        Me.beMaterialDB.TabIndex = 0
        '
        'lblMaterialDB
        '
        Me.lblMaterialDB.Location = New System.Drawing.Point(35, 15)
        Me.lblMaterialDB.Name = "lblMaterialDB"
        Me.lblMaterialDB.Size = New System.Drawing.Size(58, 13)
        Me.lblMaterialDB.TabIndex = 1
        Me.lblMaterialDB.Text = "Material DB:"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Location = New System.Drawing.Point(359, 80)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(166, 32)
        Me.SimpleButton1.TabIndex = 2
        Me.SimpleButton1.Text = "Fill Materials In CFGMan"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(27, 47)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(60, 13)
        Me.LabelControl1.TabIndex = 3
        Me.LabelControl1.Text = "CFGMan DB:"
        '
        'beCFGManDB
        '
        Me.beCFGManDB.Location = New System.Drawing.Point(99, 44)
        Me.beCFGManDB.Name = "beCFGManDB"
        Me.beCFGManDB.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.beCFGManDB.Size = New System.Drawing.Size(426, 20)
        Me.beCFGManDB.TabIndex = 4
        '
        'lbcMatTypes
        '
        Me.lbcMatTypes.Location = New System.Drawing.Point(3, 205)
        Me.lbcMatTypes.Name = "lbcMatTypes"
        Me.lbcMatTypes.Size = New System.Drawing.Size(120, 271)
        Me.lbcMatTypes.TabIndex = 5
        '
        'XtraFolderBrowserDialog1
        '
        Me.XtraFolderBrowserDialog1.SelectedPath = "XtraFolderBrowserDialog1"
        '
        'sbFindFIles
        '
        Me.sbFindFIles.AutoSize = True
        Me.sbFindFIles.Location = New System.Drawing.Point(359, 128)
        Me.sbFindFIles.Name = "sbFindFIles"
        Me.sbFindFIles.Size = New System.Drawing.Size(55, 22)
        Me.sbFindFIles.TabIndex = 6
        Me.sbFindFIles.Text = "Find FIles"
        '
        'lbFoundFIles
        '
        Me.lbFoundFIles.Location = New System.Drawing.Point(145, 234)
        Me.lbFoundFIles.Name = "lbFoundFIles"
        Me.lbFoundFIles.Size = New System.Drawing.Size(184, 242)
        Me.lbFoundFIles.TabIndex = 7
        '
        'lbNotFound
        '
        Me.lbNotFound.Location = New System.Drawing.Point(344, 234)
        Me.lbNotFound.Name = "lbNotFound"
        Me.lbNotFound.Size = New System.Drawing.Size(146, 242)
        Me.lbNotFound.TabIndex = 8
        '
        'XtraFolderBrowserDialog2
        '
        Me.XtraFolderBrowserDialog2.SelectedPath = "XtraFolderBrowserDialog2"
        '
        'lblPath
        '
        Me.lblPath.Location = New System.Drawing.Point(71, 80)
        Me.lblPath.Name = "lblPath"
        Me.lblPath.Size = New System.Drawing.Size(22, 13)
        Me.lblPath.TabIndex = 10
        Me.lblPath.Text = "Path"
        '
        'fcbRemnantPath
        '
        Me.fcbRemnantPath.Location = New System.Drawing.Point(99, 77)
        Me.fcbRemnantPath.Name = "fcbRemnantPath"
        Me.fcbRemnantPath.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.fcbRemnantPath.Size = New System.Drawing.Size(230, 20)
        Me.fcbRemnantPath.TabIndex = 9
        '
        'ListBoxControl1
        '
        Me.ListBoxControl1.Items.AddRange(New Object() {"2449A-VSP", "2449EE-ASL", "2469G-MSL", "2890A-SSG", "3226C-VSB", "4237-HCL", "4363-WB", "5449B-ALL", "5449B-ARL", "5449B-LSL", "5449B-RSCL", "5449B-RSL", "5449C-STSP", "5449D-BHL", "5449D-VCL", "5449E-MCS", "5449E-STP1", "5449E-STP2", "5449F-BML", "5449F-MML", "5449F-SB", "5449J-FML", "2467TT-TEP1", "5089-GFL", "5449-G", "5449B-TEP", "5449J-ABL", "5449J-ATL", "5449J-BP", "5449J-BTL", "5449J-NP", "5449J-TTL", "FGSBL-2", "PRP-400", "TM-09-4.5", "TM-09-6.5", "2448C1-CTP", "5449-IC", "5449B-SCL", "5449B-SML", "5449B-SMR", "5449B-SSL", "5449C-CPG", "5449C-CPL", "5449F-BGBP", "5449J-TP1", "5449J-TP2", "2334-GS", "2449EE-FSG", "2469B3-SGSB", "2469B3-UBGP", "3980-RC", "4434-GSL", "4434-GTB", "5449C-CPS", "5449F-UBGL", "5449J-LBGL", "SHDCLP-1", "2334-HEB"})
        Me.ListBoxControl1.Location = New System.Drawing.Point(3, 104)
        Me.ListBoxControl1.Name = "ListBoxControl1"
        Me.ListBoxControl1.Size = New System.Drawing.Size(326, 95)
        Me.ListBoxControl1.TabIndex = 11
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(145, 215)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(97, 13)
        Me.LabelControl2.TabIndex = 12
        Me.LabelControl2.Text = "Files Being Procesed"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(344, 215)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(146, 13)
        Me.LabelControl3.TabIndex = 13
        Me.LabelControl3.Text = "Files Not Found Or Wrong Rev"
        '
        'sbAddStations
        '
        Me.sbAddStations.Location = New System.Drawing.Point(568, 15)
        Me.sbAddStations.Name = "sbAddStations"
        Me.sbAddStations.Size = New System.Drawing.Size(271, 23)
        Me.sbAddStations.TabIndex = 14
        Me.sbAddStations.Text = "Add Stations"
        '
        'lbcTlDescrip
        '
        Me.lbcTlDescrip.Location = New System.Drawing.Point(507, 234)
        Me.lbcTlDescrip.Name = "lbcTlDescrip"
        Me.lbcTlDescrip.Size = New System.Drawing.Size(185, 249)
        Me.lbcTlDescrip.TabIndex = 15
        '
        'lbcTlCurrStations
        '
        Me.lbcTlCurrStations.Location = New System.Drawing.Point(698, 234)
        Me.lbcTlCurrStations.Name = "lbcTlCurrStations"
        Me.lbcTlCurrStations.Size = New System.Drawing.Size(120, 249)
        Me.lbcTlCurrStations.TabIndex = 16
        '
        'lbcTlStationsToAdd
        '
        Me.lbcTlStationsToAdd.Location = New System.Drawing.Point(824, 234)
        Me.lbcTlStationsToAdd.Name = "lbcTlStationsToAdd"
        Me.lbcTlStationsToAdd.Size = New System.Drawing.Size(120, 249)
        Me.lbcTlStationsToAdd.TabIndex = 17
        '
        'lblTlDescrip
        '
        Me.lblTlDescrip.Location = New System.Drawing.Point(525, 215)
        Me.lblTlDescrip.Name = "lblTlDescrip"
        Me.lblTlDescrip.Size = New System.Drawing.Size(76, 13)
        Me.lblTlDescrip.TabIndex = 18
        Me.lblTlDescrip.Text = "Tool Description"
        '
        'lblTlCurrStations
        '
        Me.lblTlCurrStations.Location = New System.Drawing.Point(707, 215)
        Me.lblTlCurrStations.Name = "lblTlCurrStations"
        Me.lblTlCurrStations.Size = New System.Drawing.Size(79, 13)
        Me.lblTlCurrStations.TabIndex = 19
        Me.lblTlCurrStations.Text = "Current Stations"
        '
        'lblTlStationsToAdd
        '
        Me.lblTlStationsToAdd.Location = New System.Drawing.Point(835, 215)
        Me.lblTlStationsToAdd.Name = "lblTlStationsToAdd"
        Me.lblTlStationsToAdd.Size = New System.Drawing.Size(76, 13)
        Me.lblTlStationsToAdd.TabIndex = 20
        Me.lblTlStationsToAdd.Text = "Stations To Add"
        '
        'sbBrass
        '
        Me.sbBrass.Location = New System.Drawing.Point(468, 127)
        Me.sbBrass.Name = "sbBrass"
        Me.sbBrass.Size = New System.Drawing.Size(147, 35)
        Me.sbBrass.TabIndex = 21
        Me.sbBrass.Text = "Add Brass"
        '
        'dlgHeatTransfer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1216, 488)
        Me.Controls.Add(Me.sbBrass)
        Me.Controls.Add(Me.lblTlStationsToAdd)
        Me.Controls.Add(Me.lblTlCurrStations)
        Me.Controls.Add(Me.lblTlDescrip)
        Me.Controls.Add(Me.lbcTlStationsToAdd)
        Me.Controls.Add(Me.lbcTlCurrStations)
        Me.Controls.Add(Me.lbcTlDescrip)
        Me.Controls.Add(Me.sbAddStations)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.ListBoxControl1)
        Me.Controls.Add(Me.lblPath)
        Me.Controls.Add(Me.fcbRemnantPath)
        Me.Controls.Add(Me.lbNotFound)
        Me.Controls.Add(Me.lbFoundFIles)
        Me.Controls.Add(Me.sbFindFIles)
        Me.Controls.Add(Me.lbcMatTypes)
        Me.Controls.Add(Me.beCFGManDB)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.lblMaterialDB)
        Me.Controls.Add(Me.beMaterialDB)
        Me.DoubleBuffered = True
        Me.Name = "dlgHeatTransfer"
        Me.Text = "dlgHeatTransfer"
        CType(Me.beMaterialDB.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.beCFGManDB.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbcMatTypes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbFoundFIles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbNotFound, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fcbRemnantPath.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ListBoxControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbcTlDescrip, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbcTlCurrStations, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbcTlStationsToAdd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents beMaterialDB As ButtonEdit
    Friend WithEvents lblMaterialDB As LabelControl
    Friend WithEvents SimpleButton1 As SimpleButton
    Friend WithEvents LabelControl1 As LabelControl
    Friend WithEvents beCFGManDB As ButtonEdit
    Friend WithEvents lbcMatTypes As ListBoxControl
    Friend WithEvents XtraFolderBrowserDialog1 As XtraFolderBrowserDialog
    Friend WithEvents sbFindFIles As SimpleButton
    Friend WithEvents lbFoundFIles As ListBoxControl
    Friend WithEvents lbNotFound As ListBoxControl
    Friend WithEvents XtraFolderBrowserDialog2 As XtraFolderBrowserDialog
    Friend WithEvents lblPath As LabelControl
    Friend WithEvents fcbRemnantPath As ButtonEdit
    Friend WithEvents ListBoxControl1 As ListBoxControl
    Friend WithEvents LabelControl2 As LabelControl
    Friend WithEvents LabelControl3 As LabelControl
    Friend WithEvents sbAddStations As SimpleButton
    Friend WithEvents lbcTlDescrip As ListBoxControl
    Friend WithEvents lbcTlCurrStations As ListBoxControl
    Friend WithEvents lbcTlStationsToAdd As ListBoxControl
    Friend WithEvents lblTlDescrip As LabelControl
    Friend WithEvents lblTlCurrStations As LabelControl
    Friend WithEvents lblTlStationsToAdd As LabelControl
    Friend WithEvents sbBrass As SimpleButton
End Class
