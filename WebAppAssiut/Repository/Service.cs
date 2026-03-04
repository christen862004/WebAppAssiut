namespace WebAppAssiut.Repository
{
	public class Service : IService
	{
		public Service()
		{
			Id=Guid.NewGuid().ToString();
		}
		public string Id { get; set; }
	}
}
