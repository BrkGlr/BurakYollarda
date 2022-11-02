using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurakYollarda.Data.Dto
{
    public class AdminDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
		public string UserType { get; set; }

	}
}
