<!-- default file list -->
*Files to look at*:

* [HomeController.cs](./CS/Sample/Controllers/HomeController.cs) (VB: [HomeController.vb](./VB/Sample/Controllers/HomeController.vb))
* [Person.cs](./CS/Sample/Models/Person.cs) (VB: [Person.vb](./VB/Sample/Models/Person.vb))
* [PersonsList.cs](./CS/Sample/Models/PersonsList.cs) (VB: [PersonsList.vb](./VB/Sample/Models/PersonsList.vb))
* [GridViewEditingPartial.cshtml](./CS/Sample/Views/Home/GridViewEditingPartial.cshtml)
* [Index.cshtml](./CS/Sample/Views/Home/Index.cshtml)
<!-- default file list end -->
# GridView - How to specify an EditForm template only when adding a new row
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/t223758/)**
<!-- run online end -->


<p>This example illustrates how to specify a grid's EditForm template only when adding a new row and leave the default template when editing a row. Perform the following steps to accomplish this task:</p>
<p>1. Handle the <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebMVCScriptsMVCxClientGridView_BeginCallbacktopic">MVCxClientGridView.BeginCallback</a> event to determine which mode the grid will be in after a callback:</p>


```js
     function OnBeginCallback(s, e) {
        var isNewRowNow = s.IsNewRowEditing();
        var isSwitchToNewRow = (e.command == 'ADDNEWROW');
        var IsCancelEdit = (e.command == 'CANCELEDIT');
        var IsSwitchToEdit = (e.command == 'STARTEDIT');
         var result = (isSwitchToNewRow * !IsCancelEdit + isNewRowNow) * !IsSwitchToEdit;
        e.customArgs['IsNewRow'] = Boolean(result);
    }

```


<p>2. Process the received value in the controller and pass it to the view using ViewBag:</p>


```cs
[HttpPost, ValidateInput(false)]
public ActionResult GridViewEditingPartial(bool IsNewRow)
{
 if (IsNewRow)
  ViewBag.IsNewRow = true;
 return PartialView(list.GetPersons());
}

[HttpPost, ValidateInput(false)]
public ActionResult EditingAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] Person person)
{
 ViewBag.IsNewRow = true;
 ...
}

```


<p>3. After that, you can create a template based on the ViewBag value:</p>


```cs
if (ViewBag.IsNewRow != null)
    if (ViewBag.IsNewRow == true)
        settings.SetEditFormTemplateContent(c =>
        {
            ViewContext.Writer.Write("EditForm Template Content");
        });
```



<br/>


