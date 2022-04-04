using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using TEST_SOFTWARE.CORE.Entities;
using TEST_SOFTWARE.CORE.Interfaces.Respositories;
using TEST_SOFTWARE.INFRASTRUCTURE.Data;
using TEST_SOFTWARE.INFRASTRUCTURE.Services;

namespace TEST_SOFTWARE.INFRASTRUCTURE.Repositories
{
    public class PersonaRepository : IDirectorio
    {
        private readonly string storedProcedure = "sp_Personas";
        private SqlConnection connection;
        private SqlCommand command;
        private SqlTransaction transaction;
        private RepositoryService repositoryService;
        public PersonaRepository()
        {
            connection = new SqlConnection(ConnectionProps.ConnectionString);
            command = connection.CreateCommand();

            repositoryService = new RepositoryService();
        }
        public async Task<Person> CreatePerson(Person person)
        {
            connection.Open();
            transaction = connection.BeginTransaction();
            command = connection.CreateCommand();
            command.Transaction = transaction;
            try
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = storedProcedure;
                command.Parameters.AddWithValue("@QueryType", 1);
                command.Parameters.AddWithValue("@Nombre", person.Nombre);
                command.Parameters.AddWithValue("@Apellido_Paterno", person.Apellido_Paterno);
                command.Parameters.AddWithValue("@Apellido_Materno", person.Apellido_Materno);
                command.Parameters.AddWithValue("@Identificacion", person.Identificacion);

                person.ID = Convert.ToInt32(await command.ExecuteScalarAsync());

                transaction.Commit();

                connection.Close();

                return person;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return new Person();
            }
        }

        public bool DeletePersonByIdentificacion(string Identificacion)
        {
            connection.Open();
            transaction = connection.BeginTransaction();
            command = connection.CreateCommand();
            command.Transaction = transaction;
            try
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = storedProcedure;
                command.Parameters.AddWithValue("@QueryType", 4);
                command.Parameters.AddWithValue("@Identificacion", Identificacion);

                command.ExecuteNonQuery();

                transaction.Commit();

                connection.Close();

                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return false;
            }
        }

        public async Task<Person> FindPersonByIdentitificacion(string Identificacion)
        {
            connection.Open();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = storedProcedure;
            command.Parameters.AddWithValue("@QueryType", 2);
            command.Parameters.AddWithValue("@Identificacion", Identificacion);

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;

            DataTable table = new DataTable();

            adapter.Fill(table);

            connection.Close(); 

            if(table.Rows.Count > 0)
            {
                Person person = repositoryService.GetPerson(table.Rows[0]);
                return await Task.FromResult(person);
            }
            else
            {
                return new Person();
            }
        }

        public async Task<List<Person>> FindPersons()
        {
            connection.Open();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = storedProcedure;
            command.Parameters.AddWithValue("@QueryType", 3);

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;

            DataTable table = new DataTable();

            adapter.Fill(table);

            connection.Close();
            
            if (table.Rows.Count > 0)
            {
                List<Person> persons = repositoryService.GetPersons(table);
                return await Task.FromResult(persons);
            }
            else
            {
                return new List<Person>();
            }
        }
    }
}
