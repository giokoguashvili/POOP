using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			//задачка состоит в следующем
			//на каждого пользователя в системе нужно генерировать папочку
			//точнее путь до папки
			//так как пользователей может быть ооочень много, то нельзя просто брать и складывать все папочки для пользователей в одну папочку
			//кто не знает, линукс сойдет с ума если положить 100 тысяч папок в одну папку
			//даже меньше
			//поэтому как правило делают следующее, генерируют некое число, которое потом разбивают на подпапки
			//и получается что то в духе / opt / 123 / 432 / 543
			//а забыл еще кое что важное, надо чтобы на repl it был не только код, но и ниже тесты проверяющие его(хотя бы тупо вызовы этой функции с разными параметрами)
			//генерация происходит следующим образом
			//берется id пользователя(это то что идет на вход нашей функции generate)
			//дальше к нему слева добавляются нули так чтобы в сумме было 9 цифр
			//затем число реверсится и разбивается по три символа
			//получается три группы
			//затем они собираются в путь
			//как показано выше
			//`/ 123 / 432 / 543`
			//поясню что реверс нужен для хорошего распределения
			//иначе папки будут набиваться строго по очереди
			//`/000/000/001` `/000/000/002`
			//типа такого
			//поэтому реверс
			//итого, функция на вход принимает число, на выходе путь

			Console
				.WriteLine(
					new FolderLocation(
						new Reversed(
							new PaddedNumber(
								new UserId(123456789)
							)
						)
					)
				);

			Assert
				.Equals(
					"/721/000/000",
					new FolderLocation(
						new Reversed(
							new PaddedNumber(
								new UserId(127)
							)
						)
					)
				);

			Assert
				.Equals(
					"/654/765/430",
					new FolderLocation(
						new Reversed(
							new PaddedNumber(
								new UserId(34567456)
							)
						)
					)
				);

			Assert
				.Equals(
					"/999/999/999",
					new FolderLocation(
						new Reversed(
							new PaddedNumber(
								new UserId(999999999)
							)
						)
					)
				);
		}
	}

	public static class Assert
	{
		public static void Equals(string first, object second)
		{
			Console.WriteLine(first.Equals(second.ToString()));
		}
	}
	public class FolderLocation
	{
		private readonly IContent<string> _number;
		private readonly int _folderNameMaxLength = 3;
		private readonly string _folderLocationSpliter = "/";
		public FolderLocation(IContent<string> number)
		{
			this._number = number;
		}

		public string Path()
		{
			return _folderLocationSpliter +
				String
				.Join(
					_folderLocationSpliter,
					new Chunked(_number, _folderNameMaxLength)
						.Content()
				);
		}

		public override string ToString()
		{
			return this.Path();
		}
	}

	public class UserId : IContent<string>
	{
		private readonly int number;
		private readonly int _userIdMaxLength = 9;

		public UserId(int number)
		{
			this.number = number;
		}

		public string Content()
		{
			return String
				.Join(
					String.Empty,
					number
						.ToString()
						.Take(_userIdMaxLength)
				);
		}
	}
	public class PaddedNumber : IContent<string>
	{
		private readonly IContent<string> _number;
		private int _paddedNumberLength = 9;
		private char _padSymbol = '0';
		public PaddedNumber(IContent<string> number)
		{
			this._number = number;
		}

		public string Content()
		{
			return String
					.Join(
						String.Empty,
						Enumerable
							.Range(0, _paddedNumberLength - _number.Content().Length)
							.Select(i => _padSymbol)
							.Concat(_number.Content().ToString())
					);
		}
	}

	public class Chunked : IContent<IEnumerable<string>>
	{
		private readonly IContent<string> content;
		private readonly int chunkSize;

		public Chunked(IContent<string> content, int chunkSize)
		{
			this.content = content;
			this.chunkSize = chunkSize;
		}

		public IEnumerable<string> Content()
		{
			return Enumerable
					.Range(0, content.Content().Count() / chunkSize)
					.Select(i =>
						 String
							.Join(
								String.Empty,
								content
									.Content()
									.Skip(chunkSize * i)
									.Take(chunkSize)
							)
					);
		}
	}
	public class Reversed : IContent<string>
	{
		private readonly IContent<string> content;

		public Reversed(IContent<string> content)
		{
			this.content = content;
		}
		public string Content()
		{
			return new String(content.Content().Reverse().ToArray());
		}
	}
	public interface IContent<T> { T Content();  }
}
