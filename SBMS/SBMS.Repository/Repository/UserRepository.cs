using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBMS.DatabaseContext.DatabaseContext;
using SBMS.Model.Model;


namespace SBMS.Repository.Repository
{
    public class UserRepository
    {
        SBMS_DBContext db = new SBMS_DBContext();
        public bool Add(User suser)
        {

            int isExecuted = 0;
            db.Users.Add(suser);
            isExecuted = db.SaveChanges();
            if (isExecuted > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(User suser)
        {
            int isExecuted = 0;
            User aUser = db.Users.FirstOrDefault(c => c.UserID == suser.UserID);
            if (aUser != null)
            {
                db.Users.Remove(aUser);
                isExecuted = db.SaveChanges();
            }

            if (isExecuted > 0)
            { return true; }
            else { return false; }


        }

        public bool Update(User suser)
        {
            int isExecuted = 0;
            db.Entry(suser).State = EntityState.Modified;
            isExecuted = db.SaveChanges();
            if (isExecuted > 0)
            {
                return true;

            }

            else
            {
                return false;
            }

        }

        public bool GetAll(User suser)
        {
            return false;
        }

        public User GetByID(User sUser)
        {
            User aUser = db.Users.FirstOrDefault(c => c.UserID == sUser.UserID);
            return aUser;
        }
      
    }
}
