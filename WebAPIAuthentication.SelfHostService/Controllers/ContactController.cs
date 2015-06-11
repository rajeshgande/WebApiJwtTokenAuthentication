using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebAPIAuthentication.SelfHostService
{
    [Authorize]
    public class ContactController : ApiController
    {
        // Mock a data store:
        private static List<Contact> _contacts = new List<Contact>
        {
            new Contact { Name = "Rajesh", Phone= "2515543900" },
            new Contact { Name = "Dave", Phone= "111-111-1111" },
            new Contact { Name = "Henry", Phone= "222-222-2222" }
        };

        public IEnumerable<Contact> Get()
        {
            return _contacts;
        }


        public Contact Get(string name)
        {
            var Contact = _contacts.FirstOrDefault(c => c.Name == name);
            if (Contact == null)
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
            }
            return Contact;
        }


        public IHttpActionResult Post(Contact Contact)
        {
            if (Contact == null)
            {
                return BadRequest("Argument Null");
            }
            var ContactExists = _contacts.Any(c => c.Name == Contact.Name);

            if (ContactExists)
            {
                return BadRequest("Exists");
            }

            _contacts.Add(Contact);
            return Ok();
        }


        public IHttpActionResult Put(Contact Contact)
        {
            if (Contact == null)
            {
                return BadRequest("Argument Null");
            }
            var existing = _contacts.FirstOrDefault(c => c.Name == Contact.Name);

            if (existing == null)
            {
                return NotFound();
            }

            existing.Name = Contact.Name;
            return Ok();
        }


        public IHttpActionResult Delete(string name)
        {
            var Contact = _contacts.FirstOrDefault(c => c.Name == name);
            if (Contact == null)
            {
                return NotFound();
            }
            _contacts.Remove(Contact);
            return Ok();
        }
    }
}