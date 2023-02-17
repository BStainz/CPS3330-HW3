using static System.Console;
namespace bhannon_ooplab
{
    internal class Program{
        static void Main(string[] args) {
            KeanPerson student = new();
            KeanPerson alumni = new();
            KeanFaculty csTeacher = new();
            KeanFaculty itTeacher = new();
            student.Id = 900;
            student.FirstName = "Arnold";
            student.LastName = "Higgins";
            student.Department = "Computer Science";
            csTeacher.Id = 4355;
            csTeacher.FirstName = "Joy";
            csTeacher.LastName = "Minister";
            csTeacher.Department = "Computer Science";
            csTeacher.Salary = 60_000;
            csTeacher.YearsAsFaculty = 8;
            student.WelcomeMessage();
            student.PrintFullData(1,student);
            csTeacher.WelcomeMessage();
            csTeacher.PrintFullData(2, csTeacher);
        }
    } //Brendan Hannon CPS 3330-01 Spring 2023 Assignment3
    class KeanFaculty : KeanPerson {
        public double Salary { get; set; }
        private int yearsasFaculty;
        public int YearsAsFaculty{
            get{
                return yearsasFaculty;
            }
            set{
                if (value > 20)
                    id = 1000;
                else
                yearsasFaculty = value;
            }
        }
        internal (double, int) GetData(){
            return (Salary, YearsAsFaculty);
        }
        public override void PrintFullData(int order, KeanPerson a){
            base.PrintFullData(order, a);
            WriteLine($"My Salary is : {Salary} ");
            WriteLine($"My Years as Faculty : {YearsAsFaculty}");
        }
    }

    class KeanPerson { //Kean ID ends in 3
        protected int id;
        public string FirstName { get; set; }
        public string LastName { get; set; } //not sure if Last Price was typo or not so created last name also
        public string Department { get; set; }
        public double LastPrice { get; set; } //not sure if Last Price was typo or not so created last name also        
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                if (value < 1000)
                    id = value + 1000;
                else
                    id = value;

            }
        }
        
        public KeanPerson(){
            FirstName = "Empty";
            LastName = "Empty";
            Department = "empty";
            LastPrice = 15;
            WriteLine("The Kean ID#{0} created. {1} {2} in the {3} department paid {4} for their id",id, FirstName,LastName,Department,LastPrice.ToString("C"));            
        }
        public KeanPerson(int keanid, string firstName, string lastName, string department, double lastPrice){
            id = keanid;
            FirstName = firstName;
            LastName = lastName;
            Department = department;
            LastPrice = lastPrice;
        }
        public KeanPerson(string firstName, string lastName, string department) : this(99999,firstName, lastName, department,15){   
        }
        public KeanPerson(char code) : this(46290,"Ell", "Coreleone", "Arts",0){
        }        //Brendan Hannon CPS 3330-01 Spring 2023 Assignment3               
        internal void WelcomeMessage(){
            WriteLine("Hello to you from Kean ID #{0}", id);
        }
        internal (string,int) GetData(){
            return (FirstName, id);
        }
        internal (string, string, int) GetFullIdentificationData() {
            return (FirstName, LastName, id);
        }
        internal (string, string, int, string, double) GetFullData(){
            return (FirstName, LastName, id, Department, LastPrice);
        }
        public virtual void PrintFullData(int order, KeanPerson a){
            Write(order);
            a.GetFullData();
            (string fName, string lName, int keanid, string dep, double lPrice) = a.GetFullData();
            WriteLine($"My ID is : {keanid}");
            WriteLine($"My First name is : {fName}");
            WriteLine($"My Last name is : {lName}");
            WriteLine($"I am in the {dep} department");
            WriteLine($"The Last price is : ${lPrice}");
        }
    }
}