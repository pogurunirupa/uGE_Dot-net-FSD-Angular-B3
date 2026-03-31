using Microsoft.AspNetCore.Mvc;
using ContactApp.Models;

namespace ContactApp.Controllers
{
    public class ContactController : Controller
    {
        
        private static List<ContactInfo> contacts = new List<ContactInfo>();

        public ActionResult ShowContacts()
        {
            return View(contacts);
        }
        public ActionResult GetContactById(int id)
        {
            var contact = contacts.FirstOrDefault(c => c.ContactId == id);
            return View(contact);
        }
        public ActionResult AddContact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddContact(ContactInfo contactInfo)
        {
            if (ModelState.IsValid)
            {
                contacts.Add(contactInfo);
                return RedirectToAction("ShowContacts");
            }

            return View(contactInfo);
        }
    }
}