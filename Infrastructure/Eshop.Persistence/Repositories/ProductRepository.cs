using Dapper;
using Eshop.Application.Repositories;
using Eshop.Domain.Common;
using Eshop.Domain.Entities;
using Eshop.Persistence.ConnectionFactory;
using Eshop.Persistence.Helpers;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Eshop.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DbConnectionFactory _connectionFactory;

        public ProductRepository(DbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<Product> Create(Product product, CancellationToken cancellationToken)
        {
            var sql = @"INSERT INTO [dbo].[Product] ([Name],[Price],[Barcode],[PLU],[DateCreated])
                        VALUES (@Name,@Price,@Barcode,@PLU,@DateCreated)
                        SELECT SCOPE_IDENTITY()";

            using var cn = await _connectionFactory.CreateConnectionAsync(cancellationToken);
            var newProductID = await cn.ExecuteScalarAsync<long>(sql, product);
            return await Get(new Product { ID = newProductID }, cancellationToken);
        }

        public async Task<Product> Update(Product product)
        {
            var sql = @"UPDATE [dbo].[Product]
                        SET [Name]=@Name,[Price]=@Price,[Barcode]=@Barcode,[PLU]=@PLU,[DateModified]=@DateModified
                        WHERE [ID]=@ID";

            using var cn = _connectionFactory.CreateConnection();
            await cn.ExecuteAsync(sql, product);
            return await Get(product, default);
        }

        public async Task<bool> Delete(Product product)
        {
            var sql = @"DELETE FROM [dbo].[Product]
                        WHERE [ID]=@ID";

            using var cn = _connectionFactory.CreateConnection();
            await cn.ExecuteAsync(sql, product);
            return true;
        }

        public async Task<Product> Get(Product product, CancellationToken cancellationToken)
        {
            var sql = @"SELECT * FROM [dbo].[Product]
                        WHERE [ID]=@ID";

            using var cn = await _connectionFactory.CreateConnectionAsync(cancellationToken);
            return await cn.QuerySingleOrDefaultAsync<Product>(sql, product);
        }

        public async Task<Product> GetByBarcode(Product product, CancellationToken cancellationToken)
        {
            var sql = @"SELECT TOP(1) * FROM [dbo].[Product]
                        WHERE [Barcode]=@Barcode";

            using var cn = await _connectionFactory.CreateConnectionAsync(cancellationToken);
            return await cn.QueryFirstOrDefaultAsync<Product>(sql, product);
        }

        public async Task<Product> GetByPLU(Product product, CancellationToken cancellationToken)
        {
            var sql = @"SELECT TOP(1) * FROM [dbo].[Product]
                        WHERE [PLU]=@PLU";

            using var cn = await _connectionFactory.CreateConnectionAsync(cancellationToken);
            return await cn.QueryFirstOrDefaultAsync<Product>(sql, product);
        }

        public async Task<IEnumerable<Product>> GetAll(GetManyRequestSpecifications<Product> request, CancellationToken cancellationToken)
        {
            var sql = @"SELECT * FROM [dbo].[Product]";
            sql += request.ConvertGetManySpecificationRequestToSql<Product>();

            using var cn = await _connectionFactory.CreateConnectionAsync(cancellationToken);
            return await cn.QueryAsync<Product>(sql);
        }

        public async Task<int> GetCount()
        {
            var sql = @"SELECT COUNT(1) FROM [dbo].[Product]";

            using var cn = _connectionFactory.CreateConnection();
            return await cn.ExecuteScalarAsync<int>(sql);
        }
    }
}