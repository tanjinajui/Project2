using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBMS.Model.Model;
using SBMS.Repository.Repository;

namespace SBMS.BLL.BLL
{
    public class UserManager
    {
        UserRepository _userRepository = new UserRepository();
        public bool Add(User suser)
        {
            return _userRepository.Add(suser);
        }
        public bool Delete(User suser)
        {
            return _userRepository.Delete(suser);
        }
        public bool Update(User suser)
        {
            return _userRepository.Update(suser);
        }
        public bool GetAll(User suser)
        {
            return _userRepository.GetAll(suser);
        }
        public User GetByID(User suser)
        {
            return _userRepository.GetByID(suser);
        }
      
    }
}
