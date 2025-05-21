namespace GymManagement.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GymManagement.Models.GymDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GymManagement.Models.GymDbContext context)
        {
            // Kiểm tra xem đã có tài khoản admin chưa
            if (!context.Users.Any(u => u.Email == "admin@gym.com"))
            {
                context.Users.AddOrUpdate(new Models.User
                {
                    FullName = "Quản trị viên",
                    Email = "admin@gym.com",
                    Password = "123456", // ⚠️ Bạn nên dùng mã hóa mật khẩu nếu dùng thật
                    Role = "Admin"
                });

                context.SaveChanges();
            }

            // Bạn có thể thêm tài khoản người dùng thường nếu muốn:
            if (!context.Users.Any(u => u.Email == "user@gym.com"))
            {
                context.Users.AddOrUpdate(new Models.User
                {
                    FullName = "Người dùng thường",
                    Email = "user@gym.com",
                    Password = "123456",
                    Role = "User"
                });

                context.SaveChanges();
            }
        }


    }
}
