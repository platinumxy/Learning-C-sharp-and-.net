// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
using System.Reflection.Metadata;
using System.Runtime.ExceptionServices;

namespace program
{
    class user
    {
        private int id;
        private string name, email;

        public int Id {
            get { return id; }
        }

        public string Name { get { return name; } } 
        bool changeName (string newName, int validationId) {
            if (id == validationId) 
                name = newName;
            return id == validationId; 

        }

        public string Email { get { return email; } }
        bool changeEmail(string newEmail, int validationId) {
            if (id == validationId)         
                email = newEmail;
            return id == validationId;
        }

        public user(string Nname, string Nemail, int Nid) {
            name = Nname;
            email = Nemail;
            id = Nid;
        }

        public void showInfo()
        {
            Console.WriteLine($"Name    : {Name}");
            Console.WriteLine($"Email   : {Email}");
            Console.WriteLine($"User ID : {Id}");

        }
    }

    class admin : user
    {
        private string pass;
        private int wrongPGuesses = 0;
        bool isCorrrectPass(string guess) {
            if (pass == guess) {
                return true;
            }
            wrongPGuesses++;
            return false; 
        }          

        public admin(string Nname, string Nemail, int Nid, string Npass) 
            : base (Nname, Nemail, Nid) // Because we do not have a empty constructor we must send the base consturctor the peramitars 
        {
            pass = Npass;
        }

        public new void showInfo()
        {
            base.showInfo();
            Console.WriteLine("Admin   : true");
        }
    }

    class main
    {
        static int UTCTimeStamp () { return (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;}
        
        static string getInput(string message)
        {
            if (message != null) { Console.WriteLine(message); }
            var input = Console.ReadLine();
            if (input == null) { return getInput(message); }
            return input;

        }

        static void Main(string[] args){
            var users = new List<user>(); 

            users.Add(new user(getInput("Whats your name"), getInput("Whats your email"), UTCTimeStamp()));
            users[0].showInfo();

            users.Add(new admin(getInput("Whats your name"), getInput("Whats your email"), UTCTimeStamp(), getInput("Whats your password")));
            users[1].showInfo();


            var userDict = new Dictionary<string, user>();
            foreach (var user in users)
            {
                userDict.Add(user.Name, user);
            }

            string input;
            while (true)
            {
                input = getInput("Enter a user name to show info on (EXIT):");
                if (input == null || input == "EXIT") { return; }
                try
                {
                    userDict[input].showInfo();
                }
                catch {
                    Console.WriteLine("Error User Not Accessable");
                } 
            }

        }
    }

 }