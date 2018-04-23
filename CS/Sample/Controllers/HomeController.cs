using System.Web.Mvc;
using DevExpress.Web.Mvc;
using Sample.Models;

namespace Sample.Controllers
{
    public class HomeController : Controller
    {
        PersonsList list = new PersonsList();

        public ActionResult Index()
        {
            return View(list.GetPersons());
        }

        public ActionResult GridViewEditingPartial()
        {
            return PartialView(list.GetPersons());
        }
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
            if (ModelState.IsValid)
                list.AddPerson(person);
            return PartialView("GridViewEditingPartial", list.GetPersons());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult EditingUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] Person personInfo)
        {
            if (ModelState.IsValid)
                list.UpdatePerson(personInfo);
            return PartialView("GridViewEditingPartial", list.GetPersons());
        }

        public ActionResult EditingDelete(int personId)
        {
            list.DeletePerson(personId);
            return PartialView("GridViewEditingPartial", list.GetPersons());
        }
    }
}