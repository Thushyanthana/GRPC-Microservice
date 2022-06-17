using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace userGRPC.Repository
{
  public  interface IGreetRepository
    {

        Task<List<User>> getUserList();
        Task<User> PostUser(User user);
        Task<User> updateSingleUser(User us);
        Task<User> getUserById(int id);

        Task<string> DeleteUser(int Id);

        Task<CalculateGrade> CalculateGr(int Id);

    }
}
