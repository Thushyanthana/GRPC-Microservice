using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userGRPC.GRPCDB;

namespace userGRPC.Repository
{
    public class GreetRepository: IGreetRepository
    {
        private readonly GRPCDBContext dbContext;

        public GreetRepository(GRPCDBContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task<List<User>> getUserList()
        {
            var authDetails = await dbContext.Users.ToListAsync();
            return authDetails;
        }

        public async Task<User> PostUser(User user)
        {
            var authDetail = await dbContext.Users.ToListAsync();            
                try
                {
                    var authDetails = await dbContext.Users.AddAsync(user);
                    await dbContext.SaveChangesAsync().ConfigureAwait(true);
                    return authDetails.Entity;
                }
                catch (Exception e)
                {
                    throw;
                }            
        }

        public async Task<User> getUserById(int id)
        {
            var User = await dbContext.Users.SingleOrDefaultAsync(x =>x.Id==id );
            return User;
        }

       
        public async Task<User> updateSingleUser(User us)
        {
            dbContext.Entry(us).State = EntityState.Modified;
            dbContext.SaveChanges();
            return   us;
        }

        public async Task<string> DeleteUser(int Id)
        {
            var us = dbContext.Users.SingleOrDefault(x => x.Id == Id);
            if (us != null)
            {
                dbContext.Users.Remove(us);
                dbContext.SaveChanges();
            }            
                return "Successfully Deleted  " + us.Id;
         }

       public async Task<CalculateGrade> CalculateGr(int Id)
        {
            var res =await dbContext.Users.SingleOrDefaultAsync(x=> x.Id==Id);
            CalculateGrade responseModel = new CalculateGrade();
           

            int o = 300;
            int p = 250;
            int x = 200;
            int y = 150;
            int z = 100;
            int s = 55;

            string A = "A";
            string B = "B";
            string C = "C";
            string D = "D";
            string E = "E";
            string F = "F";

            if (res != null)
            {
                double total = (res.Mark1 + res.Mark2 + res.Mark3);
                responseModel.Id = res.Id;
                responseModel.IsValid = true;
                responseModel.NameWithInitail = res.NameWithInitail;
                responseModel.Total = total;
                if (total > p && total < o)
                {
                    responseModel.Grade = A;
                }
                else if (total > x && total < p)
                {
                    responseModel.Grade = B;
                }
                else if (total > y && total < x)
                {
                    responseModel.Grade = C;
                }
                else if (total > z && total < y)
                {
                    responseModel.Grade = D;
                }
                else if (total > s && total < z)
                {
                    responseModel.Grade = E;
                }
                else if (total < s)
                {
                    responseModel.Grade = F;
                }
            }
            else
            {
                responseModel.IsValid = false;
            }
                       
            return responseModel;
            
        }

    }
}
