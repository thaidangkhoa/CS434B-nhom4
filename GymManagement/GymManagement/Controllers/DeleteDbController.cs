using System.Data.SqlClient;
using System.Web.Mvc;

namespace GymManagement.Controllers
{
    public class DeleteDbController : Controller
    {
        public string DropDatabase()
        {
            // Đây là chuỗi kết nối tới LocalDB – KHÔNG chỉ định tên database
            var connectionString = "Server=(localdb)\\MSSQLLocalDB;Integrated Security=true;";
            var databaseName = "GymDB";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Tắt kết nối đang sử dụng GymDB và xóa
                var setSingleUser = $"ALTER DATABASE [{databaseName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;";
                var dropDb = $"DROP DATABASE [{databaseName}];";

                using (var command = new SqlCommand(setSingleUser + dropDb, connection))
                {
                    command.ExecuteNonQuery();
                }
            }

            return "Đã xoá database GymDB thành công.";
        }
    }
}
