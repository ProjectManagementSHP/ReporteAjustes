Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data
Imports System.IO
Imports System.Net
Imports System.DirectoryServices
Imports System.Text
Imports System.String
Public Class frmEmailReportesDeajustesPorCorreo
    'Dim strCnn As String = "Server=SHPLAPSIS01\SQLEXPRESS2012; Database=SEA; User ID=sa;Password=SHPadmin14%"
    Dim strCnn As String = "Server=10.17.182.12\SQLEXPRESS2012;Database=SEA;User ID=sa;Password=SHPadmin14%"
    Dim cnn As New SqlConnection(strCnn)
    Private tblAjustes As New DataTable
    Dim QtyMovimientos, QtyPsitivos, QtyNegativos, QtyPsitivosBB, QtyNegativosBB, QtyMovimientosBB As Integer
    Dim ValorPositivos, ValorNegativos, ValorPositivosBB, ValorNegativosBB As Decimal
    Private Sub frmEmailReportesDeajustesPorCorreo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim Dia As String = Now.AddDays(-1).ToString("dd-MMM-yyyy") 'Este es solo para correr la app si fallo la tarea programada
        Dim Dia As String = Now.ToString("dd-MMM-yyyy")
        Dim intMonth As Integer = Now.Month
        Dim intYear As Integer = CInt(Now.Year)
        Dim UltimoDia As Date = DateSerial(intYear, intMonth + 1, 0)
        Dim DiaF As Date = Now.ToShortDateString
        Dim Mes As String = ""
        dtpFrom.Value = CDate(CStr(intMonth) + "/1/" + CStr(intYear))
        'DiaF = CDate("31-Oct-2024")
        Dia = DiaF.ToString("dd-MMM-yyyy")
        'DiaF = "3/31/2019"
        'UltimoDia = "31-Oct-2024"
        '***************************** Reporte Solo Diario *******************************************
        'CargaDatos(Dia)
        '*********************************************************************************************
        '***************************** Reporte Solo Mensual ******************************************
        'se genera en base a los controles del form
        '*********************************************************************************************
        '***************************** Reporte Normal ************************************************
        If UltimoDia = DiaF Then
            Select Case intMonth
                Case 1
                    Mes = "Enero de " + CStr(intYear)
                Case 2
                    Mes = "Febrero de " + CStr(intYear)
                Case 3
                    Mes = "Marzo de " + CStr(intYear)
                Case 4
                    Mes = "Abril de " + CStr(intYear)
                Case 5
                    Mes = "Mayo de " + CStr(intYear)
                Case 6
                    Mes = "Junio de " + CStr(intYear)
                Case 7
                    Mes = "Julio de " + CStr(intYear)
                Case 8
                    Mes = "Agosto de " + CStr(intYear)
                Case 9
                    Mes = "Septiembre de " + CStr(intYear)
                Case 10
                    Mes = "Octubre de " + CStr(intYear)
                Case 11
                    Mes = "Noviembre de " + CStr(intYear)
                Case 12
                    Mes = "Diciembre de " + CStr(intYear)
            End Select
            Dim FechaInicio As String = CDate(CStr(intMonth) + "/1/" + CStr(intYear)).ToString("dd-MMM-yyyy")
            'FechaInicio = "01-Mar-2019"
            'Dia = "31-Mar-2019"
            'CargaDatos(Dia)
            '  System.Threading.Thread.Sleep(60000)
            CargaDatosMensual(Dia, FechaInicio, Mes)
            'System.Threading.Thread.Sleep(60000)
            ' CargaDatosMensual("31-Oct-2024", "01-Oct-2024", "Octubre de 2024")
        Else
            CargaDatos(Dia)
            'CargaDatos("10-Oct-2024")

        End If
        '*********************************************************************************************
        Application.Exit()
    End Sub
    Private Sub CargaDatosMensual(ByVal Dia As String, ByVal FechaInicio As String, ByVal Mes As String)
        tblAjustes.Clear()
        Using TN As New DataTable
            Dim Edo, PN, BinBalance As String
            Dim AdjusmentType As String = "", Amount As Decimal = 0
            'Try 'tblItemsFinantialInventoryControlTempforProductionProcess" & sTempTableName 
            Dim cmd As SqlCommand
                Dim dr As SqlDataReader
            Dim Query As String = "SELECT tblItemsTags.Tag, tblItemsTags.PN, tblItemsTags.Balance, tblItemsAdjustmentTAGs.AdjusmentType, (tblItemsAdjustmentTAGs.QtyNew-tblItemsAdjustmentTAGs.QtyActual) AS Diff, tblItemsAdjustmentTAGs.QtyActual, tblItemsAdjustmentTAGs.QtyNew, tblItemsAdjustmentTAGs.Amount, tblItemsAdjustmentTAGs.CreatedDate, tblItemsAdjustmentTAGs.CreatedBy, tblItemsAdjustmentTAGs.Reason, tblItemsAdjustmentTAGs.Notes, tblItemsAdjustmentTAGs.ApprovedBy, tblItemsAdjustmentTAGs.ScrapCategory,tblItemsAdjustmentTAGs.AjusteUsuario,tblItemsAdjustmentTAGs.AdditionalNotes FROM tblItemsTags INNER JOIN tblItemsAdjustmentTAGs ON tblItemsTags.TAG = tblItemsAdjustmentTAGs.TAG WHERE CAST(tblItemsAdjustmentTAGs.Createddate AS DATE) BETWEEN @FechaInicio AND @FechaFin ORDER BY tblItemsAdjustmentTAGs.CreatedDate ASC"
            cmd = New SqlCommand(Query, cnn)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@FechaInicio", SqlDbType.NVarChar).Value = FechaInicio
                cmd.Parameters.Add("@FechaFin", SqlDbType.NVarChar).Value = Dia
                cnn.Open()
                dr = cmd.ExecuteReader
                tblAjustes.Load(dr)
                cnn.Close()
                QtyMovimientos = 0
                QtyNegativos = 0
                QtyPsitivos = 0
                ValorNegativos = 0
                ValorPositivos = 0
                QtyNegativosBB = 0
                QtyPsitivosBB = 0
                ValorNegativosBB = 0
                ValorPositivosBB = 0
                If tblAjustes.Rows.Count > 0 Then
                    QtyMovimientos = tblAjustes.Rows.Count
                    For NM As Integer = 0 To tblAjustes.Rows.Count - 1
                        AdjusmentType = tblAjustes.Rows(NM).Item("AdjusmentType").ToString
                        Amount = CDec(Val(tblAjustes.Rows(NM).Item("Amount").ToString))
                        PN = tblAjustes.Rows(NM).Item("PN").ToString
                        BinBalance = BuscaSiEsBinBalance(PN)
                        If BinBalance = "False" Then
                            If AdjusmentType = "Negative" Then
                                QtyNegativos += 1
                                ValorNegativos += Amount
                            ElseIf AdjusmentType = "Positive" Then
                                QtyPsitivos += 1
                                ValorPositivos += Amount
                            End If
                        ElseIf BinBalance = "True" Then
                            If AdjusmentType = "Negative" Then
                                QtyNegativosBB += 1
                                ValorNegativosBB += Amount
                            ElseIf AdjusmentType = "Positive" Then
                                QtyPsitivosBB += 1
                                ValorPositivosBB += Amount
                            End If
                        End If
                    Next
                End If
                If Mes <> "" Then
                    'Se envia el reporte de los ajustes
                    EnviaCorreoMensual(Dia, FechaInicio, Mes)
                Else
                    EnviaCorreoReporteManual(Dia, FechaInicio)
                End If
            'Catch ex As Exception
            'Edo = cnn.State.ToString
            'If Edo = "Open" Then cnn.Close()
            'MessageBox.Show(ex.Message, "Error Loading CargaDatos")
            'End Try
        End Using
    End Sub
    Private Sub EnviaCorreoReporteManual(ByVal Dia As String, ByVal FechaInicio As String)
        Try
            Dim DestinatariosTO As String = CargaDestinatarios("RptAjustesFin", "TO") '"jcarlos@specializedharness.com, almacen@specializedharness.com"  '"julio.gallegos@specializedharness.com" '"bgarcia@bitech.net, mespi@specializedharness.com, julio.gallegos@specializedharness.com"
            Dim DestinatariosCC As String = CargaDestinatarios("RptAjustesFin", "CC")
            Dim DestinatariosBCC As String = CargaDestinatarios("RptAjustesFin", "BCC")
            Dim EnviadoPor As String = "shpitreports@gmail.com"
            Dim CorreoAjustes As String = ""
            Dim RutaAjustes As String = ""
            Dim Correo As String = ""
            Dim BanderaDestinatarios As Integer = 0
            If tblAjustes.Rows.Count > 0 Then
                CorreoAjustes += "Cantidad de Movimientos Totales: " + QtyMovimientos.ToString + vbNewLine
                CorreoAjustes += "Valor total de movimientos positivos: $" + CStr(ValorPositivos + ValorPositivosBB) + vbNewLine
                CorreoAjustes += "Valor total de movimientos negativos: $" + CStr(ValorNegativos + ValorNegativosBB) + vbNewLine + vbNewLine
                CorreoAjustes += "Cantidad de Movimientos: " + CStr(QtyNegativos + QtyPsitivos) + vbNewLine
                CorreoAjustes += "Positivos: " + QtyPsitivos.ToString + vbNewLine
                CorreoAjustes += "Negativos: " + QtyNegativos.ToString + vbNewLine
                CorreoAjustes += "Valor Positivo: $" + Math.Round(ValorPositivos, 2).ToString + vbNewLine
                CorreoAjustes += "Valor Negativo: $" + Math.Round(ValorNegativos, 2).ToString + vbNewLine
                CorreoAjustes += vbNewLine
                CorreoAjustes += "Cantidad de Movimientos BinBalance: " + CStr(QtyNegativosBB + QtyPsitivosBB) + vbNewLine
                CorreoAjustes += "Positivos BinBalance: " + QtyPsitivosBB.ToString + vbNewLine
                CorreoAjustes += "Negativos BinBalance: " + QtyNegativosBB.ToString + vbNewLine
                CorreoAjustes += "Valor BinBalance Positivo: $" + Math.Round(ValorPositivosBB, 2).ToString + vbNewLine
                CorreoAjustes += "Valor BinBalance Negativo: $" + Math.Round(ValorNegativosBB, 2).ToString + vbNewLine
                CorreoAjustes += vbNewLine
                RutaAjustes = CreaCSV(Dia)
            End If
            If tblAjustes.Rows.Count = 0 Then
                RutaAjustes = ""
                CorreoAjustes = "No hay ajustes registrados el periodo de " + CDate(FechaInicio).ToString("dd-MMM-yyyy") + " a " + CDate(Dia).ToString("dd-MMM-yyyy") + vbNewLine
            End If
            Correo += vbNewLine + vbNewLine
            Correo += "Por favor no responder este correo" + vbNewLine + "Gracias"
            'se envia email ade advertencia
            Dim _Message As New System.Net.Mail.MailMessage()
            Dim _SMTP As New System.Net.Mail.SmtpClient
            'Dim att As New System.Net.Mail.Attachment("\\bimexserver\Desarrollo de Software\Reporte de AUs\AU's Subidos a SEA.xlsx") ', System.Net.Mime.TransferEncoding.Base64

            'CONFIGURACIÓN DEL STMP
            _SMTP.Credentials = New System.Net.NetworkCredential(EnviadoPor, "ShpIT2015")
            _SMTP.Host = "smtp.gmail.com"
            _SMTP.Port = 587
            _SMTP.EnableSsl = True
            ' CONFIGURACION DEL MENSAJE
            If DestinatariosBCC <> "" Then
                _Message.Bcc.Add(DestinatariosBCC)
                BanderaDestinatarios += 1
            End If
            If DestinatariosCC <> "" Then
                _Message.CC.Add(DestinatariosBCC)
                BanderaDestinatarios += 1
            End If
            If DestinatariosTO <> "" Then
                _Message.[To].Add(DestinatariosTO)
                BanderaDestinatarios += 1
            End If
            If BanderaDestinatarios > 0 Then
                _Message.From = New System.Net.Mail.MailAddress(EnviadoPor, "", System.Text.Encoding.UTF8) 'Quien lo envía
                _Message.Subject = "Reporte de Ajustes del periodo de " + CDate(FechaInicio).ToString("dd-MMM-yyyy") + " a " + CDate(Dia).ToString("dd-MMM-yyyy")
                _Message.SubjectEncoding = System.Text.Encoding.UTF8 'Codificacion
                _Message.Body = CorreoAjustes + vbNewLine + Correo
                _Message.BodyEncoding = System.Text.Encoding.UTF8
                _Message.Priority = System.Net.Mail.MailPriority.Normal
                If RutaAjustes <> "" Then
                    Dim att1 As New System.Net.Mail.Attachment(RutaAjustes)
                    _Message.Attachments.Add(att1)
                End If
                'If RutaWarning <> "" Then
                '    Dim att2 As New System.Net.Mail.Attachment(RutaWarning)
                '    _Message.Attachments.Add(att2)
                'End If
                _Message.IsBodyHtml = False
                'ENVIO
                _SMTP.Send(_Message)
                'MsgBox("Se ha Enviado el Email", MsgBoxStyle.Information, "EMail Enviado")
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Private Sub EnviaCorreoMensual(ByVal Dia As String, ByVal FechaInicio As String, ByVal Mes As String)
        'Try
        Dim DestinatariosTO As String = CargaDestinatarios("RptAjustesFin", "TO") '"jcarlos@specializedharness.com, almacen@specializedharness.com"  '"julio.gallegos@specializedharness.com" '"bgarcia@bitech.net, mespi@specializedharness.com, julio.gallegos@specializedharness.com"
            Dim DestinatariosCC As String = CargaDestinatarios("RptAjustesFin", "CC")
            Dim DestinatariosBCC As String = CargaDestinatarios("RptAjustesFin", "BCC")
            Dim EnviadoPor As String = "shp.app@specializedharness.com"
            Dim CorreoAjustes As String = ""
            Dim RutaAjustes As String = ""
            Dim Correo As String = ""
            Dim BanderaDestinatarios As Integer = 0
            If tblAjustes.Rows.Count > 0 Then
                CorreoAjustes += "Cantidad de Movimientos Totales: " + QtyMovimientos.ToString + vbNewLine
                CorreoAjustes += "Valor total de movimientos positivos: $" + CStr(ValorPositivos + ValorPositivosBB) + vbNewLine
                CorreoAjustes += "Valor total de movimientos negativos: $" + CStr(ValorNegativos + ValorNegativosBB) + vbNewLine + vbNewLine
                CorreoAjustes += "Cantidad de Movimientos: " + CStr(QtyNegativos + QtyPsitivos) + vbNewLine
                CorreoAjustes += "Positivos: " + QtyPsitivos.ToString + vbNewLine
                CorreoAjustes += "Negativos: " + QtyNegativos.ToString + vbNewLine
                CorreoAjustes += "Valor Positivo: $" + Math.Round(ValorPositivos, 2).ToString + vbNewLine
                CorreoAjustes += "Valor Negativo: $" + Math.Round(ValorNegativos, 2).ToString + vbNewLine
                CorreoAjustes += vbNewLine
                CorreoAjustes += "Cantidad de Movimientos BinBalance: " + CStr(QtyNegativosBB + QtyPsitivosBB) + vbNewLine
                CorreoAjustes += "Positivos BinBalance: " + QtyPsitivosBB.ToString + vbNewLine
                CorreoAjustes += "Negativos BinBalance: " + QtyNegativosBB.ToString + vbNewLine
                CorreoAjustes += "Valor BinBalance Positivo: $" + Math.Round(ValorPositivosBB, 2).ToString + vbNewLine
                CorreoAjustes += "Valor BinBalance Negativo: $" + Math.Round(ValorNegativosBB, 2).ToString + vbNewLine
                CorreoAjustes += vbNewLine
                RutaAjustes = CreaCSV(Dia)
            End If
            If tblAjustes.Rows.Count = 0 Then
                RutaAjustes = ""
                CorreoAjustes = "No hay ajustes registrados este mes" + vbNewLine
            End If
            Correo += vbNewLine + vbNewLine
            Correo += "Por favor no responder este correo" + vbNewLine + "Gracias"
            'se envia email ade advertencia
            Dim _Message As New System.Net.Mail.MailMessage()
            Dim _SMTP As New System.Net.Mail.SmtpClient
            'Dim att As New System.Net.Mail.Attachment("\\bimexserver\Desarrollo de Software\Reporte de AUs\AU's Subidos a SEA.xlsx") ', System.Net.Mime.TransferEncoding.Base64

            'CONFIGURACIÓN DEL STMP
            _SMTP.Credentials = New System.Net.NetworkCredential(EnviadoPor, "Row.6078$")
            _SMTP.Host = "smtp.ipower.com"
            _SMTP.Port = 587
            _SMTP.EnableSsl = True
            ' CONFIGURACION DEL MENSAJE
            If DestinatariosBCC <> "" Then
                _Message.Bcc.Add(DestinatariosBCC)
                BanderaDestinatarios += 1
            End If
            'If DestinatariosCC <> "" Then
            '    _Message.CC.Add(DestinatariosBCC)
            '    BanderaDestinatarios += 1
            'End If
            If DestinatariosTO <> "" Then
                _Message.[To].Add(DestinatariosTO)
                BanderaDestinatarios += 1
            End If
            If BanderaDestinatarios > 0 Then
                _Message.From = New System.Net.Mail.MailAddress(EnviadoPor, "", System.Text.Encoding.UTF8) 'Quien lo envía
                _Message.Subject = "Reporte de Ajustes del mes de " + Mes
                _Message.SubjectEncoding = System.Text.Encoding.UTF8 'Codificacion
                _Message.Body = CorreoAjustes + vbNewLine + Correo
                _Message.BodyEncoding = System.Text.Encoding.UTF8
                _Message.Priority = System.Net.Mail.MailPriority.Normal
                If RutaAjustes <> "" Then
                    Dim att1 As New System.Net.Mail.Attachment(RutaAjustes)
                    _Message.Attachments.Add(att1)
                End If
                'If RutaWarning <> "" Then
                '    Dim att2 As New System.Net.Mail.Attachment(RutaWarning)
                '    _Message.Attachments.Add(att2)
                'End If
                _Message.IsBodyHtml = False
                'ENVIO
                _SMTP.Send(_Message)
                'MsgBox("Se ha Enviado el Email", MsgBoxStyle.Information, "EMail Enviado")
            End If
        'Catch ex As Exception
        '    MsgBox(ex.Message.ToString)
        'End Try
    End Sub
    Private Sub CargaDatos(ByVal Dia As String)
        tblAjustes.Clear()
        Using TN As New DataTable
            Dim Edo, PN, BinBalance As String
            Dim AdjusmentType As String = "", Amount As Decimal = 0
            Try 'tblItemsFinantialInventoryControlTempforProductionProcess" & sTempTableName 
                Dim cmd As SqlCommand
                Dim dr As SqlDataReader
                Dim Query As String = "SELECT tblItemsTags.Tag, tblItemsTags.PN, tblItemsTags.Balance, tblItemsAdjustmentTAGs.AdjusmentType, (tblItemsAdjustmentTAGs.QtyNew-tblItemsAdjustmentTAGs.QtyActual) AS Diff, tblItemsAdjustmentTAGs.QtyActual, tblItemsAdjustmentTAGs.QtyNew, tblItemsAdjustmentTAGs.Amount, tblItemsAdjustmentTAGs.CreatedDate, tblItemsAdjustmentTAGs.CreatedBy, tblItemsAdjustmentTAGs.Reason, tblItemsAdjustmentTAGs.Notes, tblItemsAdjustmentTAGs.ApprovedBy, tblItemsAdjustmentTAGs.ScrapCategory,tblItemsAdjustmentTAGs.AjusteUsuario,tblItemsAdjustmentTAGs.AdditionalNotes FROM tblItemsTags INNER JOIN tblItemsAdjustmentTAGs ON tblItemsTags.TAG = tblItemsAdjustmentTAGs.TAG WHERE CAST(tblItemsAdjustmentTAGs.Createddate AS DATE)=@Dia ORDER BY tblItemsAdjustmentTAGs.CreatedDate ASC"
                cmd = New SqlCommand(Query, cnn)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@Dia", SqlDbType.NVarChar).Value = Dia
                cnn.Open()
                dr = cmd.ExecuteReader
                tblAjustes.Load(dr)
                cnn.Close()
                QtyMovimientos = 0
                QtyNegativos = 0
                QtyPsitivos = 0
                ValorNegativos = 0
                ValorPositivos = 0
                If tblAjustes.Rows.Count > 0 Then
                    QtyMovimientos = tblAjustes.Rows.Count
                    For NM As Integer = 0 To tblAjustes.Rows.Count - 1
                        AdjusmentType = tblAjustes.Rows(NM).Item("AdjusmentType").ToString
                        Amount = CDec(Val(tblAjustes.Rows(NM).Item("Amount").ToString))
                        PN = tblAjustes.Rows(NM).Item("PN").ToString
                        BinBalance = BuscaSiEsBinBalance(PN)
                        If BinBalance = "False" Then
                            If AdjusmentType = "Negative" Then
                                QtyNegativos += 1
                                ValorNegativos += Amount
                            ElseIf AdjusmentType = "Positive" Then
                                QtyPsitivos += 1
                                ValorPositivos += Amount
                            End If
                        ElseIf BinBalance = "True" Then
                            If AdjusmentType = "Negative" Then
                                QtyNegativosBB += 1
                                ValorNegativosBB += Amount
                            ElseIf AdjusmentType = "Positive" Then
                                QtyPsitivosBB += 1
                                ValorPositivosBB += Amount
                            End If
                        End If
                    Next
                End If
                'Se envia el reporte de los ajustes
                EnviaCorreo(Dia)
            Catch ex As Exception
                Edo = cnn.State.ToString
                If Edo = "Open" Then cnn.Close()
                MessageBox.Show(ex.Message, "Error Loading CargaDatos")
            End Try
        End Using
    End Sub
    Private Sub EnviaCorreo(ByVal Dia As String)
        Try
            Dim DestinatariosTO As String = CargaDestinatarios("RptAjustesFin", "TO") '"julio.gallegos@specializedharness.com" '"bgarcia@bitech.net, mespi@specializedharness.com, julio.gallegos@specializedharness.com"
            Dim DestinatariosCC As String = CargaDestinatarios("RptAjustesFin", "CC")
            Dim DestinatariosBCC As String = CargaDestinatarios("RptAjustesFin", "BCC")
            Dim EnviadoPor As String = "shp.app@specializedharness.com"
            Dim CorreoAjustes As String = ""
            Dim RutaAjustes As String = ""
            Dim Correo As String = ""
            Dim BanderaDestinatarios As Integer = 0
            If tblAjustes.Rows.Count > 0 Then
                CorreoAjustes += "Cantidad de Movimientos Totales: " + QtyMovimientos.ToString + vbNewLine + vbNewLine
                CorreoAjustes += "Cantidad de Movimientos: " + CStr(QtyNegativos + QtyPsitivos) + vbNewLine
                CorreoAjustes += "Positivos: " + QtyPsitivos.ToString + vbNewLine
                CorreoAjustes += "Negativos: " + QtyNegativos.ToString + vbNewLine
                CorreoAjustes += "Valor Positivo: $" + Math.Round(ValorPositivos, 2).ToString + vbNewLine
                CorreoAjustes += "Valor Negativo: $" + Math.Round(ValorNegativos, 2).ToString + vbNewLine
                CorreoAjustes += vbNewLine
                CorreoAjustes += "Cantidad de Movimientos BinBalance: " + CStr(QtyNegativosBB + QtyPsitivosBB) + vbNewLine
                CorreoAjustes += "Positivos BinBalance: " + QtyPsitivosBB.ToString + vbNewLine
                CorreoAjustes += "Negativos BinBalance: " + QtyNegativosBB.ToString + vbNewLine
                CorreoAjustes += "Valor BinBalance Positivo: $" + Math.Round(ValorPositivosBB, 2).ToString + vbNewLine
                CorreoAjustes += "Valor BinBalance Negativo: $" + Math.Round(ValorNegativosBB, 2).ToString + vbNewLine
                CorreoAjustes += vbNewLine
                RutaAjustes = CreaCSV(Dia)
            End If
            If tblAjustes.Rows.Count = 0 Then
                RutaAjustes = ""
                CorreoAjustes = "No hay ajustes registrados el día de hoy" + vbNewLine
            End If
            Correo += vbNewLine + vbNewLine
            Correo += "Por favor no responder este correo" + vbNewLine + "Gracias"
            'se envia email ade advertencia
            Dim _Message As New System.Net.Mail.MailMessage()
            Dim _SMTP As New System.Net.Mail.SmtpClient
            'Dim att As New System.Net.Mail.Attachment("\\bimexserver\Desarrollo de Software\Reporte de AUs\AU's Subidos a SEA.xlsx") ', System.Net.Mime.TransferEncoding.Base64

            'CONFIGURACIÓN DEL STMP
            _SMTP.Credentials = New System.Net.NetworkCredential(EnviadoPor, "Row.6078$")
            _SMTP.Host = "smtp.ipower.com"
            _SMTP.Port = 587
            _SMTP.EnableSsl = True
            ' CONFIGURACION DEL MENSAJE
            If DestinatariosBCC <> "" Then
                _Message.Bcc.Add(DestinatariosBCC)
                BanderaDestinatarios += 1
            End If
            If DestinatariosCC <> "" Then
                _Message.CC.Add(DestinatariosBCC)
                BanderaDestinatarios += 1
            End If
            If DestinatariosTO <> "" Then
                _Message.[To].Add(DestinatariosTO)
                BanderaDestinatarios += 1
            End If
            If BanderaDestinatarios > 0 Then
                _Message.From = New System.Net.Mail.MailAddress(EnviadoPor, "", System.Text.Encoding.UTF8) 'Quien lo envía
                _Message.Subject = "Reporte de Ajustes " + Dia
                _Message.SubjectEncoding = System.Text.Encoding.UTF8 'Codificacion
                _Message.Body = CorreoAjustes + vbNewLine + Correo
                _Message.BodyEncoding = System.Text.Encoding.UTF8
                _Message.Priority = System.Net.Mail.MailPriority.Normal
                If RutaAjustes <> "" Then
                    Dim att1 As New System.Net.Mail.Attachment(RutaAjustes)
                    _Message.Attachments.Add(att1)
                End If
                'If RutaWarning <> "" Then
                '    Dim att2 As New System.Net.Mail.Attachment(RutaWarning)
                '    _Message.Attachments.Add(att2)
                'End If
                _Message.IsBodyHtml = False
                'ENVIO
                _SMTP.Send(_Message)
                'MsgBox("Se ha Enviado el Email", MsgBoxStyle.Information, "EMail Enviado")
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Private Function CargaDestinatarios(ByVal Modulo As String, ByVal OpcionEnvio As String)
        Dim Destinatarios As String = ""
        Dim Edo As String = ""
        Dim contador As Long = 0
        Using TE As New Data.DataTable
            Try
                Dim cmd As SqlCommand
                Dim dr As SqlDataReader
                Dim Query As String = "SELECT Email FROM tblUserEmails WHERE Module=@Module AND Active=1 AND OptionToSend=@OptionToSend"
                cmd = New SqlCommand(Query, cnn)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@Module", SqlDbType.NVarChar).Value = Modulo
                cmd.Parameters.Add("@OptionToSend", SqlDbType.NVarChar).Value = OpcionEnvio
                cnn.Open()
                dr = cmd.ExecuteReader
                TE.Load(dr)
              cnn.Close()
            Catch ex As Exception
                Edo = cnn.State.ToString
                If Edo = "Open" Then cnn.Close()
                MessageBox.Show(ex.Message, "Error Loading tblMaster")
            End Try
            If TE.Rows.Count > 0 Then
                For NM As Integer = 0 To TE.Rows.Count - 1
                    Destinatarios += TE.Rows(NM).Item("Email").ToString
                    If NM < TE.Rows.Count - 1 Then Destinatarios += ","
                Next
            End If
        End Using
        Return Destinatarios
    End Function
    Private Function CreaCSV(ByVal Dia As String)
        Dim Banderilla As Integer = 0
        Dim Fecha As Date = CDate(Dia)
        Dim ArchivoNombre As String = "RPT" + Fecha.ToString("yyyy") + Fecha.ToString("MM") + Fecha.ToString("dd") + Now.ToString("HH") + Now.ToString("mm") + ".csv"
        Dim Ruta As String = Path.GetTempPath() & ArchivoNombre
        'Tag,PN,Balance,AdjusmentType,Diff,QtyActual,QtyNew,Amount,CreatedDate,CreatedBy,Reason,Notes, ApprovedBy
        'Try
        Dim AUX As String = "", MyTag As String = "", ProductType As String = "", UnitPrice As Decimal = 0, Piezas As Decimal = 0, Amount As Decimal = 0, TAG As String = ""
            Dim fs As FileStream = File.Create(Ruta)
            Dim CadenaBB As String = vbNewLine + vbNewLine + vbNewLine, PN As String = "", BB As String
        Dim Cadena As String = "Tag,PN,Balance,AdjusmentType,Diff,QtyActual,QtyNew,Unit Price,Amount,CreatedDate,CreatedBy,Reason,Notes,ApprovedBy,BinBalance,ProductType,ScrapCategory,Usuario,AdditionalNotes" + vbNewLine  '"Num,Issue," + vbNewLine
        Dim infoTitulos As Byte() = New UTF8Encoding(True).GetBytes(Cadena)
            fs.Write(infoTitulos, 0, infoTitulos.Length)
            For NM As Integer = 0 To tblAjustes.Rows.Count - 1
                UnitPrice = 0
                Piezas = 0
                Amount = 0
                TAG = ""
                MyTag = LTrim(RTrim(tblAjustes.Rows(NM).Item("TAG").ToString))
                PN = LTrim(RTrim(tblAjustes.Rows(NM).Item("PN").ToString))
                BB = BuscaSiEsBinBalance(PN)
                ProductType = BuscaSiEsProductType(PN)
                If MyTag = "" Then
                    PN = PN
                End If
                If PN = "WAA167-6" Or PN = "CA-M85049/49-2-10W" Then
                    PN = PN
                End If
                If BB = "False" Then
                    AUX = LTrim(RTrim(tblAjustes.Rows(NM).Item("TAG").ToString))
                    AUX = AUX.Replace(vbNewLine, " ")
                    AUX = AUX.Replace(vbCr, " ")
                    AUX = AUX.Replace(vbCrLf, " ")
                    AUX = AUX.Replace(",", " ")
                    TAG = AUX
                    Cadena = AUX + ","
                    AUX = LTrim(RTrim(tblAjustes.Rows(NM).Item("PN").ToString))
                    AUX = AUX.Replace(vbNewLine, " ")
                    AUX = AUX.Replace(vbCr, " ")
                    AUX = AUX.Replace(vbCrLf, " ")
                    AUX = AUX.Replace(",", " ")
                    Cadena += AUX + ","
                    AUX = LTrim(RTrim(tblAjustes.Rows(NM).Item("Balance").ToString))
                    AUX = AUX.Replace(vbNewLine, " ")
                    AUX = AUX.Replace(vbCr, " ")
                    AUX = AUX.Replace(vbCrLf, " ")
                    AUX = AUX.Replace(",", " ")
                    Cadena += AUX + ","
                    AUX = LTrim(RTrim(tblAjustes.Rows(NM).Item("AdjusmentType").ToString))
                    AUX = AUX.Replace(vbNewLine, " ")
                    AUX = AUX.Replace(vbCr, " ")
                    AUX = AUX.Replace(vbCrLf, " ")
                    AUX = AUX.Replace(",", " ")
                    Cadena += AUX + ","
                    AUX = LTrim(RTrim(tblAjustes.Rows(NM).Item("Diff").ToString))
                    AUX = AUX.Replace(vbNewLine, " ")
                    AUX = AUX.Replace(vbCr, " ")
                    AUX = AUX.Replace(vbCrLf, " ")
                    AUX = AUX.Replace(",", " ")
                    Piezas = CDec(Val(AUX))
                    Cadena += AUX + ","
                    AUX = LTrim(RTrim(tblAjustes.Rows(NM).Item("QtyActual").ToString))
                    AUX = AUX.Replace(vbNewLine, " ")
                    AUX = AUX.Replace(vbCr, " ")
                    AUX = AUX.Replace(vbCrLf, " ")
                    AUX = AUX.Replace(",", " ")
                    Cadena += AUX + ","
                    AUX = LTrim(RTrim(tblAjustes.Rows(NM).Item("QtyNew").ToString))
                    AUX = AUX.Replace(vbNewLine, " ")
                    AUX = AUX.Replace(vbCr, " ")
                    AUX = AUX.Replace(vbCrLf, " ")
                    AUX = AUX.Replace(",", " ")
                    Cadena += AUX + ","
                    AUX = LTrim(RTrim(tblAjustes.Rows(NM).Item("Amount").ToString))
                    AUX = AUX.Replace(vbNewLine, " ")
                    AUX = AUX.Replace(vbCr, " ")
                    AUX = AUX.Replace(vbCrLf, " ")
                    AUX = AUX.Replace(",", " ")
                    Amount = CDec(Val(AUX))
                    If Math.Abs(Piezas) = 0 Then
                        'buscamos el precio unitario
                        UnitPrice = BuscamosPrecioUnitarioTags(TAG)
                    Else
                        'calculamos el precio unitario
                        UnitPrice = Amount / Math.Abs(Piezas)
                    End If
                    Cadena += CStr(UnitPrice) + ","
                    Cadena += AUX + ","
                    AUX = LTrim(RTrim(tblAjustes.Rows(NM).Item("CreatedDate").ToString))
                    AUX = AUX.Replace(vbNewLine, " ")
                    AUX = AUX.Replace(vbCr, " ")
                    AUX = AUX.Replace(vbCrLf, " ")
                    AUX = AUX.Replace(",", " ")
                    Cadena += AUX + ","
                    AUX = LTrim(RTrim(tblAjustes.Rows(NM).Item("CreatedBy").ToString))
                    AUX = AUX.Replace(vbNewLine, " ")
                    AUX = AUX.Replace(vbCr, " ")
                    AUX = AUX.Replace(vbCrLf, " ")
                    AUX = AUX.Replace(",", " ")
                    Cadena += AUX + ","
                    AUX = LTrim(RTrim(tblAjustes.Rows(NM).Item("Reason").ToString))
                    AUX = AUX.Replace(vbNewLine, " ")
                    AUX = AUX.Replace(vbCr, " ")
                    AUX = AUX.Replace(vbCrLf, " ")
                    AUX = AUX.Replace(",", " ")
                    Cadena += AUX + ","
                    AUX = LTrim(RTrim(tblAjustes.Rows(NM).Item("Notes").ToString))
                    AUX = AUX.Replace(vbNewLine, " ")
                    AUX = AUX.Replace(vbCr, " ")
                    AUX = AUX.Replace(vbCrLf, " ")
                    AUX = AUX.Replace(",", " ")
                    Cadena += AUX + ","
                    AUX = LTrim(RTrim(tblAjustes.Rows(NM).Item("ApprovedBy").ToString.ToLower))
                    AUX = AUX.Replace(vbNewLine, " ")
                    AUX = AUX.Replace(vbCr, " ")
                    AUX = AUX.Replace(vbCrLf, " ")
                    AUX = AUX.Replace(",", " ")
                    Cadena += AUX + ","
                    Cadena += "0,"
                    AUX = ProductType.Replace(vbNewLine, " ")
                    AUX = AUX.Replace(vbCr, " ")
                    AUX = AUX.Replace(vbCrLf, " ")
                    AUX = AUX.Replace(",", " ")
                    Cadena += AUX + ","
                    AUX = LTrim(RTrim(tblAjustes.Rows(NM).Item("ScrapCategory").ToString))
                    AUX = AUX.Replace(vbCr, " ")
                    AUX = AUX.Replace(vbCrLf, " ")
                    AUX = AUX.Replace(",", " ")
                Cadena += AUX + ","
                AUX = LTrim(RTrim(tblAjustes.Rows(NM).Item("AjusteUsuario").ToString))
                AUX = AUX.Replace(vbCr, " ")
                AUX = AUX.Replace(vbCrLf, " ")
                AUX = AUX.Replace(",", " ")
                Cadena += AUX + ","
                AUX = LTrim(RTrim(tblAjustes.Rows(NM).Item("AdditionalNotes").ToString))
                AUX = AUX.Replace(vbCr, " ")
                AUX = AUX.Replace(vbCrLf, " ")
                AUX = AUX.Replace(",", " ")
                Cadena += AUX + ","
                Cadena += vbNewLine
                Dim info As Byte() = New UTF8Encoding(True).GetBytes(Cadena)
                    fs.Write(info, 0, info.Length)
                End If
            Next
            For KK As Integer = 0 To tblAjustes.Rows.Count - 1
                PN = LTrim(RTrim(tblAjustes.Rows(KK).Item("PN").ToString))
                BB = BuscaSiEsBinBalance(PN)
                If BB = "True" Then
                    AUX = LTrim(RTrim(tblAjustes.Rows(KK).Item("TAG").ToString))
                    AUX = AUX.Replace(vbNewLine, " ")
                    AUX = AUX.Replace(vbCr, " ")
                    AUX = AUX.Replace(vbCrLf, " ")
                    AUX = AUX.Replace(",", " ")
                    TAG = AUX
                    CadenaBB = AUX + ","
                    AUX = LTrim(RTrim(tblAjustes.Rows(KK).Item("PN").ToString))
                    AUX = AUX.Replace(vbNewLine, " ")
                    AUX = AUX.Replace(vbCr, " ")
                    AUX = AUX.Replace(vbCrLf, " ")
                    AUX = AUX.Replace(",", " ")
                    CadenaBB += AUX + ","
                    AUX = LTrim(RTrim(tblAjustes.Rows(KK).Item("Balance").ToString))
                    AUX = AUX.Replace(vbNewLine, " ")
                    AUX = AUX.Replace(vbCr, " ")
                    AUX = AUX.Replace(vbCrLf, " ")
                    AUX = AUX.Replace(",", " ")
                    CadenaBB += AUX + ","
                    AUX = LTrim(RTrim(tblAjustes.Rows(KK).Item("AdjusmentType").ToString))
                    AUX = AUX.Replace(vbNewLine, " ")
                    AUX = AUX.Replace(vbCr, " ")
                    AUX = AUX.Replace(vbCrLf, " ")
                    AUX = AUX.Replace(",", " ")
                    CadenaBB += AUX + ","
                    AUX = LTrim(RTrim(tblAjustes.Rows(KK).Item("Diff").ToString))
                    AUX = AUX.Replace(vbNewLine, " ")
                    AUX = AUX.Replace(vbCr, " ")
                    AUX = AUX.Replace(vbCrLf, " ")
                    AUX = AUX.Replace(",", " ")
                    Piezas = CDec(Val(AUX))
                    CadenaBB += AUX + ","
                    AUX = LTrim(RTrim(tblAjustes.Rows(KK).Item("QtyActual").ToString))
                    AUX = AUX.Replace(vbNewLine, " ")
                    AUX = AUX.Replace(vbCr, " ")
                    AUX = AUX.Replace(vbCrLf, " ")
                    AUX = AUX.Replace(",", " ")
                    CadenaBB += AUX + ","
                    AUX = LTrim(RTrim(tblAjustes.Rows(KK).Item("QtyNew").ToString))
                    AUX = AUX.Replace(vbNewLine, " ")
                    AUX = AUX.Replace(vbCr, " ")
                    AUX = AUX.Replace(vbCrLf, " ")
                    AUX = AUX.Replace(",", " ")
                    CadenaBB += AUX + ","
                    AUX = LTrim(RTrim(tblAjustes.Rows(KK).Item("Amount").ToString))
                    AUX = AUX.Replace(vbNewLine, " ")
                    AUX = AUX.Replace(vbCr, " ")
                    AUX = AUX.Replace(vbCrLf, " ")
                    AUX = AUX.Replace(",", " ")
                    'CadenaBB += AUX + ","
                    Amount = CDec(Val(AUX))
                    If Math.Abs(Piezas) = 0 Then
                        'buscamos el precio unitario
                        UnitPrice = BuscamosPrecioUnitarioTags(TAG)
                    Else
                        'calculamos el precio unitario
                        UnitPrice = Amount / Math.Abs(Piezas)
                    End If
                    CadenaBB += CStr(UnitPrice) + ","
                    CadenaBB += AUX + ","
                    AUX = LTrim(RTrim(tblAjustes.Rows(KK).Item("CreatedDate").ToString))
                    AUX = AUX.Replace(vbNewLine, " ")
                    AUX = AUX.Replace(vbCr, " ")
                    AUX = AUX.Replace(vbCrLf, " ")
                    AUX = AUX.Replace(",", " ")
                    CadenaBB += AUX + ","
                    AUX = LTrim(RTrim(tblAjustes.Rows(KK).Item("CreatedBy").ToString))
                    AUX = AUX.Replace(vbNewLine, " ")
                    AUX = AUX.Replace(vbCr, " ")
                    AUX = AUX.Replace(vbCrLf, " ")
                    AUX = AUX.Replace(",", " ")
                    CadenaBB += AUX + ","
                    AUX = LTrim(RTrim(tblAjustes.Rows(KK).Item("Reason").ToString))
                    AUX = AUX.Replace(vbNewLine, " ")
                    AUX = AUX.Replace(vbCr, " ")
                    AUX = AUX.Replace(vbCrLf, " ")
                    AUX = AUX.Replace(",", " ")
                    CadenaBB += AUX + ","
                    AUX = LTrim(RTrim(tblAjustes.Rows(KK).Item("Notes").ToString))
                    AUX = AUX.Replace(vbNewLine, " ")
                    AUX = AUX.Replace(vbCr, " ")
                    AUX = AUX.Replace(vbCrLf, " ")
                    AUX = AUX.Replace(",", " ")
                    CadenaBB += AUX + ","
                    AUX = LTrim(RTrim(tblAjustes.Rows(KK).Item("ApprovedBy").ToString.ToLower))
                    AUX = AUX.Replace(vbNewLine, " ")
                    AUX = AUX.Replace(vbCr, " ")
                    AUX = AUX.Replace(vbCrLf, " ")
                    AUX = AUX.Replace(",", " ")
                    CadenaBB += AUX + ","
                    CadenaBB += "1,"
                    AUX = ProductType.Replace(vbNewLine, " ")
                    AUX = AUX.Replace(vbCr, " ")
                    AUX = AUX.Replace(vbCrLf, " ")
                    AUX = AUX.Replace(",", " ")
                    CadenaBB += AUX + ","
                    AUX = LTrim(RTrim(tblAjustes.Rows(KK).Item("ScrapCategory").ToString))
                    AUX = AUX.Replace(vbCr, " ")
                    AUX = AUX.Replace(vbCrLf, " ")
                    AUX = AUX.Replace(",", " ")
                Cadena += AUX + ","
                AUX = LTrim(RTrim(tblAjustes.Rows(KK).Item("AjusteUsuario").ToString))
                AUX = AUX.Replace(vbCr, " ")
                AUX = AUX.Replace(vbCrLf, " ")
                AUX = AUX.Replace(",", " ")
                Cadena += AUX + ","
                AUX = LTrim(RTrim(tblAjustes.Rows(KK).Item("AdditionalNotes").ToString))
                AUX = AUX.Replace(vbCr, " ")
                AUX = AUX.Replace(vbCrLf, " ")
                AUX = AUX.Replace(",", " ")
                Cadena += AUX + ","
                CadenaBB += vbNewLine
                    Dim info As Byte() = New UTF8Encoding(True).GetBytes(CadenaBB)
                    fs.Write(info, 0, info.Length)
                End If
            Next
            fs.Close()
            Banderilla += 1
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message.ToString + vbNewLine + "Error in CreaCSV", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
        If Banderilla = 0 Then
            Ruta = ""
        End If
        Return Ruta
    End Function
    Private Function BuscaSiEsBinBalance(ByVal PN As String)
        Dim Resp As String = "False"
        Using TN As New DataTable
            Dim Edo As String
            'Try
            Dim cmd As SqlCommand
                Dim dr As SqlDataReader
                Dim Query As String = "SELECT BinBalance FROM tblItemsQB WHERE PN=@PN ORDER BY PriOption DESC"
                cmd = New SqlCommand(Query, cnn)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@PN", SqlDbType.NVarChar).Value = PN
                cnn.Open()
                dr = cmd.ExecuteReader
                TN.Load(dr)
                cnn.Close()
                If TN.Rows.Count > 0 Then
                    Resp = TN.Rows(0).Item("BinBalance").ToString
                End If
            'Catch ex As Exception
            '    Edo = cnn.State.ToString
            '    If Edo = "Open" Then cnn.Close()
            '    MessageBox.Show(ex.Message)
            'End Try
        End Using
        Return Resp
    End Function
    Private Function BuscaSiEsProductType(ByVal PN As String)
        Dim Resp As String = ""
        Using TN As New DataTable
            Dim Edo As String
            'Try
            Dim cmd As SqlCommand
                Dim dr As SqlDataReader
                Dim Query As String = "SELECT DISTINCT ProductType, PriOption FROM tblItemsQB WHERE PN=@PN ORDER BY PriOption DESC"
                cmd = New SqlCommand(Query, cnn)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@PN", SqlDbType.NVarChar).Value = PN
                cnn.Open()
                dr = cmd.ExecuteReader
                TN.Load(dr)
                cnn.Close()
                If TN.Rows.Count > 0 Then
                    Resp = TN.Rows(0).Item("ProductType").ToString
                End If
            'Catch ex As Exception
            '    Edo = cnn.State.ToString
            '    If Edo = "Open" Then cnn.Close()
            '    MessageBox.Show(ex.Message)
            'End Try
        End Using
        Return Resp
    End Function
    Private Function BuscamosPrecioUnitarioTags(ByVal TAG As String)
        Dim Resp As String = ""
        Using TN As New DataTable
            Dim Edo As String, ID As String, SubPN As String
            'Try
            Dim cmd As SqlCommand
                Dim dr As SqlDataReader
                Dim Query As String = "SELECT * FROM tblItemsTags WHERE TAG=@TAG "
                cmd = New SqlCommand(Query, cnn)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@TAG", SqlDbType.NVarChar).Value = TAG
                cnn.Open()
                dr = cmd.ExecuteReader
                TN.Load(dr)
                cnn.Close()
                If TN.Rows.Count > 0 Then
                    ID = TN.Rows(0).Item("ID").ToString
                    SubPN = TN.Rows(0).Item("SubPN").ToString
                    If ID <> "" Then
                    'Buscamos Unit Price en las PO
                    Resp = BuscaPrecioPODet(ID, SubPN)
                Else
                        'Buscamos unit price en la lista maestra
                        Resp = BuscaPrecioEnListaMaestra(SubPN)
                    End If
                End If
            'Catch ex As Exception
            '    Edo = cnn.State.ToString
            '    If Edo = "Open" Then cnn.Close()
            '    MessageBox.Show(ex.Message)
            'End Try
        End Using
        Return Resp
    End Function
    Private Function BuscaPrecioPODet(ByVal ID As String, subpn As String)
        Dim Resp As String = ""
        Using TN As New DataTable
            Dim Edo As String
            Try
                Dim cmd As SqlCommand
                Dim dr As SqlDataReader
                Dim Query As String = "SELECT * FROM tblItemsPOsDet WHERE ID=@ID "
                cmd = New SqlCommand(Query, cnn)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@ID", SqlDbType.NVarChar).Value = ID
                cnn.Open()
                dr = cmd.ExecuteReader
                TN.Load(dr)
                cnn.Close()
                If TN.Rows.Count > 0 Then
                    Resp = TN.Rows(0).Item("UnitPriceUSD").ToString
                Else
                    Resp = BuscaPrecioEnListaMaestra(subpn)
                End If
            Catch ex As Exception
                Edo = cnn.State.ToString
                If Edo = "Open" Then cnn.Close()
                MessageBox.Show(ex.Message)
            End Try
        End Using
        Return Resp
    End Function
    Private Function BuscaPrecioEnListaMaestra(ByVal SubPN As String)
        Dim Resp As String = ""
        Using TN As New DataTable
            Dim Edo As String
            Try
                Dim cmd As SqlCommand
                Dim dr As SqlDataReader
                Dim Query As String = "SELECT isnull(UnitPrice,0) as UnitPrice FROM tblItemsQB WHERE SubPN=@SubPN "
                cmd = New SqlCommand(Query, cnn)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@SubPN", SqlDbType.NVarChar).Value = SubPN
                cnn.Open()
                dr = cmd.ExecuteReader
                TN.Load(dr)
                cnn.Close()
                If TN.Rows.Count > 0 Then
                    Resp = TN.Rows(0).Item("UnitPrice").ToString
                Else
                    Resp = 0
                End If
            Catch ex As Exception
                Edo = cnn.State.ToString
                If Edo = "Open" Then cnn.Close()
                MessageBox.Show(ex.Message)
            End Try
        End Using
        Return Resp
    End Function

    Private Sub btnSendReport_Click(sender As Object, e As EventArgs) Handles btnSendReport.Click
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        QtyMovimientos = 0
        ValorPositivos = 0
        ValorPositivosBB = 0
        ValorNegativos = 0
        ValorNegativosBB = 0
        QtyNegativos = 0
        QtyPsitivos = 0
        QtyNegativosBB = 0
        QtyPsitivosBB = 0
        GenerarReporteManual()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub
    Private Sub GenerarReporteManual()
        Dim Desde As String = CDate(dtpFrom.Value.ToString).ToString("dd-MMM-yyyy")
        Dim Hasta As String = dtpTo.Value.ToString
        CargaDatosMensual(Hasta, Desde, "")
        Application.Exit()
    End Sub
End Class
