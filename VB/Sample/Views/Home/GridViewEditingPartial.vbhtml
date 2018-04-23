@Html.DevExpress().GridView( _
    Sub(settings)
            settings.Name = "grid"
            settings.KeyFieldName = "PersonID"
            settings.CallbackRouteValues = New With {Key .Controller = "Home", Key .Action = "GridViewEditingPartial"}

            settings.SettingsEditing.Mode = GridViewEditingMode.EditFormAndDisplayRow
            settings.SettingsEditing.AddNewRowRouteValues = New With {Key .Controller = "Home", Key .Action = "EditingAddNew"}
            settings.SettingsEditing.UpdateRowRouteValues = New With {Key .Controller = "Home", Key .Action = "EditingUpdate"}
            settings.SettingsEditing.DeleteRowRouteValues = New With {Key .Controller = "Home", Key .Action = "EditingDelete"}

            settings.CommandColumn.Visible = True
            settings.CommandColumn.ShowNewButtonInHeader = True
            settings.CommandColumn.ShowDeleteButton = True
            settings.CommandColumn.ShowEditButton = True
            settings.Columns.Add("FirstName")
            settings.Columns.Add("MiddleName")
            settings.Columns.Add("LastName")
            settings.ClientSideEvents.BeginCallback = "OnBeginCallback"
            If ViewBag.IsNewRow IsNot Nothing Then
                If ViewBag.IsNewRow = True Then
                    settings.SetEditFormTemplateContent(Sub(c) ViewContext.Writer.Write("EditForm Template Content"))
                End If
            End If
    End Sub).Bind(Model).GetHtml()
