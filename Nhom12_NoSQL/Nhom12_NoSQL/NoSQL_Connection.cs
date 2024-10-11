using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Neo4j.Driver;
using Nhom12_NoSQL.Model;
using Newtonsoft.Json;
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
        public INode SelectNode(string query)
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
                        return record[0].As<INode>();
                    }
                );
                return queryResult.Result;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<Tuple<INode ,string,int>> LayTTVoChongVaTinhTrangQuanHe(string query)
        {
            List<Tuple<INode, string, int>> danhSachVoChong = new List<Tuple<INode, string, int>>();
            var session = driver.AsyncSession();
            try
            {
                var queryResult = session.ExecuteWriteAsync(
                    async tx =>
                    {
                        var result = await tx.RunAsync(
                            query
                            );
                        var record = await result.ToListAsync();
                        return record;
                    }
                );
                foreach(var item in queryResult.Result)
                {
                    var node = item[0]?.As<INode>();
                    var tinhTrangQuanHe = item[1]?.As<string>();
                    var keTu = item[2].As<int>();
                    danhSachVoChong.Add(Tuple.Create(node, tinhTrangQuanHe, keTu));
                }
                return danhSachVoChong;

            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<Tuple<string, string, string>> LayDSTruongHo(string query)
        {
            List<Tuple<string, string, string>> danhSachTruongHo = new List<Tuple<string, string, string>>();
            var session = driver.AsyncSession();
            try
            {
                var queryResult = session.ExecuteWriteAsync(
                    async tx =>
                    {
                        var result = await tx.RunAsync(
                            query
                            );
                        var record = await result.ToListAsync();
                        return record;
                    }
                );
                foreach (var item in queryResult.Result)
                {
                    var hoTen = item[0].As<string>();
                    var ngaySinh = item[1].As<string>();
                    var doiThu = item[2].As<string>();
                    danhSachTruongHo.Add(Tuple.Create(hoTen, ngaySinh, doiThu));
                }
                return danhSachTruongHo;

            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<INode> SelectListNode(string query)
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
                        var record = await result.ToListAsync(row => row[0].As<INode>());
                        return record;
                    }
                );
                return queryResult.Result;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<IRecord> SelectListProperties(string query)
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
                        var record = await result.ToListAsync();
                        return record;
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
        public int CreateTraVeID(string query)
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
                        return record[0].As<int>();
                    }
                );
                return queryResult.Result;
            }
            catch (Exception)
            {
                return -1;
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
                        return result.ConsumeAsync();
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
                        var result = await tx.RunAsync(query);
                    }
                );
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public void BackupDatabase(string filePath)
        {            
            var session = driver.AsyncSession();
            try
            {
                // Thực thi truy vấn để lấy tất cả node và quan hệ
                var query = @"
                    MATCH (n)
                    OPTIONAL MATCH (n)-[r]->(m)
                    RETURN n AS node, r AS relationship, m AS relatedNode";

                var nodes = new List<object>();

                var result = session.RunAsync(query);

                while (result.Result.FetchAsync().Result)
                {
                    var node = result.Result.Current["node"];
                    var relationship = result.Result.Current["relationship"];
                    var relatedNode = result.Result.Current["relatedNode"];

                    // Chuyển đổi kết quả sang một định dạng JSON-friendly
                    var nodeData = new
                    {
                        Node = node.As<INode>().Properties,
                        Relationship = relationship?.As<IRelationship>()?.Properties,
                        RelatedNode = relatedNode?.As<INode>()?.Properties
                    };

                    nodes.Add(nodeData);
                }
                var jsonData = JsonConvert.SerializeObject(nodes, Formatting.Indented);
                File.WriteAllText(filePath, jsonData);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                MessageBox.Show("Đã xảy ra lỗi khi sao lưu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void closeConnection()
        {
            driver.Dispose();
        }
    }
}
