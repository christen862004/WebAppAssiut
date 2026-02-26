namespace WebAppAssiut.ViewModels
{
    public class EmpDetailsWithTempColrBrcnahsMsgViewModel
    {
        //Some Moddel PRoperty
        public int EmpId { get; set; }
        public string EmpName { get; set; }

        //add some Extar Property
        public string Msg { get; set; }
        public int Temp { get; set; }
        public string Color { get; set; }
        public List<string> Branches { get; set; }
    }
}
