<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCSFails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCSFails))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.btnRCClear1 = New System.Windows.Forms.Button()
        Me.lblRCIDDescription = New System.Windows.Forms.Label()
        Me.btnRCDeleteDescription = New System.Windows.Forms.Button()
        Me.lblRC = New System.Windows.Forms.Label()
        Me.btnRCAddUpdateDescription = New System.Windows.Forms.Button()
        Me.lblRCRecordsGridRC = New System.Windows.Forms.Label()
        Me.GridRC = New System.Windows.Forms.DataGridView()
        Me.txbRCDescription = New System.Windows.Forms.TextBox()
        Me.lblRCCustomerCode = New System.Windows.Forms.Label()
        Me.btnRCClear2 = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.lblRCIDRC = New System.Windows.Forms.Label()
        Me.lblRCDueDate = New System.Windows.Forms.Label()
        Me.lblRCPO = New System.Windows.Forms.Label()
        Me.lblRCIDQB = New System.Windows.Forms.Label()
        Me.lblRCSONumber = New System.Windows.Forms.Label()
        Me.btnRCDeleteRC = New System.Windows.Forms.Button()
        Me.btnRCAddUpdateRC = New System.Windows.Forms.Button()
        Me.lblRCMonthAssigned = New System.Windows.Forms.Label()
        Me.lblRCStatus = New System.Windows.Forms.Label()
        Me.lblResponsibleDate = New System.Windows.Forms.Label()
        Me.lblRCResponsible = New System.Windows.Forms.Label()
        Me.lblRCImmediateAction = New System.Windows.Forms.Label()
        Me.cmbRCMonthAssigned = New System.Windows.Forms.ComboBox()
        Me.cmbRCStatus = New System.Windows.Forms.ComboBox()
        Me.dtpRCResponsibleDate = New System.Windows.Forms.DateTimePicker()
        Me.txbRCResponsible = New System.Windows.Forms.TextBox()
        Me.txbRCImmediateAction = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbRC = New System.Windows.Forms.ComboBox()
        Me.lblRCRecordsOTDRootCauseDeliveryFail = New System.Windows.Forms.Label()
        Me.GridOTDRootCauseDeliveryFail = New System.Windows.Forms.DataGridView()
        Me.Panel1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.GridRC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridOTDRootCauseDeliveryFail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.SplitContainer1)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1238, 579)
        Me.Panel1.TabIndex = 0
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnRCClear1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblRCIDDescription)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnRCDeleteDescription)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblRC)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnRCAddUpdateDescription)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblRCRecordsGridRC)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GridRC)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txbRCDescription)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblRCCustomerCode)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnRCClear2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnClear)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblRCIDRC)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblRCDueDate)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblRCPO)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblRCIDQB)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblRCSONumber)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnRCDeleteRC)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnRCAddUpdateRC)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblRCMonthAssigned)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblRCStatus)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblResponsibleDate)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblRCResponsible)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblRCImmediateAction)
        Me.SplitContainer1.Panel2.Controls.Add(Me.cmbRCMonthAssigned)
        Me.SplitContainer1.Panel2.Controls.Add(Me.cmbRCStatus)
        Me.SplitContainer1.Panel2.Controls.Add(Me.dtpRCResponsibleDate)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txbRCResponsible)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txbRCImmediateAction)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel2.Controls.Add(Me.cmbRC)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblRCRecordsOTDRootCauseDeliveryFail)
        Me.SplitContainer1.Panel2.Controls.Add(Me.GridOTDRootCauseDeliveryFail)
        Me.SplitContainer1.Size = New System.Drawing.Size(1238, 579)
        Me.SplitContainer1.SplitterDistance = 361
        Me.SplitContainer1.TabIndex = 0
        '
        'btnRCClear1
        '
        Me.btnRCClear1.Location = New System.Drawing.Point(11, 33)
        Me.btnRCClear1.Name = "btnRCClear1"
        Me.btnRCClear1.Size = New System.Drawing.Size(75, 38)
        Me.btnRCClear1.TabIndex = 77
        Me.btnRCClear1.Text = "Clear"
        Me.btnRCClear1.UseVisualStyleBackColor = True
        '
        'lblRCIDDescription
        '
        Me.lblRCIDDescription.AutoSize = True
        Me.lblRCIDDescription.Location = New System.Drawing.Point(97, 40)
        Me.lblRCIDDescription.Name = "lblRCIDDescription"
        Me.lblRCIDDescription.Size = New System.Drawing.Size(21, 17)
        Me.lblRCIDDescription.TabIndex = 76
        Me.lblRCIDDescription.Text = "ID"
        '
        'btnRCDeleteDescription
        '
        Me.btnRCDeleteDescription.Enabled = False
        Me.btnRCDeleteDescription.Location = New System.Drawing.Point(265, 57)
        Me.btnRCDeleteDescription.Name = "btnRCDeleteDescription"
        Me.btnRCDeleteDescription.Size = New System.Drawing.Size(75, 38)
        Me.btnRCDeleteDescription.TabIndex = 75
        Me.btnRCDeleteDescription.Text = "Delete"
        Me.btnRCDeleteDescription.UseVisualStyleBackColor = True
        '
        'lblRC
        '
        Me.lblRC.AutoSize = True
        Me.lblRC.Location = New System.Drawing.Point(5, 11)
        Me.lblRC.Name = "lblRC"
        Me.lblRC.Size = New System.Drawing.Size(86, 17)
        Me.lblRC.TabIndex = 65
        Me.lblRC.Text = "Root Cause:"
        '
        'btnRCAddUpdateDescription
        '
        Me.btnRCAddUpdateDescription.Location = New System.Drawing.Point(184, 57)
        Me.btnRCAddUpdateDescription.Name = "btnRCAddUpdateDescription"
        Me.btnRCAddUpdateDescription.Size = New System.Drawing.Size(75, 38)
        Me.btnRCAddUpdateDescription.TabIndex = 74
        Me.btnRCAddUpdateDescription.Text = "Add"
        Me.btnRCAddUpdateDescription.UseVisualStyleBackColor = True
        '
        'lblRCRecordsGridRC
        '
        Me.lblRCRecordsGridRC.AutoSize = True
        Me.lblRCRecordsGridRC.Location = New System.Drawing.Point(9, 81)
        Me.lblRCRecordsGridRC.Name = "lblRCRecordsGridRC"
        Me.lblRCRecordsGridRC.Size = New System.Drawing.Size(77, 17)
        Me.lblRCRecordsGridRC.TabIndex = 64
        Me.lblRCRecordsGridRC.Text = "Records: 0"
        '
        'GridRC
        '
        Me.GridRC.AllowUserToAddRows = False
        Me.GridRC.AllowUserToDeleteRows = False
        Me.GridRC.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridRC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridRC.Location = New System.Drawing.Point(12, 101)
        Me.GridRC.Name = "GridRC"
        Me.GridRC.ReadOnly = True
        Me.GridRC.RowTemplate.Height = 24
        Me.GridRC.Size = New System.Drawing.Size(329, 466)
        Me.GridRC.TabIndex = 62
        '
        'txbRCDescription
        '
        Me.txbRCDescription.Location = New System.Drawing.Point(97, 11)
        Me.txbRCDescription.Name = "txbRCDescription"
        Me.txbRCDescription.Size = New System.Drawing.Size(244, 22)
        Me.txbRCDescription.TabIndex = 63
        '
        'lblRCCustomerCode
        '
        Me.lblRCCustomerCode.AutoSize = True
        Me.lblRCCustomerCode.Location = New System.Drawing.Point(461, 149)
        Me.lblRCCustomerCode.Name = "lblRCCustomerCode"
        Me.lblRCCustomerCode.Size = New System.Drawing.Size(105, 17)
        Me.lblRCCustomerCode.TabIndex = 1104
        Me.lblRCCustomerCode.Text = "Customer Code"
        '
        'btnRCClear2
        '
        Me.btnRCClear2.Location = New System.Drawing.Point(796, 128)
        Me.btnRCClear2.Name = "btnRCClear2"
        Me.btnRCClear2.Size = New System.Drawing.Size(71, 38)
        Me.btnRCClear2.TabIndex = 1103
        Me.btnRCClear2.Text = "Clear"
        Me.btnRCClear2.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Image = CType(resources.GetObject("btnClear.Image"), System.Drawing.Image)
        Me.btnClear.Location = New System.Drawing.Point(827, 10)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(43, 47)
        Me.btnClear.TabIndex = 1102
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'lblRCIDRC
        '
        Me.lblRCIDRC.AutoSize = True
        Me.lblRCIDRC.Location = New System.Drawing.Point(329, 150)
        Me.lblRCIDRC.Name = "lblRCIDRC"
        Me.lblRCIDRC.Size = New System.Drawing.Size(40, 17)
        Me.lblRCIDRC.TabIndex = 78
        Me.lblRCIDRC.Text = "IDRC"
        '
        'lblRCDueDate
        '
        Me.lblRCDueDate.AutoSize = True
        Me.lblRCDueDate.Location = New System.Drawing.Point(461, 128)
        Me.lblRCDueDate.Name = "lblRCDueDate"
        Me.lblRCDueDate.Size = New System.Drawing.Size(64, 17)
        Me.lblRCDueDate.TabIndex = 77
        Me.lblRCDueDate.Text = "DueDate"
        '
        'lblRCPO
        '
        Me.lblRCPO.AutoSize = True
        Me.lblRCPO.Location = New System.Drawing.Point(329, 128)
        Me.lblRCPO.Name = "lblRCPO"
        Me.lblRCPO.Size = New System.Drawing.Size(28, 17)
        Me.lblRCPO.TabIndex = 76
        Me.lblRCPO.Text = "PO"
        '
        'lblRCIDQB
        '
        Me.lblRCIDQB.AutoSize = True
        Me.lblRCIDQB.Location = New System.Drawing.Point(155, 149)
        Me.lblRCIDQB.Name = "lblRCIDQB"
        Me.lblRCIDQB.Size = New System.Drawing.Size(41, 17)
        Me.lblRCIDQB.TabIndex = 75
        Me.lblRCIDQB.Text = "IDQB"
        '
        'lblRCSONumber
        '
        Me.lblRCSONumber.AutoSize = True
        Me.lblRCSONumber.Location = New System.Drawing.Point(154, 128)
        Me.lblRCSONumber.Name = "lblRCSONumber"
        Me.lblRCSONumber.Size = New System.Drawing.Size(78, 17)
        Me.lblRCSONumber.TabIndex = 74
        Me.lblRCSONumber.Text = "SONumber"
        '
        'btnRCDeleteRC
        '
        Me.btnRCDeleteRC.Enabled = False
        Me.btnRCDeleteRC.Location = New System.Drawing.Point(716, 128)
        Me.btnRCDeleteRC.Name = "btnRCDeleteRC"
        Me.btnRCDeleteRC.Size = New System.Drawing.Size(75, 38)
        Me.btnRCDeleteRC.TabIndex = 73
        Me.btnRCDeleteRC.Text = "Delete"
        Me.btnRCDeleteRC.UseVisualStyleBackColor = True
        '
        'btnRCAddUpdateRC
        '
        Me.btnRCAddUpdateRC.Location = New System.Drawing.Point(635, 128)
        Me.btnRCAddUpdateRC.Name = "btnRCAddUpdateRC"
        Me.btnRCAddUpdateRC.Size = New System.Drawing.Size(75, 38)
        Me.btnRCAddUpdateRC.TabIndex = 72
        Me.btnRCAddUpdateRC.Text = "Add"
        Me.btnRCAddUpdateRC.UseVisualStyleBackColor = True
        '
        'lblRCMonthAssigned
        '
        Me.lblRCMonthAssigned.AutoSize = True
        Me.lblRCMonthAssigned.Location = New System.Drawing.Point(568, 102)
        Me.lblRCMonthAssigned.Name = "lblRCMonthAssigned"
        Me.lblRCMonthAssigned.Size = New System.Drawing.Size(113, 17)
        Me.lblRCMonthAssigned.TabIndex = 71
        Me.lblRCMonthAssigned.Text = "Month Assigned:"
        '
        'lblRCStatus
        '
        Me.lblRCStatus.AutoSize = True
        Me.lblRCStatus.Location = New System.Drawing.Point(409, 100)
        Me.lblRCStatus.Name = "lblRCStatus"
        Me.lblRCStatus.Size = New System.Drawing.Size(52, 17)
        Me.lblRCStatus.TabIndex = 70
        Me.lblRCStatus.Text = "Status:"
        '
        'lblResponsibleDate
        '
        Me.lblResponsibleDate.AutoSize = True
        Me.lblResponsibleDate.Location = New System.Drawing.Point(8, 98)
        Me.lblResponsibleDate.Name = "lblResponsibleDate"
        Me.lblResponsibleDate.Size = New System.Drawing.Size(124, 17)
        Me.lblResponsibleDate.TabIndex = 69
        Me.lblResponsibleDate.Text = "Responsible Date:"
        '
        'lblRCResponsible
        '
        Me.lblRCResponsible.AutoSize = True
        Me.lblRCResponsible.Location = New System.Drawing.Point(42, 72)
        Me.lblRCResponsible.Name = "lblRCResponsible"
        Me.lblRCResponsible.Size = New System.Drawing.Size(90, 17)
        Me.lblRCResponsible.TabIndex = 68
        Me.lblRCResponsible.Text = "Responsible:"
        '
        'lblRCImmediateAction
        '
        Me.lblRCImmediateAction.AutoSize = True
        Me.lblRCImmediateAction.Location = New System.Drawing.Point(13, 44)
        Me.lblRCImmediateAction.Name = "lblRCImmediateAction"
        Me.lblRCImmediateAction.Size = New System.Drawing.Size(108, 17)
        Me.lblRCImmediateAction.TabIndex = 67
        Me.lblRCImmediateAction.Text = "Imediate Action:"
        '
        'cmbRCMonthAssigned
        '
        Me.cmbRCMonthAssigned.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRCMonthAssigned.FormattingEnabled = True
        Me.cmbRCMonthAssigned.Location = New System.Drawing.Point(685, 99)
        Me.cmbRCMonthAssigned.Name = "cmbRCMonthAssigned"
        Me.cmbRCMonthAssigned.Size = New System.Drawing.Size(119, 24)
        Me.cmbRCMonthAssigned.TabIndex = 66
        '
        'cmbRCStatus
        '
        Me.cmbRCStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRCStatus.FormattingEnabled = True
        Me.cmbRCStatus.Items.AddRange(New Object() {"Open", "Close", "Cancel"})
        Me.cmbRCStatus.Location = New System.Drawing.Point(464, 99)
        Me.cmbRCStatus.Name = "cmbRCStatus"
        Me.cmbRCStatus.Size = New System.Drawing.Size(97, 24)
        Me.cmbRCStatus.TabIndex = 65
        '
        'dtpRCResponsibleDate
        '
        Me.dtpRCResponsibleDate.Location = New System.Drawing.Point(139, 97)
        Me.dtpRCResponsibleDate.Name = "dtpRCResponsibleDate"
        Me.dtpRCResponsibleDate.Size = New System.Drawing.Size(259, 22)
        Me.dtpRCResponsibleDate.TabIndex = 64
        '
        'txbRCResponsible
        '
        Me.txbRCResponsible.Location = New System.Drawing.Point(138, 69)
        Me.txbRCResponsible.Name = "txbRCResponsible"
        Me.txbRCResponsible.Size = New System.Drawing.Size(666, 22)
        Me.txbRCResponsible.TabIndex = 63
        '
        'txbRCImmediateAction
        '
        Me.txbRCImmediateAction.Location = New System.Drawing.Point(138, 41)
        Me.txbRCImmediateAction.Name = "txbRCImmediateAction"
        Me.txbRCImmediateAction.Size = New System.Drawing.Size(666, 22)
        Me.txbRCImmediateAction.TabIndex = 62
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(46, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 17)
        Me.Label3.TabIndex = 60
        Me.Label3.Text = "Root Cause:"
        '
        'cmbRC
        '
        Me.cmbRC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRC.FormattingEnabled = True
        Me.cmbRC.Location = New System.Drawing.Point(138, 10)
        Me.cmbRC.Name = "cmbRC"
        Me.cmbRC.Size = New System.Drawing.Size(666, 24)
        Me.cmbRC.TabIndex = 61
        '
        'lblRCRecordsOTDRootCauseDeliveryFail
        '
        Me.lblRCRecordsOTDRootCauseDeliveryFail.AutoSize = True
        Me.lblRCRecordsOTDRootCauseDeliveryFail.Location = New System.Drawing.Point(7, 149)
        Me.lblRCRecordsOTDRootCauseDeliveryFail.Name = "lblRCRecordsOTDRootCauseDeliveryFail"
        Me.lblRCRecordsOTDRootCauseDeliveryFail.Size = New System.Drawing.Size(77, 17)
        Me.lblRCRecordsOTDRootCauseDeliveryFail.TabIndex = 59
        Me.lblRCRecordsOTDRootCauseDeliveryFail.Text = "Records: 0"
        '
        'GridOTDRootCauseDeliveryFail
        '
        Me.GridOTDRootCauseDeliveryFail.AllowUserToAddRows = False
        Me.GridOTDRootCauseDeliveryFail.AllowUserToDeleteRows = False
        Me.GridOTDRootCauseDeliveryFail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridOTDRootCauseDeliveryFail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridOTDRootCauseDeliveryFail.Location = New System.Drawing.Point(7, 170)
        Me.GridOTDRootCauseDeliveryFail.Name = "GridOTDRootCauseDeliveryFail"
        Me.GridOTDRootCauseDeliveryFail.ReadOnly = True
        Me.GridOTDRootCauseDeliveryFail.RowTemplate.Height = 24
        Me.GridOTDRootCauseDeliveryFail.Size = New System.Drawing.Size(863, 398)
        Me.GridOTDRootCauseDeliveryFail.TabIndex = 58
        '
        'frmCSFails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1262, 603)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmCSFails"
        Me.Text = "frmCSFails"
        Me.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.GridRC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridOTDRootCauseDeliveryFail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents lblRC As System.Windows.Forms.Label
    Friend WithEvents lblRCRecordsGridRC As System.Windows.Forms.Label
    Friend WithEvents GridRC As System.Windows.Forms.DataGridView
    Friend WithEvents txbRCDescription As System.Windows.Forms.TextBox
    Friend WithEvents lblRCMonthAssigned As System.Windows.Forms.Label
    Friend WithEvents lblRCStatus As System.Windows.Forms.Label
    Friend WithEvents lblResponsibleDate As System.Windows.Forms.Label
    Friend WithEvents lblRCResponsible As System.Windows.Forms.Label
    Friend WithEvents lblRCImmediateAction As System.Windows.Forms.Label
    Friend WithEvents cmbRCMonthAssigned As System.Windows.Forms.ComboBox
    Friend WithEvents cmbRCStatus As System.Windows.Forms.ComboBox
    Friend WithEvents dtpRCResponsibleDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txbRCResponsible As System.Windows.Forms.TextBox
    Friend WithEvents txbRCImmediateAction As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbRC As System.Windows.Forms.ComboBox
    Friend WithEvents lblRCRecordsOTDRootCauseDeliveryFail As System.Windows.Forms.Label
    Friend WithEvents GridOTDRootCauseDeliveryFail As System.Windows.Forms.DataGridView
    Friend WithEvents btnRCDeleteDescription As System.Windows.Forms.Button
    Friend WithEvents btnRCAddUpdateDescription As System.Windows.Forms.Button
    Friend WithEvents lblRCDueDate As System.Windows.Forms.Label
    Friend WithEvents lblRCPO As System.Windows.Forms.Label
    Friend WithEvents lblRCIDQB As System.Windows.Forms.Label
    Friend WithEvents lblRCSONumber As System.Windows.Forms.Label
    Friend WithEvents btnRCDeleteRC As System.Windows.Forms.Button
    Friend WithEvents btnRCAddUpdateRC As System.Windows.Forms.Button
    Friend WithEvents lblRCIDDescription As System.Windows.Forms.Label
    Friend WithEvents lblRCIDRC As System.Windows.Forms.Label
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnRCClear1 As System.Windows.Forms.Button
    Friend WithEvents btnRCClear2 As System.Windows.Forms.Button
    Friend WithEvents lblRCCustomerCode As System.Windows.Forms.Label
End Class
