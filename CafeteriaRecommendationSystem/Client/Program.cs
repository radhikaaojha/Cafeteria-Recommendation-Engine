namespace Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Client client = new Client();
            await client.StartClient();
        }
    }
}
