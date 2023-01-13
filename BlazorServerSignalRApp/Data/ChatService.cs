namespace BlazorServerSignalRApp.Data
{
    public class ChatService
    {
        public Dictionary<string, string> Users;

        public ChatService()
        {
            Users = new Dictionary<string, string>();
        }

        public void AddUser(string id,string name)
        {
            try {
            Users.Add(id,name); 
            Console.WriteLine("Id:"+id +"Name:"+name + " added");
            }
            catch {
                Console.WriteLine("Error: The user has already been added");
            }
        }
    }
}
