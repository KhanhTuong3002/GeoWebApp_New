using BusinessObject.Entites;
using DataAccess.DAO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class UserRepo(DbContext dbContext) : BaseRepository<User>(new UserDao(dbContext))
    {
        public async Task<bool> UploadAvatarAsync(string userId, Stream imageStream)
        {
            try
            {
                // Đọc dữ liệu của ảnh từ Stream
                using (var memoryStream = new MemoryStream())
                {
                    await imageStream.CopyToAsync(memoryStream);
                    byte[] imageBytes = memoryStream.ToArray();

                    // Chuyển đổi ảnh thành chuỗi Base64
                    string base64String = Convert.ToBase64String(imageBytes);

                    // Lưu base64String vào cơ sở dữ liệu
                    var user = await UserDao.GetByIdAsync(userId);
                    if (user != null)
                    {
                        user.Avatar = base64String;
                        await dbContext.SaveChangesAsync();
                        return true;
                    }
                    else
                    {
                        // User không tồn tại
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có
                Console.WriteLine($"Error uploading avatar: {ex.Message}");
                return false;
            }
        }
    }
}
