using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StudentManagementAPI.StudentManagementAPI.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagementAPI.StudentManagementAPI.Backend.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (context.Students.Any() || context.Users.Any())
            {
                return; // DB has been seeded
            }

            // Dados de estudantes
            var students = new List<Student>
            {
                new Student { Nome = "Alice", Idade = 10, Serie = 5, NotaMedia = 8.5, Endereco = "123 Main St", NomePai = "John Doe", NomeMae = "Jane Doe", DataNascimento = DateTime.Parse("2013-05-15") },
                new Student { Nome = "Bob", Idade = 11, Serie = 6, NotaMedia = 7.2, Endereco = "456 Oak St", NomePai = "Bob Smith", NomeMae = "Alice Smith", DataNascimento = DateTime.Parse("2012-08-21") },
                new Student { Nome = "Charlie", Idade = 9, Serie = 4, NotaMedia = 9.0, Endereco = "789 Pine St", NomePai = "Charlie Brown", NomeMae = "Lucy Brown", DataNascimento = DateTime.Parse("2014-02-10") },
                new Student { Nome = "David", Idade = 10, Serie = 5, NotaMedia = 8.8, Endereco = "101 Cedar St", NomePai = "David Johnson", NomeMae = "Emily Johnson", DataNascimento = DateTime.Parse("2013-07-18") },
                new Student { Nome = "Emma", Idade = 11, Serie = 6, NotaMedia = 7.5, Endereco = "202 Elm St", NomePai = "Michael White", NomeMae = "Sophia White", DataNascimento = DateTime.Parse("2012-10-05") },
                new Student { Nome = "Frank", Idade = 9, Serie = 4, NotaMedia = 9.2, Endereco = "303 Maple St", NomePai = "Frank Williams", NomeMae = "Grace Williams", DataNascimento = DateTime.Parse("2014-01-22") },
                new Student { Nome = "Grace", Idade = 10, Serie = 5, NotaMedia = 8.0, Endereco = "404 Birch St", NomePai = "George Taylor", NomeMae = "Olivia Taylor", DataNascimento = DateTime.Parse("2013-04-30") },
                new Student { Nome = "Henry", Idade = 11, Serie = 6, NotaMedia = 7.8, Endereco = "505 Spruce St", NomePai = "Henry Moore", NomeMae = "Lily Moore", DataNascimento = DateTime.Parse("2012-09-14") },
                new Student { Nome = "Isabel", Idade = 9, Serie = 4, NotaMedia = 9.5, Endereco = "606 Walnut St", NomePai = "Isaac Davis", NomeMae = "Ava Davis", DataNascimento = DateTime.Parse("2014-03-07") },
                new Student { Nome = "Jack", Idade = 10, Serie = 5, NotaMedia = 7.9, Endereco = "707 Sycamore St", NomePai = "Jack Smith", NomeMae = "Emma Smith", DataNascimento = DateTime.Parse("2013-06-19") },
                new Student { Nome = "Katherine", Idade = 11, Serie = 6, NotaMedia = 8.3, Endereco = "808 Cedar St", NomePai = "James Martin", NomeMae = "Sophia Martin", DataNascimento = DateTime.Parse("2012-11-28") },
                new Student { Nome = "Liam", Idade = 9, Serie = 4, NotaMedia = 9.1, Endereco = "909 Oak St", NomePai = "Liam Turner", NomeMae = "Ella Turner", DataNascimento = DateTime.Parse("2014-02-01") },
                new Student { Nome = "Mia", Idade = 10, Serie = 5, NotaMedia = 8.7, Endereco = "1010 Maple St", NomePai = "Ryan Brown", NomeMae = "Mia Brown", DataNascimento = DateTime.Parse("2013-05-12") },
                new Student { Nome = "Nathan", Idade = 11, Serie = 6, NotaMedia = 7.4, Endereco = "1111 Birch St", NomePai = "Nathan Harris", NomeMae = "Eva Harris", DataNascimento = DateTime.Parse("2012-08-03") },
                new Student { Nome = "Olivia", Idade = 9, Serie = 4, NotaMedia = 9.3, Endereco = "1212 Pine St", NomePai = "Daniel Green", NomeMae = "Olivia Green", DataNascimento = DateTime.Parse("2014-01-09") },
                new Student { Nome = "Peter", Idade = 10, Serie = 5, NotaMedia = 8.4, Endereco = "1313 Elm St", NomePai = "Peter Clark", NomeMae = "Ava Clark", DataNascimento = DateTime.Parse("2013-04-18") },
                new Student { Nome = "Quinn", Idade = 11, Serie = 6, NotaMedia = 7.1, Endereco = "1414 Cedar St", NomePai = "Quinn Davis", NomeMae = "Grace Davis", DataNascimento = DateTime.Parse("2012-09-27") },
                new Student { Nome = "Rachel", Idade = 9, Serie = 4, NotaMedia = 9.4, Endereco = "1515 Walnut St", NomePai = "Richard White", NomeMae = "Rachel White", DataNascimento = DateTime.Parse("2014-02-14") },
                new Student { Nome = "Sam", Idade = 10, Serie = 5, NotaMedia = 8.6, Endereco = "1616 Sycamore St", NomePai = "Sam Turner", NomeMae = "Emily Turner", DataNascimento = DateTime.Parse("2013-06-06") },
                new Student { Nome = "Tristan", Idade = 11, Serie = 6, NotaMedia = 7.7, Endereco = "1717 Spruce St", NomePai = "Tristan Harris", NomeMae = "Lily Harris", DataNascimento = DateTime.Parse("2012-11-23") },
                new Student { Nome = "Uma", Idade = 9, Serie = 4, NotaMedia = 9.6, Endereco = "1818 Maple St", NomePai = "Uma Smith", NomeMae = "Sophia Smith", DataNascimento = DateTime.Parse("2014-03-30") },
                new Student { Nome = "Victor", Idade = 10, Serie = 5, NotaMedia = 8.2, Endereco = "1919 Oak St", NomePai = "Victor Martin", NomeMae = "Ella Martin", DataNascimento = DateTime.Parse("2013-05-24") },
                new Student { Nome = "Wendy", Idade = 11, Serie = 6, NotaMedia = 7.0, Endereco = "2020 Pine St", NomePai = "Wendy Brown", NomeMae = "Michael Brown", DataNascimento = DateTime.Parse("2012-10-10") },
                new Student { Nome = "Xander", Idade = 9, Serie = 4, NotaMedia = 9.7, Endereco = "2121 Birch St", NomePai = "Xander Turner", NomeMae = "Sophia Turner", DataNascimento = DateTime.Parse("2014-01-17") },
                new Student { Nome = "Yara", Idade = 10, Serie = 5, NotaMedia = 8.1, Endereco = "2222 Elm St", NomePai = "Yara Davis", NomeMae = "John Davis", DataNascimento = DateTime.Parse("2013-04-04") },
                new Student { Nome = "Zane", Idade = 11, Serie = 6, NotaMedia = 7.3, Endereco = "2323 Cedar St", NomePai = "Zane Harris", NomeMae = "Lily Harris", DataNascimento = DateTime.Parse("2012-09-08") },
                new Student { Nome = "Aaron", Idade = 9, Serie = 4, NotaMedia = 9.8, Endereco = "2424 Walnut St", NomePai = "Aaron Smith", NomeMae = "Sophia Smith", DataNascimento = DateTime.Parse("2014-02-21") },
                new Student { Nome = "Bella", Idade = 10, Serie = 5, NotaMedia = 8.9, Endereco = "2525 Sycamore St", NomePai = "Bella Martin", NomeMae = "Ella Martin", DataNascimento = DateTime.Parse("2013-06-14") },
                new Student { Nome = "Carlos", Idade = 11, Serie = 6, NotaMedia = 7.6, Endereco = "2626 Spruce St", NomePai = "Carlos Turner", NomeMae = "Emily Turner", DataNascimento = DateTime.Parse("2012-11-05") },
                new Student { Nome = "Diana", Idade = 9, Serie = 4, NotaMedia = 9.9, Endereco = "2727 Maple St", NomePai = "Diana White", NomeMae = "Michael White", DataNascimento = DateTime.Parse("2014-03-18") },
                new Student { Nome = "Ethan", Idade = 10, Serie = 5, NotaMedia = 8.8, Endereco = "2828 Oak St", NomePai = "Ethan Brown", NomeMae = "Sophia Brown", DataNascimento = DateTime.Parse("2013-04-23") },
                new Student { Nome = "Fiona", Idade = 11, Serie = 6, NotaMedia = 7.5, Endereco = "2929 Pine St", NomePai = "Fiona Harris", NomeMae = "John Harris", DataNascimento = DateTime.Parse("2012-10-16") },
                new Student { Nome = "Gavin", Idade = 9, Serie = 4, NotaMedia = 9.2, Endereco = "3030 Birch St", NomePai = "Gavin Smith", NomeMae = "Olivia Smith", DataNascimento = DateTime.Parse("2014-01-03") },
                new Student { Nome = "Holly", Idade = 10, Serie = 5, NotaMedia = 8.0, Endereco = "3131 Cedar St", NomePai = "Holly Davis", NomeMae = "Daniel Davis", DataNascimento = DateTime.Parse("2013-05-29") },
                new Student { Nome = "Ian", Idade = 11, Serie = 6, NotaMedia = 7.8, Endereco = "3232 Elm St", NomePai = "Ian Turner", NomeMae = "Sophia Turner", DataNascimento = DateTime.Parse("2012-09-20") },
                new Student { Nome = "Jenna", Idade = 9, Serie = 4, NotaMedia = 9.5, Endereco = "3333 Sycamore St", NomePai = "Jenna Martin", NomeMae = "Ella Martin", DataNascimento = DateTime.Parse("2014-02-26") },
                new Student { Nome = "Kevin", Idade = 10, Serie = 5, NotaMedia = 8.4, Endereco = "3434 Spruce St", NomePai = "Kevin Harris", NomeMae = "Lily Harris", DataNascimento = DateTime.Parse("2013-06-09") },
                new Student { Nome = "Lila", Idade = 11, Serie = 6, NotaMedia = 7.2, Endereco = "3535 Maple St", NomePai = "Lila White", NomeMae = "Michael White", DataNascimento = DateTime.Parse("2012-08-14") },
                new Student { Nome = "Mark", Idade = 9, Serie = 4, NotaMedia = 9.3, Endereco = "3636 Oak St", NomePai = "Mark Brown", NomeMae = "Sophia Brown", DataNascimento = DateTime.Parse("2014-01-12") },
                new Student { Nome = "Nina", Idade = 10, Serie = 5, NotaMedia = 8.7, Endereco = "3737 Pine St", NomePai = "Nina Smith", NomeMae = "Olivia Smith", DataNascimento = DateTime.Parse("2013-05-17") },
                new Student { Nome = "Oscar", Idade = 11, Serie = 6, NotaMedia = 7.9, Endereco = "3838 Birch St", NomePai = "Oscar Turner", NomeMae = "Emily Turner", DataNascimento = DateTime.Parse("2012-09-30") },
                new Student { Nome = "Paula", Idade = 9, Serie = 4, NotaMedia = 9.4, Endereco = "3939 Elm St", NomePai = "Paula Harris", NomeMae = "John Harris", DataNascimento = DateTime.Parse("2014-03-11") },
                new Student { Nome = "Quincy", Idade = 10, Serie = 5, NotaMedia = 8.1, Endereco = "4040 Cedar St", NomePai = "Quincy Davis", NomeMae = "Daniel Davis", DataNascimento = DateTime.Parse("2013-04-01") },
                new Student { Nome = "Ruby", Idade = 11, Serie = 6, NotaMedia = 7.7, Endereco = "4141 Sycamore St", NomePai = "Ruby Martin", NomeMae = "Ella Martin", DataNascimento = DateTime.Parse("2012-11-30") },
                new Student { Nome = "Steve", Idade = 9, Serie = 4, NotaMedia = 9.6, Endereco = "4242 Spruce St", NomePai = "Steve White", NomeMae = "Michael White", DataNascimento = DateTime.Parse("2014-02-04") },
                new Student { Nome = "Tina", Idade = 10, Serie = 5, NotaMedia = 8.3, Endereco = "4343 Maple St", NomePai = "Tina Brown", NomeMae = "Sophia Brown", DataNascimento = DateTime.Parse("2013-05-08") },
                new Student { Nome = "Ursula", Idade = 11, Serie = 6, NotaMedia = 7.1, Endereco = "4444 Oak St", NomePai = "Ursula Smith", NomeMae = "Olivia Smith", DataNascimento = DateTime.Parse("2012-08-27") },
                new Student { Nome = "Vince", Idade = 9, Serie = 4, NotaMedia = 9.1, Endereco = "4545 Pine St", NomePai = "Vince Turner", NomeMae = "Emily Turner", DataNascimento = DateTime.Parse("2014-01-20") },
                new Student { Nome = "Wes", Idade = 10, Serie = 5, NotaMedia = 8.9, Endereco = "4646 Birch St", NomePai = "Wes Harris", NomeMae = "Lily Harris", DataNascimento = DateTime.Parse("2013-04-27") },
                new Student { Nome = "Xena", Idade = 11, Serie = 6, NotaMedia = 7.4, Endereco = "4747 Elm St", NomePai = "Xena Davis", NomeMae = "John Davis", DataNascimento = DateTime.Parse("2012-09-13") },
                new Student { Nome = "Yvonne", Idade = 9, Serie = 4, NotaMedia = 9.7, Endereco = "4848 Sycamore St", NomePai = "Yvonne Martin", NomeMae = "Ella Martin", DataNascimento = DateTime.Parse("2014-03-24") },
                new Student { Nome = "Zach", Idade = 10, Serie = 5, NotaMedia = 8.2, Endereco = "4949 Spruce St", NomePai = "Zach White", NomeMae = "Michael White", DataNascimento = DateTime.Parse("2013-05-03") },
            };

            context.Students.AddRange(students);

            var users = new List<User>
            {
                new User { Username = "admin", Password = "admin123" },
            };

            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}
