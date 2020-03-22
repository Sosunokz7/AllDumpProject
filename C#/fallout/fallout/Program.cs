using System;

namespace fallout
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Random randNum = new Random ();
			int v, p;
			int q ,w ,o, f=1,o1 ,z,z1,z2,z3 ;

			int[] xzz = new  int[8];
			{
				xzz [1] = 1;
				xzz [2] = 1;
				xzz [3] = 1;
				xzz [4] = 1;
				xzz [5] = 1;
				xzz [6] = 1;
				xzz [7] = 1;
			};


			p = randNum.Next (1, 3);
			if (p == 1) {
				Console.WriteLine ("Ваш пол : Женский \n");} else 		Console.WriteLine ("Ваш пол : Мужской\n");


			v = randNum.Next (16, 36);
			Console.WriteLine ("Ваш возраст " + v +"\n");



			//////////////////////////////////////////////////////////


			w = randNum.Next (0, 3);
			if (w == 0) {o = 0; o1 = 0;goto w1;} else 
			if (w == 1) {	o = randNum.Next (1, 17); o1 = 0;}
			else 
					o = randNum.Next (1, 17); o1 = randNum.Next (1, 17);
			while (o == o1) {o1 = randNum.Next (1, 17);};


			if (o == 16 || o1==16) {f = f+1;}  

				////////////////////////////////////////////////////////////////// 
				w1:
				s0:
				q = 33;
				xzz [1] = randNum.Next (f, 11);
				if (xzz [1] == f) {
					goto s1;
				}
				;
				xzz [1] = xzz [1] - f;
				q = q - xzz [1];
				xzz [1] = xzz [1]+f; 
				s1:
				



			xzz [2] = randNum.Next  (f, 11);
			if (xzz [2] == f) {goto s2;};
			xzz [2] = xzz [2] - f;
			q = q - xzz [2];
			xzz [2] = xzz [2]+f;
			s2: 



			xzz [3] = randNum.Next (f, 11);
			if (xzz[3] == f) {goto s3;};
			xzz [3] = xzz [3]-f;
			q = q-xzz [3];
			xzz [3] = xzz [3]+f;
			s3:



			xzz [4] = randNum.Next (f, 11);
			if (xzz [4] == f) {goto s4;}
			xzz [4] = xzz [4] - f;
			q = q - xzz [4];
			xzz [4] = xzz [4]+f;
			s4:



			xzz [5] = randNum.Next (f, 11);
			if (xzz [5] == f) {goto s5;};
			xzz [5] = xzz [5] - f;
			q = q - xzz [5];
			xzz [5] = xzz [5]+f;
			s5:



			xzz [6] = randNum.Next (f, 11);
			if (xzz [6] == f) {goto s6;};
			xzz [6] = xzz [6] - f;
			q = q - xzz [6];
			xzz[6] = xzz [6]+f;
			s6:



			xzz [7] = randNum.Next (f, 11);
			if (xzz [7] == f) {goto s7;}
			xzz [7] = xzz [7] - f;
			q = q - xzz [7];
			xzz [7] = xzz [7]+f;
			s7:
			while (q < 0 || q!=0) 
			{
				
				goto s0;
			}  


		
			if (o >= 1 	|| o1 >= 1) {
				Console.WriteLine ("Доп особености\n");};

			if (o == 1	|| o1 == 1) 	{Console.WriteLine ("Ускореный метаболизм");}; 
			if (o==2 	|| o1 ==2 )   	{Console.WriteLine ("Хулиган");}; 
			if (o==3 	|| o1 ==3 )   	{Console.WriteLine ("Миниатюрный");}; 
			if (o==4 	|| o1 ==4 )   	{Console.WriteLine ("Однарукий");}; 
			if (o==5 	|| o1 ==5 )   	{Console.WriteLine ("Точность");}; 
			if (o==6 	|| o1 ==6 )   	{Console.WriteLine ("Камикадзе");}; 
			if (o==7 	|| o1 ==7 )   	{Console.WriteLine ("Тяжолаярука");}; 
			if (o==8 	|| o1 ==8 )   	{Console.WriteLine ("Стрельба на вскидку");}; 
			if (o==9 	|| o1 ==9 )   	{Console.WriteLine ("Крававая баня");}; 
			if (o==10	|| o1 ==10 )   	{Console.WriteLine ("Порченый");}; 
			if (o==11 	|| o1 ==11 )   	{Console.WriteLine ("Добрая душа");}; 
			if (o==12 	|| o1 ==12 )   	{Console.WriteLine ("Чувство к химии");}; 
			if (o==13 	|| o1 ==13 )   	{Console.WriteLine ("Сопротивление к химии");}; 
			if (o==14 	|| o1 ==14 )   	{Console.WriteLine ("Сексуальность");}; 
			if (o==15 	|| o1 ==15 )   	{Console.WriteLine ("Тренеровочный");}; 
			if (o==16 	|| o1 ==16 )   	{Console.WriteLine ("Одареный");}; 
			if (o >= 1 	|| o1 >= 1) {
				
				Console.WriteLine ("\n") ;};



			Console.WriteLine ("Основные навыки\n");
			Console.WriteLine ("Сила = " + xzz [1]);
			Console.WriteLine ("Восприятие =  " + xzz [2]);
			Console.WriteLine ("Выносливость = " + xzz [3]);
			Console.WriteLine ("Превлекательность = " + xzz [4]);
			Console.WriteLine ("Интелект = "+xzz[5]);
			Console.WriteLine ("Ловкость = " + xzz [6]);
			Console.WriteLine ("Удача = "+xzz[7]);
			Console.WriteLine (q);


			Console.ReadLine ();


			n:
			z = randNum.Next (1, 19);
			z1 = randNum.Next (1, 19);
			z2 = randNum.Next (1, 19);


			if ( z==z1 || z1==z2  ||z2==z) {goto n;};

			if (z==1 || z1==1 || z2==1) {Console.WriteLine ("Легкое оружие");};
			if (z==2 || z1==2 || z2==2) {Console.WriteLine ("Тяжолое оружие");};
			if (z==3 || z1==3 || z2==3) {Console.WriteLine ("Энергитическое оружие");};
			if (z==4 || z1==4 || z2==4) {Console.WriteLine ("Без оружия");};
			if (z==5 || z1==5 || z2==5) {Console.WriteLine ("Холодное");};
			if (z==6 || z1==6 || z2==6) {Console.WriteLine ("Метательное");};
			if (z==7 || z1==7 || z2==7) {Console.WriteLine ("Первая помощь");};
			if (z==8 || z1==8 || z2==8) {Console.WriteLine ("Скрытность");};
			if (z==9|| z1==9 || z2==9) {Console.WriteLine ("Взлом");};
			if (z==10|| z1==10 || z2==10) {Console.WriteLine ("Доктор");};
			if (z==11|| z1==11|| z2==11) {Console.WriteLine ("Кража");};
			if (z==12 || z1==12 || z2==12) {Console.WriteLine ("Ловушки");};
			if (z==13 || z1==13 || z2==13) {Console.WriteLine ("Наука");};
			if (z==14 || z1==14 || z2==14) {Console.WriteLine ("Ремонт");};
			if (z==15 || z1==15 || z2==15) {Console.WriteLine ("Красноречие");};
			if (z==16 || z1==16 || z2==16) {Console.WriteLine ("Бартер");};
			if (z==17 || z1==17 || z2==17) {Console.WriteLine ("Азартные игры");};
			if (z==18 || z1==18 || z2==18) {Console.WriteLine ("Натуралист");};


			Console.ReadLine ();


			}
	

			
		
		
		
		}
	}

