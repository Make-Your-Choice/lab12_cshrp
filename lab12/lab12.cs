using System;

namespace lab12_app {
	interface bonus_expansion { //интерфейс
		void expand_bonus_num(); //метод интерфейса
	}
	abstract class payment : ICloneable { //абстрактный класс оплата с поддержкой клонирования
		protected int is_succeed;
		public payment(int a) {
			is_succeed = a;
		}
		public object Clone() { //клонирование
            return new payment_cash(is_succeed);
        }
		public int get_access() { //геттер
            return is_succeed;
        }
		public abstract int is_accessible(); //абстрактная функция проверки успешности операции оплаты
	}
	class payment_cash : payment { //наследник абстрактного класса
		public payment_cash(int a) : base(a) { //вызов конструктора базового класса
		}
		public override string ToString() { //перегрузка toString
            string s = "";
            s += "Access code: " + Convert.ToString(is_succeed) + "\n";
            return s;
        }
		public void change_val(int a) { //изменение кода доступа
			is_succeed = a;
		}
		public override int is_accessible() { //перегрузка абстрактной функции
			return is_succeed * 1;
		}
	}
	class payment_card : payment { //наследник абстрактного класса
		public payment_card(int a) : base(a) { //вызов конструктора базового класса
		}
		public override int is_accessible() { //перегрузка абстрактной функции
			return is_succeed * 0;
		}
	}
	class special { //бонусы
		protected int bonus_num; //число бонусов
		protected int continuation; //длительность в днях
		public special() { //конструктор без параметров
			this.bonus_num = 5;
			this.continuation = 1;
		}
		public special(int a, int b) { //конструктор с параметрами
			this.bonus_num = a;
			this.continuation = b;
		}
		public special(int a) { //конструктор с параметром для создания массива
			this.bonus_num = a;
			this.continuation = 1;
		}
		public void change_bonus_num (int a) { //изменение числа бонусов
			this.bonus_num = a;
		}
		public void change_continuation(int a) { //изменение длительности
			this.continuation = a;
		}
		public void output() { //вывод
			Console.WriteLine($"Number of bonuses: {bonus_num}\nContinuation: {continuation}");
		}
		public void reduce_bonus() { //сокращение числа бонусов
			Console.WriteLine("\nDecreasing number of bonuses");
			this.bonus_num = bonus_num - 2;
			Console.WriteLine("Number of bonuses decreased on 2");
		}
		public void reduce_bonus_on_num(int a) { //сокращение числа бонусов на число
			Console.WriteLine("\nDecreasing number of bonuses");
			this.bonus_num -= a;
			Console.Write($"Number of bonuses decreased on {0}\n", a);
		}
		public void expand_bonus_num() { //метод интерфейса
			Console.WriteLine("\nIncreasing number of bonuses");
			this.bonus_num += 2;
			Console.WriteLine("Number of bonuses increased on 2");
		}
		public void set_default() { //установка значений по умолчанию
			this.bonus_num = 5;
			this.continuation = 2;
		}
		public static special operator + (special spec_offer, int a) { //перегрузка + постфиксная
			special spec_offer1;
			spec_offer1 = new special();
			spec_offer1.bonus_num = spec_offer.bonus_num + a;
			return spec_offer1;
		}
		public static special operator + (int a, special spec_offer) { //перегрузка + префиксная
			special spec_offer1;
			spec_offer1 = new special();
			spec_offer1.bonus_num = a + spec_offer.bonus_num;
			return spec_offer1;
		}
		public static special operator ++ (special spec_offer) { //перегрузка ++ постфиксная и префиксная
			++ spec_offer.bonus_num;
			return spec_offer;
		}
		public override string ToString() { //перегрузка toString
            string s = "";
            s += "Number of bonuses: " + Convert.ToString(bonus_num) + "\nContinuation: " + Convert.ToString(continuation) + "\n";
            return s;
        }

	}
	class limited_special : special { //наследование от класса бонусов - класс ограниченные бонусы с поддержкой интерфейса
		int times_per_year; //периодичность в год
		public limited_special(int a, int b, int c) : base(a, b) { //конструктор с вызовом конструктора базового (супер) класса
			times_per_year = c;
		}
		public void output() {
			Console.WriteLine($"\nNumber of bonuses:: {bonus_num}\nContinuation: {continuation}\nTimes per year:: {times_per_year}");
		}
		public void change_times_per_year(int a) { //изменение периодичности
			this.times_per_year = a;
		}
		public void reduce_bonus_on_num(int a, int b) //перегрузка базового метода сокращения числа бонусов на заданное число
		{
			Console.WriteLine("\nDecreasing number of bonuses and times per year");
			this.bonus_num -= a;
			this.times_per_year -= b;
			Console.WriteLine($"Number of bonuses decreased on {a}, times per year decreased on {b}");
		}
		public void expand_bonus_num() //метод интерфейса и перегрузка базового метода увеличения числа бонусов
		{
			Console.WriteLine("\nIncreasing number of bonuses");
			this.bonus_num += 4;
			Console.WriteLine("Number of bonuses increased on 4");
		}
		public void set_default() { //перегрузка базового метода установления значений по усолчанию с вызовом метода базового класса
			base.set_default();
			this.times_per_year = 4;
		}
		public override string ToString() { //перегрузка toString
            string s = "";
            s += "Number of bonuses: " + Convert.ToString(bonus_num) + "\nContinuation: " + Convert.ToString(continuation) + "\nTimes per year: " + Convert.ToString(times_per_year) + "\n";
            return s;
        }
	}
	class book_store : ICloneable { //поддержка клонирования
		special[,] spec_offer1 = new special[10, 10]; //бонусы двумерный массив
		special[] spec_offer = new special[10]; //бонусы одномерный массив
		public special spec_offer2; //бонусы
		public payment_cash cash; //оплата наличными
		int n = 0; //размерности массивов
		int m = 0;
		String title; //название
		String author; //автор
		String genre; //основной жанр
		int price = 0; //цена
		int num_stock = 0; //количество в магазине
		int popularity = 0; //популярность
		public static int space_left; //статическое поле отавшееся в магазине место
		static public int title_len(book_store book) { //статический метод вычисления длины названия
			return book.title.Length;
		}
		public book_store(special[] spec_offer){ //конструктор с параметром
			n = 0;
			for (int i=0; i<n; i++)
			{
				this.spec_offer[i] = spec_offer[i];
			}
			Console.WriteLine("\nEmpty book created\n");
		}
		public String Title { //получение названия
			get { return title; }
			set { title = value; }
		}
	
