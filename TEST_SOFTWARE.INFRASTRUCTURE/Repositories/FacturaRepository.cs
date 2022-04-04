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
    public class FacturaRepository : IVentas
    {
        private readonly string storedProcedure = "sp_Facturas";
        private SqlConnection connection;
        private SqlCommand command;
        private SqlTransaction transaction;
        private RepositoryService repositoryService;
        public FacturaRepository()
        {
            connection = new SqlConnection(ConnectionProps.ConnectionString);
            command = connection.CreateCommand();
            repositoryService = new RepositoryService();
        }
        public async Task<Invoice> CreateInvoice(Invoice invoice, string Identificacion)
        {
            connection.Open();
            transaction = connection.BeginTransaction();
            command.Transaction = transaction;
            try
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = storedProcedure;
                command.Parameters.AddWithValue("@QueryType", 1);
                command.Parameters.AddWithValue("@Fecha", invoice.Fecha);
                command.Parameters.AddWithValue("@Monto", invoice.Monto);
                command.Parameters.AddWithValue("@Identificacion", Identificacion);

                invoice.ID = Convert.ToInt32(await command.ExecuteScalarAsync());

                transaction.Commit();

                connection.Close(); 

                return invoice;
            }
            catch (Exception)
            {
                transaction.Rollback();
                connection.Close(); 
                return new Invoice();
            }
        }

        public async Task<List<Invoice>> FindInvoicesByPerson(string Identificacion)
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
                List<Invoice> invoices = repositoryService.GetInvoices(table);
                return await Task.FromResult(invoices);
            }
            else
            {
                return new List<Invoice>();
            }
        }
    }
}
