import datetime,requests
from bs4 import BeautifulSoup
url='http://www.xn--c1adoj5aa.xn--p1ai/files/www/hg.htm'#Ссылка на сайт

week_day={
	1:'Пн',
	2:'Вт',
	3:'Ср',
	4:'Чт',
	5:'Пт',
	6:'Суб',
	7:'Вс'
	}#Дни недели  цыфпы в string# Дни недели из цыфр в букв#Конвертатор дней недели из цифры в буквы


Russ_alf=[chr (i) for i in range(ord('А'),ord('я')+1)]#Русский алфавит от А доя Я (включая малые регисты)
need_group=input()
if need_group=='':
	need_group='ИС-17-9'

def to_week():#Получение сегоднешнего дня
	dat_week=int(datetime.datetime.today().isoweekday())
	dat=datetime.date.today()

	print('Дата на ваших часах: '+str(dat)+' '+str(week_day[dat_week]))

def get_html(url):#Получение html кода
	r=requests.get(url)
	return r.text

def get_raspis(html):
	soup=BeautifulSoup(html,'lxml')
	
	xz=soup.find('table',class_='inf')
	
	fas=xz.find_all('tr')
	x=0#Пройденная длина
	Group=[]
	for i in fas:
		s=i.get_text()#Получение текста из всех групп и запись его в списк
		if x>=1 and x<6:# Добовление нужные строки в  списк		
			x+=1
			Group.append(s)

		if need_group in s:#Как только в нашем списке появится нужная группа начинаем считать количество необходимых строчек 
			Group.append(s)
			x+=1
	return Group #Получение списка всех групп#Получение пар,преподавателей,кабинетов ,всех групп
			
def make_good_raspis(bad_raspis):#Преведение начала списка в порядок (Комфортный вид)
	string_bad_raspis=bad_raspis[0]
	bad_raspis[0]=bad_raspis[0].replace(need_group+'1',need_group +'\n1)	' )# Перенос первого номера пары на новую строку
	for i in range(1,5):# Перебор значений для добавления отступов после номера пары
		bad_raspis[i]=bad_raspis[i].replace(str(i+1),str(i+1)+')	',1)#Добовления номера посредством замены номера ,на номер + TAB
	return bad_raspis


	for i in range (0,5):
		print(bad_raspis[i])

def srez_kabinet_and_prepod(pred_srez_raspis):#Создает срез кабинетов и преподавателей ,для всех пар на
	string_for_kabinet=['','','','','']#Строка в которй буду хранится все номера кобинетов

	#string_for_famile=''#Строка где будут хранится все преподователи


	for i in range(0,5):#Цыкл для перебора мкасимально возможного количества пар
		test_digit_kabinty=True#Для проверик информации ,что кабинет найден
		for_digit_kabinet='		'#Для сохранения готовой комбинации (Кабинета)
		kolek_digit_for_kabinet=''#Для сохронения прошлых цифр в строке номер пары
		
		strt_digit=0
		#Famile=''#Для сбора полных фамилии перед помишение ее в хранилише  фамилий(string_for_famile) 
		for strin_raspis in pred_srez_raspis[i]:#Цыкл перебора всех символов в строке номер пары

			if test_digit_kabinty==True:# Если кабинет не найден то ищем
				
				if strt_digit==3:
					test_digit_kabinty=False#Меняем переменную 
					for_digit_kabinet=''+kolek_digit_for_kabinet

					#string_for_kabinet+=' '+for_digit_kabinet 
					string_for_kabinet.insert(i,for_digit_kabinet)

					#Famile=''+strin_raspis# Основа для руководителя
					
				elif strin_raspis.isdigit():#Проверка является ли strin_raspis цифрой
					kolek_digit_for_kabinet+=strin_raspis
					strt_digit+=1
				else :
					strt_digit=0					
					kolek_digit_for_kabinet=''


			#else:#Поиск руководителя
				#Famile+=strin_raspis
				#print(Famile)
		#string_for_famile+=' '+Famile#Перемешение найденого руководителя в глвную строку


	final_raspis(string_for_kabinet,pred_srez_raspis)

def final_raspis(string_kabinet,raspis):#Вывод и разделение  кабенетов от преподавателей

	for i in range (0,len(string_kabinet)-1):# разделение
		if string_kabinet[i]=='':
			continue
		raspis[i]=raspis[i].replace(string_kabinet[i],'	Кабинет: '+str(string_kabinet[i]+'	'))

	
	for i in range (5):#Вывод
		print(raspis[i])

def get_soup_time(html):
	soup=BeautifulSoup(html,'lxml')
	time=soup.find('li',class_='zgr')
	return time.text#Дата на сайте


def main():

	html=get_html(url)
	bad_raspis=get_raspis(html)#Преподы ,пары,кабинеты, но до комфортного вида 

	srez_kabinet_and_prepod(make_good_raspis(bad_raspis))#Полностью готовый (Комфортный вид)
	
	print('Дата на сайте: '+get_soup_time(html))
	

	to_week()
 

if __name__=='__main__':
	main()