using Dapper;
using Eshop.Application.Services;
using Eshop.Persistence.ConnectionFactory;
using Eshop.Persistence.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Persistence.Services
{
    public class StorageService : IStorageService
    {
        private readonly DbConnectionFactory _connectionFactory;
        public StorageService(DbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task Fill()
        {
            var sql = @"TRUNCATE TABLE [dbo].[Product]";

            using var cn = _connectionFactory.CreateConnection();
            await cn.ExecuteAsync(sql);

            int rowCount = 50000;

            var tasks = new Task[]
            {
                Task.Factory.StartNew<string[]>(() => ProductFieldGenerator.GenerateRandomProductNames(5, 16, rowCount)),
                Task.Factory.StartNew<List<decimal>>(() => ProductFieldGenerator.GenerateRandomProductPrices(10, 5000, rowCount)),
                Task.Factory.StartNew<string[]>(() => ProductFieldGenerator.GenerateUniqueProductBarcodes(13, rowCount)),
                Task.Factory.StartNew<int[]>(() => ProductFieldGenerator.GenerateUniqueProductPLUs(1, 99999, rowCount))
            };

            Task.WaitAll(tasks);

            var names = (tasks[0] as Task<string[]>).Result;
            var prices = (tasks[1] as Task<List<decimal>>).Result;
            var barcodes = (tasks[2] as Task<string[]>).Result;
            var plus = (tasks[3] as Task<int[]>).Result;

            DataTable dt = new();
            dt.Columns.Add(new DataColumn("Name", typeof(string)));
            dt.Columns.Add(new DataColumn("Price", typeof(decimal)));
            dt.Columns.Add(new DataColumn("Barcode", typeof(string)));
            dt.Columns.Add(new DataColumn("PLU", typeof(int)));
            dt.Columns.Add(new DataColumn("DateCreated", typeof(DateTimeOffset)));

            var nowDate = DateTimeOffset.UtcNow;
            for (int i = 0; i < rowCount; i++)
            {
                var row = dt.NewRow();
                row["Name"] = names[i];
                row["Price"] = prices[i];
                row["Barcode"] = barcodes[i];
                row["PLU"] = plus[i];
                row["DateCreated"] = nowDate;

                dt.Rows.Add(row);
            }

            SqlBulkCopy bulk = new(cn as SqlConnection);
            bulk.DestinationTableName = "[dbo].[Product]";

            bulk.ColumnMappings.Add("Name", "Name");
            bulk.ColumnMappings.Add("Price", "Price");
            bulk.ColumnMappings.Add("Barcode", "Barcode");
            bulk.ColumnMappings.Add("PLU", "PLU");
            bulk.ColumnMappings.Add("DateCreated", "DateCreated");

            bulk.WriteToServer(dt);
        }

        public async Task Drop()
        {
            var sql = @"TRUNCATE TABLE [dbo].[Product]";

            using var cn = _connectionFactory.CreateConnection();
            await cn.ExecuteAsync(sql);
        }
    }
}
