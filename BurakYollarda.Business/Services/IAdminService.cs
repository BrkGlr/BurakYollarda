using BurakYollarda.Business.Types;
using BurakYollarda.Data.Dto;
using BurakYollarda.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurakYollarda.Business.Services
{
    public interface IAdminService
    {
        AdminDto Login(string email, string password);

        AdminDto GetAdminById(int id);

         void UpdateAdmin(AdminDto admin);


    }
}
