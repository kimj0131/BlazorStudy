namespace BlazorApp.Data
{
	public class Food
	{
		public string Name { get; set; }
		public int Price { get; set; }
	}

	// 인터페이스로 개선
	public interface IFoodService
	{
		IEnumerable<Food> GetFoods();
	}

	public class FoodService : IFoodService
	{
		public IEnumerable<Food> GetFoods()
		{
			List<Food> foods = new List<Food>()
			{
				new Food(){Name = "Bibimbap", Price = 7000 },
				new Food(){Name = "Kimbap", Price = 3000 },
				new Food(){Name = "Bossam", Price = 9000 }
			};

			return foods;
		}
	}

	public class FastFoodService : IFoodService
	{
		public IEnumerable<Food> GetFoods()
		{
			List<Food> foods = new List<Food>()
			{
				new Food(){Name = "Hamburger", Price = 5000 },
				new Food(){Name = "Fries", Price = 1000 }
			};

			return foods;
		}
	}

	// Dependency Injection을 활용하면 생성자에서 서비스를 연동해준다
	// injection한 razor컴포넌트에서 확인가능
	public class PaymentService
	{
		IFoodService _service;

		public PaymentService(IFoodService service)
		{
			_service = service;
		}

		// TODO
	}

	public class SingletonService : IDisposable
	{
		public Guid ID { get; set; }

		public SingletonService()
		{
			ID = Guid.NewGuid();
		}

		public void Dispose()
		{
			Console.WriteLine("SingletonService Disposed");
		}
	}

	public class TransientService : IDisposable
	{
		public Guid ID { get; set; }

		public TransientService()
		{
			ID = Guid.NewGuid();
		}

		public void Dispose()
		{
			Console.WriteLine("TransientService Disposed");
		}
	}

	public class ScopedService : IDisposable
	{
		public Guid ID { get; set; }

		public ScopedService()
		{
			ID = Guid.NewGuid();
		}

		public void Dispose()
		{
			Console.WriteLine("ScopedService Disposed");
		}
	}
}