		public String Author { //получение автора
			get { return author; }
			set { author = value; }
		}
	
		public String Genre { //получение жанра
			get { return genre; }
			set { genre = value; }
		}
	
		public int Price { //получение цены
			get { return price; }
			set { price = value; }
		}
	
		public int Num_stock { //получение количества в магазине
			get { return num_stock; }
			set { num_stock = value; }
		}
	
		public int Popularity { //получение популярности
			get { return popularity; }
			set { popularity = value; }
		}
		
		public object Clone() { //клонирование
			book_store book = new book_store(title, author, genre, price, num_stock, popularity, spec_offer2, cash.get_access());
            cash = (payment_cash)cash.Clone();
            return book;
        }
		
		public book_store(String str1, String str2, String str3, int a, int b, int c, special spec_offer, int d) { //конструктор с параметрами
			this.title = str1;
			this.author = str2;
			this.genre = str3;
			this.price = a;
			this.num_stock = b;
			this.popularity = c;
			this.spec_offer2 = spec_offer;
			this.cash = new payment_cash(d);
		}
		
		public book_store(String str1, String str2, String str3, int a, int b, int c, int d, special[] spec_offer) { //конструктор с параметрами для одномерного массива
			this.title = str1;
			this.author = str2;
			this.genre = str3;
			this.price = a;
			this.num_stock = b;
			this.popularity = c;
			this.n = d;
			for (int i = 0; i < n; i++)
			{
				this.spec_offer[i] = spec_offer[i];
			}
		}
		public book_store(String str1, String str2, String str3, int a, int b, int c, int d, int e, special[,] spec_offer) { //конструктор с параметрами для двумерного массива
			this.title = str1;
			this.author = str2;
			this.genre = str3;
			this.price = a;
			this.num_stock = b;
			this.popularity = c;
			this.n = d;
			this.m = e;
			for (int i = 0; i < n; i++)
			{
				for(int j = 0; j < m; j++)
				{
					this.spec_offer1[i, j] = spec_offer[i, j];
				}
			}
		}
		public void input(String str1, String str2, String str3, int a, int b, int c, int d) { //ввод
			title = str1;
			author = str2;
			genre = str3;
			price = a;
			num_stock = b;
			popularity = c;
			n = d;
		}
		public override string ToString() { //перегрузка toString
            string s = "";
            s += "\nYour book\nTitle: " + Convert.ToString(title) + "\nAuthor: " + Convert.ToString(author) + "\nGenre: " + Convert.ToString(genre) + "\nPrice: " + Convert.ToString(price) + "\nNumber in stock: " + Convert.ToString(num_stock) + "\n" + spec_offer2 + cash;
            return s;
        }
		public void output() { //вывод для одномерного массива
			Console.WriteLine("\nYour book");
			Console.Write($"\nTitle: {title}\nAuthor: {author}\nGenre: {genre}\nPrice: {price}\nNumber in stock: {num_stock}\nPopularity: {popularity}\n");
			for(int i = 0; i < n; i++)
			{
				spec_offer[i].output();
			}
			Console.Write("\n");
		}
		public void output1() { //вывод для двумерного массива
			Console.WriteLine("\nYour book");
			Console.Write($"\nTitle: {title}\nAuthor: {author}\nGenre: {genre}\nPrice: {price}\nNumber in stock: {num_stock}\nPopularity: {popularity}\n");
			for(int i = 0; i < n; i++)
			{
				for(int j = 0; j < m; j++)
				{
					spec_offer1[i, j].output();
				}
			}
			Console.Write("\n");
		}
		public void sell() { //продажа
			Console.WriteLine("\nPutting book on sale");
			num_stock = num_stock - 1;
			popularity = popularity + 5;
			Console.WriteLine("Ony copy sold, popularity increased on 5");
		}
		public void price_rise() { //повышение цены
			Console.WriteLine("\nRising the price");
			price = price + 50;
			Console.WriteLine("Price risen on 50");
		}
		public void rearrange() { //перестановка
			Console.WriteLine("\nRearranging books");
			popularity = popularity + 10;
			Console.WriteLine("Books rearranged, popularity increased on 10");
		}
		public void archivate() { //отправка на склад
			Console.WriteLine("\nSending 4 books to the archive");
			num_stock = num_stock - 4;
			Console.WriteLine("4 books now stored in archive");
		}
		public int predictable_profit(out int a) { //возврат значения через out
			return a = num_stock * price;
		}
		public int predictable_popularity(ref int a) { //возврат значения через ref
			return a = num_stock * 5 + popularity;
		}
		public int summarize(book_store book) { //сложение количества двух книг
			return this.num_stock + book.num_stock;
		}
		public void reduce_bonus() { //уменьшение числа бонусов для одномерного массива
			for( int i = 0; i < n; i++)
			{
				this.spec_offer[i].reduce_bonus();
			}
		}
		public void reduce_bonus1() { //уменьшение числа бонусов для двумерного массива
			for( int i = 0; i < n; i++)
			{
				for(int j = 0; j < m; j++)
				{
					this.spec_offer1[i, j].reduce_bonus();
				}
			}
		}
	}
	class lab12 {
		static Exception e1;
		static void Main(string[] args) {
			int x = 0, y = 0, z = 0, n, m, profit, popularity = 1; //переменные
			int x2, y2;
			String x1, y1, z1;
			String s1, s2, s3; //строки
			
			int res1, res2;
			
			limited_special lim_offer1 = new limited_special(5, 6, 2);
			special sp_offer1 = new special(8, 4);
			Console.WriteLine("\nWorking with a derivative class");
			Console.WriteLine("\nlim_offer1");
			Console.WriteLine(lim_offer1);
			Console.WriteLine("\nsp_offer1\n");
			Console.WriteLine(sp_offer1);
			Console.WriteLine("\nOverload without basic method (reducing bonus num)"); //перегрузка без вызова базового метода
			lim_offer1.reduce_bonus_on_num(2, 1);
			Console.WriteLine("\nlim_offer1\n");
			Console.WriteLine(lim_offer1);
			Console.WriteLine("\nOverload with basic method (setting default val)"); //перегрузка с вызовом базового метода
			lim_offer1.set_default();
			Console.WriteLine("\nlim_offer1\n");
			Console.WriteLine(lim_offer1);
			
			Console.WriteLine("Working with an abstract class\n");
			payment_cash cash1 = new payment_cash(1);
			payment_card card1 = new payment_card(2);
			res1 = cash1.is_accessible(); //вызов перегруженной абстрактной функции
			if(res1 > 0)
				Console.WriteLine("Cash pay for cash1 is accessible\n");
			else
				Console.WriteLine("Cash pay for cash1 is not accessible\n");
			res2 = card1.is_accessible(); //вызов перегруженной абстрактной функции
			if(res2 > 0)
				Console.WriteLine("Card pay for card1 is accessible\n");
			else
				Console.WriteLine("Card pay for card1 is not accessible\n");
			
			Console.WriteLine("Working with an interface (bonus num expansion)");
			sp_offer1.expand_bonus_num(); //вызов метода интерфейса
			Console.WriteLine("\nsp_offer1\n");
			Console.WriteLine(sp_offer1);
			lim_offer1.expand_bonus_num(); //вызов метода интерфейса
			Console.WriteLine("\nlim_offer1\n");
			Console.WriteLine(lim_offer1);
			
			s1 = "qqq";
			s2 = "aaa";
			s3 = "zzz";
			special spec_offer6 = new special(3, 4);
			book_store book6 = new book_store(s1, s2, s3, 100, 10, 15, spec_offer6, 2);
			s1 = "www";
			s2 = "sss";
			s3 = "xxx";
			special spec_offer7 = new special(5, 6);
			book_store book7 = new book_store(s1, s2, s3, 200, 20, 25, spec_offer7, 1);
			Console.WriteLine("\nShallow cloning (spec_offer.bonus_num) and deep cloning (cash.is_succeed)\n");
			Console.WriteLine("book6");
			Console.WriteLine(book6);
			Console.WriteLine("book7");
			Console.WriteLine(book7);
			book6 = (book_store)book7.Clone();
			Console.WriteLine("book6");
			Console.WriteLine(book6);
			book7.spec_offer2.change_bonus_num(10); //мелкое клонирование spec_offer (для book6 bonus_num = 10)
			book7.cash.change_val(3); //глубокое клонирование cash (для book6 is_succeed = 1)
			Console.WriteLine("book6");
			Console.WriteLine(book6);
			Console.WriteLine("book7");
			Console.WriteLine(book7);
		}
	}
}