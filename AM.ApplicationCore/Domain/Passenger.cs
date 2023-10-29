using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {

        //public int PassengerId { get; set; }
        [Key]
        [StringLength(7)]
        public string PassportNumber { get; set; }

        public FullName fUllName { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("date of birth")]

        public DateTime BirthDate { get; set; }
        //[DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^[0-9]{8}$", ErrorMessage = "Invalid Phone Number!")]

        public int? TelNumber { get; set; }
        //[DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string? EmailAddress { get; set; }

        public  IList<Flight> Flights { get; set; }

        public override string ToString()
        {
            return "FirstName: " + fUllName.FirstName + " LastName: " + fUllName.LastName + " date of Birth: " + BirthDate;
        }
        //poly par signature
       public bool Checkprofile(string nom,string prenom)
        {
            return fUllName.FirstName == prenom && fUllName.LastName == nom;    
        }
        public bool Checkprofile(string nom, string prenom,string email)
        {
            return fUllName.FirstName == prenom && fUllName.LastName == nom && EmailAddress==email;
        }
        public bool Login(string nom,string prenom,string email = null)
        {
            if(email!=null)
                return Checkprofile(nom,prenom,email);
               return Checkprofile(nom,prenom);
        }
        public virtual void PassengerType()
        {
            Console.WriteLine("i am passenger");
        }
        public virtual String PassengerType1()
        {
            return "i am passenger";
        }
    }
}
