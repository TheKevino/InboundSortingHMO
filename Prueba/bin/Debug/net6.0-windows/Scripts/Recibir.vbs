Dim argumentos
Set argumentos = WScript.Arguments
Dim etiquetas
etiquetas = argumentos(0)

Dim tresS
tresS = Split(etiquetas, ",")
 
truckNumber = InputBox("Truck Number:")
 
Set SapGui = GetObject("SAPGUI")
Set Appl = SapGui.GetScriptingEngine
'DECISION BETWEEN AUTO LOGON AND MANUAL LOGON
'Set Connection = Appl.OpenConnection("' PR2 - Warehouse - Automatic Logon", True)
Set Connection = Appl.Openconnection("'' PR2 - Warehouse - Manual Logon", True)
' wait added to prevent Server Busy error while opening SAP

Set Session = Connection.Children(0)
'MANUAL LOGON, COMMENT OUT IF USING AUTO ABOVE
Session.findById("wnd[0]/usr/txtRSYST-BNAME").Text = "TE376202R"
Session.findById("wnd[0]/usr/pwdRSYST-BCODE").Text = "Almacen.2023"
Session.findById("wnd[0]").sendVKey 0

If Session.Children.Count > 1 Then

    Session.findById("wnd[1]/usr/radMULTI_LOGON_OPT2").Select

    Session.findById("wnd[1]/usr/radMULTI_LOGON_OPT2").SetFocus

    Session.findById("wnd[1]/tbar[0]/btn[0]").press

End If
   
Session.findById("wnd[0]").maximize
Session.findById("wnd[0]/tbar[0]/okcd").text = "/nzscn"
Session.findById("wnd[0]").sendVKey 0

For Each elemento In tresS
   Session.findById("wnd[0]/usr/txtI_LTAG").text = elemento
   Session.findById("wnd[0]/usr/txtI_LTAG").caretPosition = 14
   Session.findById("wnd[0]").sendVKey 0
Next

Session.findById("wnd[0]/mbar/menu[3]/menu[0]").select
Session.findById("wnd[0]/tbar[0]/btn[11]").press
Session.findById("wnd[0]/tbar[1]/btn[18]").press
Session.findById("wnd[1]/usr/ctxtZLTBWART-BWART").text = "101"
Session.findById("wnd[1]/usr/ctxtZLTBWART-BWART").caretPosition = 3
Session.findById("wnd[1]/usr/btnCONTINUE").press
Session.findById("wnd[1]/usr/chkDISPLAY_MATDOC").selected = false
Session.findById("wnd[1]/usr/chkDISPLAY_MATDOC").setFocus
Session.findById("wnd[1]/usr/btnPOST").press
Session.findById("wnd[0]/usr/txtLS_0106_SCRN-Z_TN").text = truckNumber
Session.findById("wnd[0]/usr/txtLS_0106_SCRN-Z_TN").caretPosition = 12
Session.findById("wnd[0]/usr/btn%#AUTOTEXT003").press
       
' LOGS OUT OF SAP AND CLOSES THE LOGOUT CONFIRMATION WINDOW
Session.findById("wnd[0]").Close
Session.findById("wnd[1]/usr/btnSPOP-OPTION1").press