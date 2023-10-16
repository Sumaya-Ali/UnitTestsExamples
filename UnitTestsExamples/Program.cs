// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using UnitTestsExamples;
using UnitTestsExamples.Data;

class Program
{
    static void Main(string[] args)
    {
        insertMyObject();
        Console.WriteLine("Hello, World!");
    }

    static void insertMyObject()
    {
        using (var db = new ApplicationDBContext())
        {
            MyObjectDataModel _object = new MyObjectDataModel() { 
                FName="Sumaya",
                LName="Ali"
            };
      
            db.Add(_object);

            _object = new MyObjectDataModel() {
                FName = "Sarah",
                LName = "Ali"
            };
            db.Add(_object);

            db.SaveChanges();
        }
        return;
    }
}
