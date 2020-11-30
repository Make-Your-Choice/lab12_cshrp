using System;

namespace lab12_app {
	class special {
		protected int bonus_num; //число бонусов
		protected int continuation; //длительность в днях
		public special() { //конструктор без параметров
			this.bonus_num = 5;
			this.continuation = 1;
		}
		public special(int a, int b) {
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
		public void reduce_bonus_on_num(int a) {
			Console.WriteLine("\nDecreasing number of bonuses");
			this.bonus_num -= a;
			Console.Write($"Number of bonuses decreased on {0}\n", a);
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
		public override string ToString() {
            string s = "";
            s += "Number of bonuses: " + Convert.ToString(bonus_num) + "\nContinuation: " + Convert.ToString(continuation) + "\n";
            return s;
        }

	}
	class limited_special : special {
		int times_per_year;
		public limited_special(int a, int b, int c) : base(a, b) {
			times_per_year = c;
		}
		public void output() {
			Console.WriteLine($"\nNumber of bonuses:: {bonus_num}\nContinuation: {continuation}\nTimes per year:: {times_per_year}");
		}
		public void change_times_per_year(int a) {
			this.times_per_year = a;
		}
		public void reduce_bonus_on_num(int a, int b)
		{
			Console.WriteLine("\nDecreasing number of bonuses and times per year");
			this.bonus_num -= a;
			this.times_per_year -= b;
			Console.WriteLine($"Number of bonuses decreased on {a}, times per year decreased on {b}");
		}
		public void expand_bonus_num()
		{
			Console.WriteLine("\nIncreasing number of bonuses");
			this.bonus_num += 4;
			Console.WriteLine("Number of bonuses increased on 4");
		}
		public void set_default() {
			base.set_default();
			this.times_per_year = 4;
		}
		public override string ToString() {
            string s = "";
            s += "Number of bonuses: " + Convert.ToString(bonus_num) + "\nContinuation: " + Convert.ToString(continuation) + "\nTimes per year: " + Convert.ToString(times_per_year) + "\n";
            return s;
        }
	}
	class book_store {
		special[,] spec_offer1 = new special[10, 10]; //бонусы двумерный массив
		special[] spec_offer = new special[10]; //бонусы одномерный массив
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
			
			limited_special lim_offer1 = new limited_special(5, 6, 2);
			special sp_offer1 = new special(8, 4);
			Console.WriteLine("\nWorking with a derivative class");
			Console.WriteLine("\nlim_offer1");
			Console.WriteLine(lim_offer1);
			Console.WriteLine("\nsp_offer1\n");
			Console.WriteLine(sp_offer1);
			Console.WriteLine("\nOverload without basic method (reducing bonus num)");
			lim_offer1.reduce_bonus_on_num(2, 1);
			Console.WriteLine("\nlim_offer1\n");
			Console.WriteLine(lim_offer1);
			Console.WriteLine("\nOverload with basic method (setting default val)");
			lim_offer1.set_default();
			Console.WriteLine("\nlim_offer1\n");
			Console.WriteLine(lim_offer1);
			
			
			/*Console.WriteLine("Input information about the 1 book\n"); //ввод информации о книге
			Console.WriteLine("Input number of specials: ");
			n = Convert.ToInt32(Console.ReadLine());
			special[] spec_offer1 = new special[10]; //одномерные массивы
			special[] spec_offer2 = new special[10];
			for(int i = 0; i < n; i++)
			{
				spec_offer1[i] = new special();
				spec_offer2[i] = new special();
			}
			Console.WriteLine("\nInput title: ");
			s1 = Console.ReadLine();
			Console.WriteLine("Input author: ");
			s2 = Console.ReadLine();
			Console.WriteLine("Input genre: ");
			s3 = Console.ReadLine();
			int r;
			r = 0;
			while(r == 0) //проверка корректности ввода цены
			{
				Console.WriteLine("Input price: ");
				r = 1;
				x1 = Console.ReadLine();
				try {
					if(!Char.IsDigit(x1,0)) //если цена - цифра
						throw e1 = new Exception("Incorrect input\n");
					x = Convert.ToInt32(x1);
				}
				catch(Exception e1) {
					Console.WriteLine("Incorrect value\n"); //сообщение об ошибке
					r = 0;
				}
				if (r == 1)
					continue;
			}
			r = 0;
			while(r == 0) //проверка корректности ввода количества на складе
			{
				Console.WriteLine("Input number in stock: ");
				r = 1;
				y1 = Console.ReadLine();
				try {
					if(!Char.IsDigit(y1,0)) //если количество на складе - цифра
						throw e1 = new Exception("Incorrect input\n");
					y = Convert.ToInt32(y1);
				}
				catch(Exception e1) {
					Console.WriteLine("Incorrect value\n"); //сообщение об ошибке
					r = 0;
				}
				if (r == 1)
					continue;
			}
			r = 0;
			while(r == 0) //проверка корректности ввода популярности
			{
				Console.WriteLine("Input popularity: ");
				r = 1;
				z1 = Console.ReadLine();
				try {
					if(!Char.IsDigit(z1,0)) //если популярность - цифра
						throw e1 = new Exception("Incorrect input\n");
					z = Convert.ToInt32(z1);
				}
				catch(Exception e1) {
					Console.WriteLine("Incorrect value\n"); //сообщение об ошибке
					r = 0;
				}
				if (r == 1)
					continue;
			}
			book_store book1 = new book_store(s1, s2, s3, x, y, z, n, spec_offer1);
			book1.output();
			book_store book2 = new book_store(spec_offer2);
			book2.Title = "www"; //установка значений с помощью сеттера
			book2.Author = "sss";
			book2.Genre = "xxx";
			book2.Price = 200;
			book2.Num_stock = 20;
			book2.Popularity = 25;
			Console.WriteLine("\nSecond book (setter used)");
			book2.output();
			Console.WriteLine("\nNumber in stock of 1 and 2: {0}", book1.summarize(book2)); //сложение количетва двух книг
			String book_genre = book1.Genre; //получение значения геттером
			Console.WriteLine("First book genre is {0}, str length of genre is {1}", book_genre, book_genre.Length); //вычисление длины строки жанр
			Console.WriteLine("\nFirst book");
			book1.output(); //вывод
			book1.sell(); //продажа
			book1.output();
			book1.price_rise(); //повышение цены
			book1.output();
			book1.rearrange(); //перестановка
			book1.output();
			book1.archivate(); //отправка на склад
			book1.output();
			book1.reduce_bonus(); //уменьшение количества бонусов для одномерного массива
			book1.output();
			book1.predictable_profit(out profit); //подсчет ожидаемой прибыли через out
			Console.WriteLine("\nPredictable profit: {0}", profit);
			book1.predictable_popularity(ref popularity); //подсчет ожидаемой популярности через ref
			Console.WriteLine("Predictable popularity: {0}", popularity);
			Console.WriteLine("First book title length is {0}",book_store.title_len(book1)); //вывод значения длины строки названия
			book_store.space_left = 50; //установка значения оставшегося места
			Console.WriteLine("Space left in the store {0}",book_store.space_left);
			Console.WriteLine("Input information about the 3 book\n"); //ввод информации о книге
			Console.WriteLine("Input number of specials (n and m): ");
			n = Convert.ToInt32(Console.ReadLine());
			m = Convert.ToInt32(Console.ReadLine());
			special [,] spec_offer3 = new special[10, 10]; //двумерный массив
			for(int i = 0; i < n; i++) //ввод двумерного массива
			{
				for(int j = 0; j < m; j++)
				{
					spec_offer3[i, j] = new special(); //вызов конструктора без параметров
					Console.WriteLine("\nInput number of bonuses for [{0}][{1}] special: ", i + 1, j + 1);
					x2 = Convert.ToInt32(Console.ReadLine());
					spec_offer3[i, j].change_bonus_num(x2);
					Console.WriteLine("Input continuation for [{0}][{1}] special: ", i + 1, j + 1);
					y2 = Convert.ToInt32(Console.ReadLine());
					spec_offer3[i, j].change_continuation(y2);
				}
			}
			Console.WriteLine("\nInput title: ");
			s1 = Console.ReadLine();
			Console.WriteLine("Input author: ");
			s2 = Console.ReadLine();
			Console.WriteLine("Input genre: ");
			s3 = Console.ReadLine();
			r = 0;
			while(r == 0) //проверка корректности ввода цены
			{
				Console.WriteLine("Input price: ");
				r = 1;
				x1 = Console.ReadLine();
				try {
					if(!Char.IsDigit(x1,0)) //если цена - цифра
						throw e1 = new Exception("Incorrect input\n");
					x = Convert.ToInt32(x1);
				}
				catch(Exception e1) {
					Console.WriteLine("Incorrect value\n"); //сообщение об ошибке
					r = 0;
				}
				if (r == 1)
					continue;
			}
			r = 0;
			while(r == 0) //проверка корректности ввода количества на складе
			{
				Console.WriteLine("Input number in stock: ");
				r = 1;
				y1 = Console.ReadLine();
				try {
					if(!Char.IsDigit(y1,0)) //если количество на складе - цифра
						throw e1 = new Exception("Incorrect input\n");
					y = Convert.ToInt32(y1);
				}
				catch(Exception e1) {
					Console.WriteLine("Incorrect value\n"); //сообщение об ошибке
					r = 0;
				}
				if (r == 1)
					continue;
			}
			r = 0;
			while(r == 0) //проверка корректности ввода популярности
			{
				Console.WriteLine("Input popularity: ");
				r = 1;
				z1 = Console.ReadLine();
				try {
					if(!Char.IsDigit(z1,0)) //если популярность - цифра
						throw e1 = new Exception("Incorrect input\n");
					z = Convert.ToInt32(z1);
				}
				catch(Exception e1) {
					Console.WriteLine("Incorrect value\n"); //сообщение об ошибке
					r = 0;
				}
				if (r == 1)
					continue;
			}
			book_store book3 = new book_store(s1, s2, s3, x, y, z, n, m, spec_offer3);
			book3.output1();
			book3.sell(); //продажа
			book3.output1();
			book3.price_rise(); //повышение цены
			book3.output1();
			book3.rearrange(); //перестановка
			book3.output1();
			book3.archivate(); //отправка на склад
			book3.output1();
			book3.reduce_bonus1(); //уменьшение количества бонусов для двумерного массива
			book3.output1();
			special[] spec_offer0 = new special[1];
			special[] spec_offer4 = new special[1];
			spec_offer0[0] = new special();
			spec_offer4[0] = new special();
			Console.WriteLine($"\nDefault value of special offer = {spec_offer0[0].bonus_num}");
			spec_offer4[0] = spec_offer0[0] + 5; //перегрузка + постфиксная
			Console.WriteLine($"\nSpecial offer + 5 = {spec_offer4[0].bonus_num}");
			spec_offer4[0] = 10 + spec_offer0[0]; //перегрузка + префиксная
			Console.WriteLine($"10 + Special offer = {spec_offer4[0].bonus_num}");
			spec_offer4[0] = spec_offer0[0] ++; //перегрузка ++ постфиксная
			Console.WriteLine($"Special offer ++ = {spec_offer4[0].bonus_num}");
			spec_offer4[0].set_default();
			spec_offer4[0] = ++ spec_offer0[0]; //перегрузка ++ префиксная
			Console.WriteLine($"++ Special offer = {spec_offer4[0].bonus_num}");
			Console.WriteLine("\nMassive using constructor with a single parameter");
			special[] spec_offer5 = new special[2];
			for(int i = 0; i < 2; i ++)
			{
				spec_offer5[i] = new special(10); //вызов конструктора с одним параметром для создания массива
			}
			Console.WriteLine("\nSpecial offers\n");
			for(int i = 0; i < 2; i ++)
			{
				spec_offer5[i].output();
			}*/
		}
	}
}