Dim argumentos
Set argumentos = WScript.Arguments

Dim etiqueta
etiqueta = argumentos(0)

Dim truckNumber
truckNumber = argumentos(1)

Set SapGui = GetObject("SAPGUI")
Set Appl = SapGui.GetScriptingEngine
'DECISION BETWEEN AUTO LOGON AND MANUAL LOGON
'Set Connection = Appl.OpenConnection("' PR2 - Warehouse - Automatic Logon", True)
Set Connection = Appl.Openconnection("'' PR2 - Warehouse - Manual Logon", True)

Set Session = Connection.Children(0)
'MANUAL LOGON, COMMENT OUT IF USING AUTO ABOVE
Session.findById("wnd[0]/usr/txtRSYST-BNAME").Text = "TE376202R"
Session.findById("wnd[0]/usr/pwdRSYST-BCODE").Text = "Usuario.24"
Session.findById("wnd[0]").sendVKey 0

If Session.Children.Count > 1 Then

    Session.findById("wnd[1]/usr/radMULTI_LOGON_OPT2").Select

    Session.findById("wnd[1]/usr/radMULTI_LOGON_OPT2").SetFocus

    Session.findById("wnd[1]/tbar[0]/btn[0]").press

End If
   
Session.findById("wnd[0]").maximize
Session.findById("wnd[0]/tbar[0]/okcd").text = "/nzscn"
Session.findById("wnd[0]").sendVKey 0

On Error Resume Next

WScript.Sleep 5000

If Err.Number <> 0 Then
  Err.Clear
End If

' LOGS OUT OF SAP AND CLOSES THE LOGOUT CONFIRMATION WINDOW
Session.findById("wnd[0]").Close
Session.findById("wnd[1]/usr/btnSPOP-OPTION1").press

On Error GoTo 0