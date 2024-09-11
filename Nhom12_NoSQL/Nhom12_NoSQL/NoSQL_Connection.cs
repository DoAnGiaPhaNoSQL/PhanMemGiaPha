using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neo4j.Driver;
namespace Nhom12_NoSQL
{
    class NoSQL_Connection
    {
        private IDriver driver= GraphDatabase.Driver("bolt://localhost:7687", AuthTokens.Basic("neo4j", "12345678"));
        public string Select(string query)
        {
            var session = driver.AsyncSession();
            try
            {
                var queryResult = session.ExecuteWriteAsync(
                    async tx =>
                    {
                        var result = await tx.RunAsync(
                            query
                            );
                        var record = await result.SingleAsync();
                        return record[0].As<string>();
                    }
                );
                return queryResult.Result;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public bool Create(string query)
        {
            var session = driver.AsyncSession();
            try
            {
                var queryResult = session.ExecuteWriteAsync(
                    async tx =>
                    {
                        var result = await tx.RunAsync(
                            query
                            );
                        var record = await result.SingleAsync();
                        return record[0].As<string>();
                    }
                );
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Update(string query)
        {
            var session = driver.AsyncSession();
            try
            {
                var queryResult = session.ExecuteWriteAsync(
                    async tx =>
                    {
                        var result = await tx.RunAsync(
                            query
                            );
                        var record = await result.SingleAsync();
                        return record[0].As<string>();
                    }
                );
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete(string query)
        {
            var session = driver.AsyncSession();
            try
            {
                var queryResult = session.ExecuteWriteAsync(
                    async tx =>
                    {
                        var result = await tx.RunAsync(
                            query
                            );
                        var record = await result.SingleAsync();
                        return record[0].As<string>();
                    }
                );
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
