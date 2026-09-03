using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class AppUser
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        //Kunne ha brukt data annotations for max og min length,
        //men ikke nødevendigvis alle som bruker 8nr
        public int PhoneNumber { get; set; }
    }
}
