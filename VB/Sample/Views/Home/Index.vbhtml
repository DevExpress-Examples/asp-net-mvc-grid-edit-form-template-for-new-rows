
           <script type="text/javascript">
               function OnBeginCallback(s, e) {
                   var isNewRowNow = s.IsNewRowEditing();
                   var isSwitchToNewRow = (e.command == 'ADDNEWROW');
                   var IsCancelEdit = (e.command == 'CANCELEDIT');
                   var IsSwitchToEdit = (e.command == 'STARTEDIT');
                   var result = (isSwitchToNewRow * !IsCancelEdit + isNewRowNow) * !IsSwitchToEdit;
                   e.customArgs['IsNewRow'] = Boolean(result);
               }
           </script>
@Html.Partial("GridViewEditingPartial", Model)

