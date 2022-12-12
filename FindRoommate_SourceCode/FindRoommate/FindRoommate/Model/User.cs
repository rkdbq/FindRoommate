namespace FindRoommate.Model
{
    public class User
    {
        public string userName { get; set; }

        public User(string name)
        {
            this.userName = name;
        }
    }
}
