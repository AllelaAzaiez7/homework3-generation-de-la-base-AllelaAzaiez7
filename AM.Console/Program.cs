// See https://aka.ms/new-console-template for more information
using AM.ApplicationCore.Domain;

//Console.WriteLine("Hello, World!");

//constructeur par défaut
Plane plane = new Plane();
plane.Capacity = 300;
plane.ManufactureDate = DateTime.Now;
plane.PlaneType = PlaneType.Boing;
//Constructeur paramétré
Plane plane2 = new Plane(PlaneType.Boing,new DateTime(2018,2,12),200);

//initialiseur d'objet 
Plane plane3 = new Plane
{
    Capacity = 100,
    ManufactureDate = DateTime.Now,
    PlaneType = PlaneType.Boing,
    PlaneId = 2
};
Passenger p1 = new Passenger
{
   fUllName = new()
   {
       FirstName = "hassen",
       LastName = "messaoudi",
   } ,
    EmailAddress = "hassen@gmail.com"
};
Staff s1 = new Staff
{
    fUllName = new()
    {
        FirstName = "hassen",
        LastName = "messaoudi",
    },
    EmailAddress = "hassen@gmail.com"
};
Traveller t1 = new Traveller
{
    fUllName = new()
    {
        FirstName = "hassen",
        LastName = "messaoudi",
    },
    EmailAddress = "hassen@gmail.com"
};
p1.PassengerType();
p1.Checkprofile("hassen", "messaoudi");
s1.PassengerType();
t1.PassengerType();




