Buk=['A','B','C','D','E','F','G','H','I']


slow=input('Введите слова:	')

def ShBuk(Buk,slow):
    mas=[]
    for i in slow:
        for i1 in range(len(Buk)):
            if i==Buk[i1]:
                mas.append(i1)
    mas= Sor(mas)
    for m in range(len(mas)):
        for en,b in enumerate(Buk):
            if mas[m]==en:
                mas[m]=b
    return mas
def Sor(mas):
    x=len(mas)-1
    for i in range(x):
        for i1 in range(x-i):
            if mas[i1]>mas[i1+1]:
                mas[i1],mas[i1+1]=mas[i1+1],mas[i1]
    return mas
x=ShBuk(Buk,slow)
print(str(x))
input()
