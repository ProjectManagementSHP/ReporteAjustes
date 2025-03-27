Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data
Imports System.IO
Imports System.Net
Public Class frmCSFails
    Dim strCnn As String = "Server=SHPLAPSIS01\SQLEXPRESS2012; Database=SEA; User ID=sa;Password=Fernanda25"
    'Dim strCnn As String = "Server=10.17.182.12\SQLEXPRESS2012;Database=SEA;User ID=sa;Password=SHPadmin14%"
    Dim cnn As New SqlConnection(strCnn)
    Private tblMeses As New DataTable
    Private tblRC As New DataTable
    Dim IDRCRCTemp, RCRCTemp, IDQBRCTemp, SONumberRCTemp, CustomerCodeRCTemp, ImmediateActionRCTemp, ResponsibleRCTemp, ResponsibleDateRCTemp, StatusRCTemp, MonthAssignedRCTemp, ModifyDateRCTemp As String
    Dim RCDescriptionTemp As String
    Private Sub frmCSFails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadRC()
    End Sub

    Private Sub LoadRC()
        GeneraColumnasRC()
        CargaComboMeses()
        CargaComboRC()
        CargaRCGridDescriptions()
        BorraRC()
        BorraRCCusAll()
        CargaRCGridIssues(lblRCSONumber.Text, lblRCIDQB.Text)
    End Sub
    Private Sub CargaComboRC()
        tblRC.Clear()
        Using TN As New DataTable
            Dim Edo As String
            Dim AdjusmentType As String = "", Amount As Decimal = 0
            Try 'tblItemsFinantialInventoryControlTempforProductionProcess" & sTempTableName 
                Dim cmd As SqlCommand
                Dim dr As SqlDataReader
                Dim Query As String = "SELECT ID, RC FROM tblCustomerServiceOTDRootCauseDescriptions "
                cmd = New SqlCommand(Query, cnn)
                'cmd.CommandType = CommandType.Text
                'cmd.Parameters.Add("@Dia", SqlDbType.NVarChar).Value = Dia
                cnn.Open()
                dr = cmd.ExecuteReader
                tblRC.Load(dr)
                cnn.Close()
                With cmbRC
                    .DataSource = tblRC
                    .DisplayMember = "RC"
                    .ValueMember = "ID"
                End With
            Catch ex As Exception
                Edo = cnn.State.ToString
                If Edo = "Open" Then cnn.Close()
                MessageBox.Show(ex.Message, "Error Loading CargaComboRC")
            End Try
        End Using
    End Sub
    Private Sub CargaComboMeses()
        tblMeses.Clear()
        Dim Mes As String = "", MesFecha As Date
        Dim englishCultureInfo = New Globalization.CultureInfo("en-US")
        For NM As Integer = 1 To 12
            MesFecha = CStr(NM) + "-01-2017"
            Mes = MonthName(NM, True)
            Mes = GetMonthName(MesFecha, englishCultureInfo)
            tblMeses.Rows.Add(Mes)
        Next
        With cmbRCMonthAssigned
            .DataSource = tblMeses
            .DisplayMember = "Mes"
            .ValueMember = "Mes"
        End With
    End Sub
    Private Sub GeneraColumnasRC()
        Dim WC1 As DataColumn = tblMeses.Columns.Add("Mes", Type.GetType("System.String"))
        Dim WC2 As DataColumn = tblRC.Columns.Add("RC", Type.GetType("System.String"))
    End Sub
    Private Sub CargaRCGridDescriptions()
        Using TN As New DataTable
            Dim Edo As String
            Try 'tblItemsFinantialInventoryControlTempforProductionProcess" & sTempTableName 
                Dim cmd As SqlCommand
                Dim dr As SqlDataReader
                Dim Query As String = "SELECT * FROM tblCustomerServiceOTDRootCauseDescriptions "
                cmd = New SqlCommand(Query, cnn)
                'cmd.CommandT ype = CommandType.Text
                'cmd.Parameters.Add("@Dia", SqlDbType.NVarChar).Value = Dia
                cnn.Open()
                dr = cmd.ExecuteReader
                TN.Load(dr)
                cnn.Close()
                With GridRC
                    .DataSource = TN
                    .AutoResizeColumns()
                End With
                lblRCRecordsGridRC.Text = "Records: " + TN.Rows.Count.ToString
            Catch ex As Exception
                Edo = cnn.State.ToString
                If Edo = "Open" Then cnn.Close()
                MessageBox.Show(ex.Message, "Error Loading CargaComboRC")
            End Try
        End Using
    End Sub
    Private Sub CargaRCGridIssues(ByVal SONumber As String, ByVal IDQB As String)
        Using TN As New DataTable
            Dim Edo As String
            Dim AdjusmentType As String = "", Amount As Decimal = 0
            Try 'tblItemsFinantialInventoryControlTempforProductionProcess" & sTempTableName 
                Dim cmd As SqlCommand
                Dim dr As SqlDataReader
                Dim Query As String = "SELECT * FROM tblCustomerServiceOTDRootCauseDeliveryFail WHERE SONumber=@SONumber AND IDQB=@IDQB ORDER BY CreatedDate"
                cmd = New SqlCommand(Query, cnn)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@SONumber", SqlDbType.NVarChar).Value = SONumber
                cmd.Parameters.Add("@IDQB", SqlDbType.NVarChar).Value = IDQB
                cnn.Open()
                dr = cmd.ExecuteReader
                TN.Load(dr)
                cnn.Close()
                With GridOTDRootCauseDeliveryFail
                    .DataSource = TN
                    .AutoResizeColumns()
                End With
                lblRCRecordsGridRC.Text = "Records: " + TN.Rows.Count.ToString
            Catch ex As Exception
                Edo = cnn.State.ToString
                If Edo = "Open" Then cnn.Close()
                MessageBox.Show(ex.Message, "Error Loading CargaComboRC")
            End Try
        End Using
    End Sub
    Private Function GetMonthName(d As DateTime, ci As Globalization.CultureInfo) As String
        Return ci.DateTimeFormat.GetMonthName(d.Month)
    End Function

    Private Sub GridOTDRootCauseDeliveryFail_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridOTDRootCauseDeliveryFail.CellClick
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Dim row As DataGridViewRow = Me.GridOTDRootCauseDeliveryFail.CurrentRow
        Dim XX As Long = System.Convert.ToInt64(Val(row.Index.ToString))
        If IsNumeric(XX) Then
            lblRCIDRC.Text = GridOTDRootCauseDeliveryFail.Rows(XX).Cells("IDRC").Value.ToString
            cmbRC.Text = GridOTDRootCauseDeliveryFail.Rows(XX).Cells("RC").Value.ToString
            txbRCImmediateAction.Text = GridOTDRootCauseDeliveryFail.Rows(XX).Cells("ImmediateAction").Value.ToString
            txbRCResponsible.Text = GridOTDRootCauseDeliveryFail.Rows(XX).Cells("Responsible").Value.ToString
            dtpRCResponsibleDate.Value = CDate(GridOTDRootCauseDeliveryFail.Rows(XX).Cells("ResponsibleDate").Value.ToString)
            cmbRCStatus.Text = GridOTDRootCauseDeliveryFail.Rows(XX).Cells("Status").Value.ToString
            cmbRCMonthAssigned.Text = GridOTDRootCauseDeliveryFail.Rows(XX).Cells("MonthAssigned").Value.ToString
            RCRCTemp = GridOTDRootCauseDeliveryFail.Rows(XX).Cells("RC").Value.ToString
            ImmediateActionRCTemp = GridOTDRootCauseDeliveryFail.Rows(XX).Cells("ImmediateAction").Value.ToString
            ResponsibleRCTemp = GridOTDRootCauseDeliveryFail.Rows(XX).Cells("Responsible").Value.ToString
            ResponsibleDateRCTemp = CDate(GridOTDRootCauseDeliveryFail.Rows(XX).Cells("ResponsibleDate").Value.ToString)
            StatusRCTemp = GridOTDRootCauseDeliveryFail.Rows(XX).Cells("Status").Value.ToString
            MonthAssignedRCTemp = GridOTDRootCauseDeliveryFail.Rows(XX).Cells("MonthAssigned").Value.ToString
            btnRCAddUpdateRC.Text = "Update"
            btnRCDeleteRC.Enabled = True
        End If

        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub
    Private Sub GridOTDRootCauseDeliveryFail_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridOTDRootCauseDeliveryFail.CellContentClick
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub
    Private Sub GridOTDRootCauseDeliveryFail_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridOTDRootCauseDeliveryFail.CellDoubleClick
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub btnRCAddUpdateRC_Click(sender As Object, e As EventArgs) Handles btnRCAddUpdateRC.Click
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        If btnRCAddUpdateRC.Text = "Add" Then
            Dim nb As String = BuscaNumeroDeReferencia("tblCustomerServiceOTDRootCauseDeliveryFail", "IDRC")
            nb = GeneraSerialIDRCReference(nb, "tblCustomerServiceOTDRootCauseDeliveryFail")
            InsertRC(nb, cmbRC.Text, lblRCIDQB.Text, lblRCSONumber.Text, lblRCCustomerCode.Text, txbRCImmediateAction.Text, txbRCResponsible.Text, dtpRCResponsibleDate.Value.ToString("dd-MMM-yyyy"), cmbRCStatus.Text, cmbRCMonthAssigned.Text, "")
        ElseIf btnRCAddUpdateRC.Text = "Update" Then
            CambiosRC()
            BorraRCCusNew()
        End If
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub btnRCDeleteRC_Click(sender As Object, e As EventArgs) Handles btnRCDeleteRC.Click
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        If lblRCIDRC.Text <> "" Then
            DeleteRC(lblRCIDRC.Text)
        End If
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub GridRC_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridRC.CellClick
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Dim row As DataGridViewRow = Me.GridRC.CurrentRow
        Dim XX As Long = System.Convert.ToInt64(Val(row.Index.ToString))
        If XX > -1 Then
            lblRCIDDescription.Text = GridRC.Rows(XX).Cells("ID").Value.ToString
            RCDescriptionTemp = GridRC.Rows(XX).Cells("RC").Value.ToString
            txbRCDescription.Text = GridRC.Rows(XX).Cells("RC").Value.ToString
            btnRCAddUpdateDescription.Text = "Update"
            btnRCDeleteDescription.Enabled = True
        End If

        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub
    Private Sub GridRC_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridRC.CellContentClick
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub
    Private Sub GridRC_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridRC.CellDoubleClick
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub btnRCAddUpdateDescription_Click(sender As Object, e As EventArgs) Handles btnRCAddUpdateDescription.Click
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        If btnRCAddUpdateDescription.Text = "Add" Then
            InsertRCDescription(txbRCDescription.Text, "")
        ElseIf btnRCAddUpdateDescription.Text = "Update" Then
            If RCDescriptionTemp <> txbRCDescription.Text Then UpdateRCDescription(lblRCIDDescription.Text, txbRCDescription.Text, "")
        End If
        CargaComboRC()
        CargaRCGridDescriptions()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub btnRCDeleteDescription_Click(sender As Object, e As EventArgs) Handles btnRCDeleteDescription.Click
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        If lblRCIDDescription.Text <> "" And IsNumeric(lblRCIDDescription.Text) Then
            DeleteRCIDDescription(lblRCIDDescription.Text)
            CargaComboRC()
            CargaRCGridDescriptions()
        End If
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub btnRCClear2_Click(sender As Object, e As EventArgs) Handles btnRCClear2.Click
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        BorraRCCusNew()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub btnRCClear1_Click(sender As Object, e As EventArgs) Handles btnRCClear1.Click
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        BorraRC()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub
    Private Sub BorraRC()
        txbRCDescription.Text = ""
        lblRCIDDescription.Text = ""
        btnRCAddUpdateDescription.Text = "Add"
        btnRCDeleteDescription.Enabled = False
    End Sub
    Private Sub BorraRCCusAll()
        cmbRC.SelectedIndex = 0
        cmbRCMonthAssigned.SelectedIndex = 0
        cmbRCStatus.SelectedIndex = 0
        dtpRCResponsibleDate.Value = Now
        txbRCImmediateAction.Text = ""
        txbRCResponsible.Text = ""
        lblRCIDDescription.Text = ""
        lblRCSONumber.Text = ""
        lblRCIDQB.Text = ""
        lblRCPO.Text = ""
        lblRCDueDate.Text = ""
        lblRCCustomerCode.Text = ""
        lblRCIDRC.Text = ""
        btnRCAddUpdateRC.Text = "Add"
        btnRCDeleteRC.Enabled = False
        btnRCDeleteDescription.Enabled = False
    End Sub
    Private Sub BorraRCCusNew()
        cmbRC.SelectedIndex = 0
        cmbRCMonthAssigned.SelectedIndex = 0
        cmbRCStatus.SelectedIndex = 0
        dtpRCResponsibleDate.Value = Now
        txbRCImmediateAction.Text = ""
        txbRCResponsible.Text = ""
        lblRCIDDescription.Text = ""
        lblRCIDRC.Text = ""
        'lblRCSONumber.Text = ""
        'lblRCIDQB.Text = ""
        'lblRCPO.Text = ""
        'lblRCDueDate.Text = ""
        'lblRCCustomerCode.Text = ""
        btnRCAddUpdateRC.Text = "Add"
        btnRCDeleteRC.Enabled = False
    End Sub

    Private Sub InsertRCDescription(ByVal RC As String, ByVal UserID As String)
        Dim Edo As String = ""
        Try 'Definimos el query del insert
            Dim Query As String = "INSERT INTO tblCustomerServiceOTDRootCauseDescriptions (RC, CreatedBy, CreatedDate) VALUES (@RC, @CreatedBy, @CreatedDate)"
            Dim cmd As SqlCommand = New SqlCommand(Query, cnn)
            cmd.CommandType = CommandType.Text 'Asignamos los valores de cada campo
            cmd.Parameters.Add("@RC", SqlDbType.NVarChar).Value = RC
            cmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar).Value = UserID
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = Now
            cnn.Open() 'abre la conexion
            cmd.ExecuteNonQuery() 'realiza el query
            cnn.Close() 'cierra la conexion
            txbRCDescription.Text = ""
            lblRCIDDescription.Text = ""
        Catch ex As Exception
            Edo = cnn.State.ToString
            If Edo = "Open" Then cnn.Close()
            MessageBox.Show(ex.Message, "Error into the insert of InsertRCDescription") 'despliega un mesaje si hay un error
        End Try
    End Sub

    Private Sub UpdateRCDescription(ByVal ID As String, ByVal RC As String, ByVal UserID As String)
        Dim Edo As String
        Try 'Definimos el query del insert
            Dim Query As String = "UPDATE tblCustomerServiceOTDRootCauseDescriptions SET RC=@RC, ModifyBy=@ModifyBy, ModifyDate=@ModifyDate WHERE ID=@ID"
            Dim cmd As SqlCommand = New SqlCommand(Query, cnn)
            cmd.CommandType = CommandType.Text
            cmd.Parameters.Add("@RC", SqlDbType.NVarChar).Value = RC
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID
            cmd.Parameters.Add("@ModifyBy", SqlDbType.NVarChar).Value = UserID
            cmd.Parameters.Add("@ModifyDate", SqlDbType.DateTime).Value = Now
            cnn.Open() 'abre la conexion
            cmd.ExecuteNonQuery() 'realiza el query
            cnn.Close() 'cierra la conexion
            txbRCDescription.Text = ""
            lblRCIDDescription.Text = ""
        Catch ex As Exception
            Edo = cnn.State.ToString
            If Edo = "Open" Then cnn.Close()
            MessageBox.Show(ex.Message + vbNewLine + "Error traying to update " + RC, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) 'despliega un mesaje si hay un error
        End Try
    End Sub

    Private Sub InsertRC(ByVal IDRC As String, ByVal RC As String, ByVal IDQB As String, ByVal SONumber As String, ByVal CustomerCode As String, ByVal ImmediateAction As String, ByVal Responsible As String, ByVal ResponsibleDate As String, ByVal Status As String, ByVal MonthAssigned As String, ByVal CreatedBy As String)
        Dim Edo As String = ""
        'IDRC, RC, IDQB, SONumber, CustomerCode, ImmediateAction, Responsible, ResponsibleDate, Status, MonthAssigned, CreatedDate, CreatedBy
        Try 'Definimos el query del insert
            Dim Query As String = "INSERT INTO tblCustomerServiceOTDRootCauseDeliveryFail (IDRC, RC, IDQB, SONumber, CustomerCode, ImmediateAction, Responsible, ResponsibleDate, Status, MonthAssigned, CreatedDate, CreatedBy) VALUES (@IDRC, @RC, @IDQB, @SONumber, @CustomerCode, @ImmediateAction, @Responsible, @ResponsibleDate, @Status, @MonthAssigned, @CreatedDate, @CreatedBy)"
            Dim cmd As SqlCommand = New SqlCommand(Query, cnn)
            cmd.CommandType = CommandType.Text 'Asignamos los valores de cada campo
            cmd.Parameters.Add("@IDRC", SqlDbType.NVarChar).Value = IDRC
            cmd.Parameters.Add("@SONumber", SqlDbType.NVarChar).Value = SONumber
            cmd.Parameters.Add("@RC", SqlDbType.NVarChar).Value = RC
            cmd.Parameters.Add("@IDQB", SqlDbType.NVarChar).Value = IDQB
            cmd.Parameters.Add("@CustomerCode", SqlDbType.NVarChar).Value = CustomerCode
            cmd.Parameters.Add("@ImmediateAction", SqlDbType.NVarChar).Value = ImmediateAction
            cmd.Parameters.Add("@Responsible", SqlDbType.NVarChar).Value = Responsible
            cmd.Parameters.Add("@ResponsibleDate", SqlDbType.Date).Value = ResponsibleDate
            cmd.Parameters.Add("@Status", SqlDbType.NVarChar).Value = Status
            cmd.Parameters.Add("@MonthAssigned", SqlDbType.NVarChar).Value = MonthAssigned
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = Now
            cmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar).Value = CreatedBy
            '    cmd.Parameters.Add("@", SqlDbType.NVarChar).Value = RC
            cnn.Open() 'abre la conexion
            cmd.ExecuteNonQuery() 'realiza el query
            cnn.Close() 'cierra la conexion
            BorraRCCusNew()
            CargaRCGridIssues(lblRCSONumber.Text, lblRCIDQB.Text)
        Catch ex As Exception
            Edo = cnn.State.ToString
            If Edo = "Open" Then cnn.Close()
            MessageBox.Show(ex.Message, "Error into the insert of InsertRC") 'despliega un mesaje si hay un error
        End Try
    End Sub

    Private Sub UpdateRC(ByVal TipoDato As String, ByVal Campo As String, ByVal Dato As String, ByVal IDRC As String, ByVal UserID As String)
        Dim Edo As String
        Try 'Definimos el query del insert
            Dim Query As String = "UPDATE tblCustomerServiceOTDRootCauseDeliveryFail SET " + Campo + "=@Dato WHERE IDRC=@IDRC"
            Dim cmd As SqlCommand = New SqlCommand(Query, cnn)
            cmd.CommandType = CommandType.Text
            Select Case TipoDato
                Case "Entero"
                    cmd.Parameters.Add("@Dato", SqlDbType.BigInt).Value = Dato
                Case "Decimal"
                    cmd.Parameters.Add("@Dato", SqlDbType.Decimal).Value = Dato
                Case "Fecha"
                    cmd.Parameters.Add("@Dato", SqlDbType.DateTime).Value = Dato
                Case "Cadena"
                    cmd.Parameters.Add("@Dato", SqlDbType.NVarChar).Value = Dato
                Case "Boleano"
                    cmd.Parameters.Add("@Dato", SqlDbType.Bit).Value = CInt(Dato)
            End Select
            cmd.Parameters.Add("@IDRC", SqlDbType.NVarChar).Value = IDRC
            cmd.Parameters.Add("@ModifyBy", SqlDbType.NVarChar).Value = UserID
            cmd.Parameters.Add("@ModifyDate", SqlDbType.DateTime).Value = Now
            cnn.Open() 'abre la conexion
            cmd.ExecuteNonQuery() 'realiza el query
            Edo = cnn.State.ToString
            If Edo = "Open" Then cnn.Close() 'cierra la conexion
        Catch ex As Exception
            MessageBox.Show(ex.Message + vbNewLine + "Error traying to update the Sales Order " + CStr(Dato), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) 'despliega un mesaje si hay un error
        End Try
        Edo = cnn.State.ToString
        If Edo = "Open" Then cnn.Close()
    End Sub

    Private Sub CambiosRC()
        'IDRC, RC, IDQB, SONumber, CustomerCode, ImmediateAction, Responsible, ResponsibleDate, Status, MonthAssigned, CreatedDate, CreatedBy
        If RCRCTemp <> cmbRC.Text Then
            UpdateRC("Cadena", "RC", cmbRC.Text, lblRCIDRC.Text, "")
        End If
        If ImmediateActionRCTemp <> txbRCImmediateAction.Text Then
            UpdateRC("Cadena", "ImmediateAction", txbRCImmediateAction.Text, lblRCIDRC.Text, "")
        End If
        If ResponsibleRCTemp <> txbRCResponsible.Text Then
            UpdateRC("Cadena", "Responsible", txbRCResponsible.Text, lblRCIDRC.Text, "")
        End If
        If ResponsibleDateRCTemp <> dtpRCResponsibleDate.Value.ToShortDateString Then
            UpdateRC("Fecha", "ResponsibleDate", dtpRCResponsibleDate.Value.ToString, lblRCIDRC.Text, "")
        End If
        If StatusRCTemp <> cmbRCStatus.Text Then
            UpdateRC("Cadena", "Status", cmbRCStatus.Text, lblRCIDRC.Text, "")
        End If
        If MonthAssignedRCTemp <> cmbRCMonthAssigned.Text Then
            UpdateRC("Cadena", "MonthAssigned", cmbRCMonthAssigned.Text, lblRCIDRC.Text, "")
        End If
        BorraRCCusNew()
        CargaRCGridIssues(lblRCSONumber.Text, lblRCIDQB.Text)
    End Sub

    Private Function GeneraSerialIDRCReference(ByVal PreviousSerial As String, ByVal Tabla As String)
        Dim Numero, ascii1, ascii2, ascii3 As Long ', ascii4
        Dim NumeroString, Letras, letra1, letra2, letra3, NewSerial As String 'letra4,
        NewSerial = ""
        Dim TNewSerial As String = ""
        Select Case Tabla
            Case "tblCustomerServiceOTDRootCauseDeliveryFail"
                TNewSerial = "RC"
                PreviousSerial = Microsoft.VisualBasic.Mid(PreviousSerial, 3)
        End Select
        Try
            If PreviousSerial <> "" Then
                Letras = Microsoft.VisualBasic.Left(PreviousSerial, 3)
                Numero = Convert.ToInt64(Microsoft.VisualBasic.Right(PreviousSerial, 5))
                If Numero < 99999 Then
                    Numero = Numero + 1
                    NumeroString = Numero.ToString
                    If NumeroString.Length < 4 Then
                        For count As Integer = NumeroString.Length To 6
                            NumeroString = "0" + NumeroString
                        Next
                    End If
                    NewSerial = Letras + NumeroString
                ElseIf Numero = 99999 Then
                    NumeroString = "00001"
                    letra1 = Mid(Letras, 1, 1)
                    letra2 = Mid(Letras, 2, 1)
                    letra3 = Mid(Letras, 3, 1)
                    'letra4 = Mid(Letras, 4, 1)
                    ascii1 = Asc(letra1)
                    ascii2 = Asc(letra2)
                    ascii3 = Asc(letra3)
                    'ascii4 = Asc(letra4)
                    'If ascii4 < 90 Then
                    '    ascii4 = ascii4 + 1
                    If ascii3 < 90 Then 'ascii4 = 90 And 
                        'ascii4 = 65
                        ascii3 = ascii3 + 1
                    ElseIf ascii3 = 90 And ascii2 < 90 Then 'ascii4 = 90 And
                        'ascii4 = 65
                        ascii3 = 65
                        ascii2 = ascii2 + 1
                    ElseIf ascii3 = 90 And ascii2 = 90 And ascii1 < 90 Then 'ascii4 = 90 And
                        'ascii4 = 65
                        ascii3 = 65
                        ascii2 = 65
                        ascii1 = ascii1 + 1
                    ElseIf ascii3 = 90 And ascii2 = 90 And ascii1 = 90 Then 'ascii4 = 90 And
                        'ascii4 = 65
                        ascii3 = 65
                        ascii2 = 65
                        ascii1 = 65
                    End If
                    letra1 = Convert.ToChar(ascii1).ToString
                    letra2 = Convert.ToChar(ascii2).ToString
                    letra3 = Convert.ToChar(ascii3).ToString
                    'letra4 = Convert.ToChar(ascii4).ToString
                    Letras = letra1 + letra2 + letra3 '+ letra4
                    NewSerial = Letras + NumeroString
                End If
            ElseIf PreviousSerial = "" Then
                Letras = "AAA"
                NumeroString = "00001"
                NewSerial = Letras + NumeroString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        TNewSerial += NewSerial
        Return TNewSerial
    End Function
    'Funcion para encontrar el ultimo numero de referencia registrado en la base de datos
    Private Function BuscaNumeroDeReferencia(ByVal Tabla As String, ByVal Campo As String)
        Dim Edo As String = ""
        Using TN As New System.Data.DataTable 'Despliega los materiales 
            Dim PN As String = ""
            Dim Qty As Decimal = 0
            Dim UM As String = ""
            Dim Query As String = "SELECT TOP 1 " + Campo + " FROM " + Tabla + " ORDER BY " + Campo + " DESC " '"tblCustomerServiceSO","SONumber"
            Try
                Dim dr As SqlDataReader
                Dim cmd As SqlCommand = New SqlCommand(Query, cnn)
                'cmd.CommandType = CommandType.Text
                'cmd.Parameters.Add("@Valor1", SqlDbType.NVarChar).Value = ValorStatus
                'cmd.Parameters.Add("@Category", SqlDbType.NVarChar).Value = TipoCategoria
                cnn.Open()
                dr = cmd.ExecuteReader
                TN.Load(dr) ''Llena la tabla
                Edo = cnn.State.ToString
                cnn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString + "Error loading materials with requierment, Muestra Materiales function", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            Edo = cnn.State.ToString
            If Edo = "Open" Then cnn.Close()
            If TN.Rows.Count = 0 Then Edo = ""
            If Tabla = "tblCustomerServiceOTDRootCauseDeliveryFail" Then If TN.Rows.Count > 0 Then Edo = TN.Rows(0).Item("IDQB").ToString
        End Using
        Return Edo
    End Function

    Private Sub DeleteRCIDDescription(ByVal ID As String)
        Dim Edo As String 'VendorCode, VendorID, ShipTo, ShippingMethod, Terms, DeliveryDate, Notes, SubTotal, ShippingCost, Currency, TaxRate, Tax, Total, Status, CreatedBy, CreatedDate
        Dim Query As String = "DELETE FROM tblCustomerServiceOTDRootCauseDescriptions WHERE ID=@ID"
        Try 'Definimos el query del insert
            Dim cmd As SqlCommand = New SqlCommand(Query, cnn)
            cmd.CommandType = CommandType.Text
            cmd.Parameters.Add("@ID", SqlDbType.NVarChar).Value = ID
            cnn.Open() 'abre la conexion
            cmd.ExecuteNonQuery() 'realiza el query
            cnn.Close() 'cierra la conexion
            txbRCDescription.Text = ""
            lblRCIDDescription.Text = ""
            btnRCDeleteDescription.Enabled = False
        Catch ex As Exception
            Edo = cnn.State.ToString
            If Edo = "Open" Then cnn.Close()
            MessageBox.Show(ex.Message + "Error into the delete a IDDescription", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) 'despliega un mesaje si hay un error
        End Try
    End Sub

    Private Sub DeleteRC(ByVal IDRC As String)
        Dim Edo As String 'VendorCode, VendorID, ShipTo, ShippingMethod, Terms, DeliveryDate, Notes, SubTotal, ShippingCost, Currency, TaxRate, Tax, Total, Status, CreatedBy, CreatedDate
        Dim Query As String = "DELETE FROM tblCustomerServiceOTDRootCauseDeliveryFail WHERE IDRC=@IDRC"
        Try 'Definimos el query del insert
            Dim cmd As SqlCommand = New SqlCommand(Query, cnn)
            cmd.CommandType = CommandType.Text
            cmd.Parameters.Add("@IDRC", SqlDbType.NVarChar).Value = IDRC
            cnn.Open() 'abre la conexion
            cmd.ExecuteNonQuery() 'realiza el query
            cnn.Close() 'cierra la conexion
            BorraRCCusNew()
            CargaRCGridIssues(lblRCSONumber.Text, lblRCIDQB.Text)
            btnRCDeleteRC.Enabled = False
        Catch ex As Exception
            Edo = cnn.State.ToString
            If Edo = "Open" Then cnn.Close()
            MessageBox.Show(ex.Message + "Error into the delete a IDDescription", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) 'despliega un mesaje si hay un error
        End Try
    End Sub
End Class