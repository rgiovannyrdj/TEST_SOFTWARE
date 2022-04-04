using System;
using System.Collections.Generic;
using System.Data;
using TEST_SOFTWARE.CORE.Entities;

namespace TEST_SOFTWARE.INFRASTRUCTURE.Services
{
    public class RepositoryService
    {
        public List<Person> GetPersons(DataTable table)
        {
            List<Person> persons = new List<Person>();

            foreach (DataRow row in table.Rows)
            {
                Person person = GetPerson(row);

                persons.Add(person);
            }

            return persons;
        }
        public Person GetPerson(DataRow dataRow)
        {
            Person person = new Person();

            person.ID = Convert.ToInt32(dataRow["ID"]);
            person.Nombre = Convert.ToString(dataRow["Nombre"]);
            person.Apellido_Paterno = Convert.ToString(dataRow["Apellido_Paterno"]);
            person.Apellido_Materno = Convert.ToString(dataRow["Apellido_Materno"]);
            person.Identificacion = Convert.ToString(dataRow["Identificacion"]);

            return person;
        }
        public List<Invoice> GetInvoices(DataTable table)
        {
            List<Invoice> invoices = new List<Invoice>();

            foreach (DataRow row in table.Rows)
            {
                Invoice invoice = GetInvoice(row);

                invoices.Add(invoice);
            }

            return invoices;
        }
        public Invoice GetInvoice(DataRow dataRow)
        {
            Invoice invoice = new Invoice();

            invoice.ID = Convert.ToInt32(dataRow["ID"]);
            invoice.Fecha = Convert.ToDateTime(dataRow["Fecha"]);
            invoice.Monto = Convert.ToDouble(dataRow["Monto"]);

            return invoice;
        }
    }
}
