import pygame,random
h='f'
pygame.init()
shr=pygame.font.Font(None,37)
#======================================
xe=900
ye=700
#======================================
xs=450
ys=350
bxs=range(xs,xs+15)
bys=range(ys,ys+15)
#======================================


ap=0


pkx=[]
pky=[]

ek=pygame.display.set_mode((xe,ye))
text=shr.render('Счет:',0,(0,0,0))
#=======================================

def go  (eve,h,ap):
    if eve.key==pygame.K_w and (h!='S'or ap<1):
        h='W'
    elif eve.key==pygame.K_s and (h!='W'or ap<1):
        h='S'
    elif eve.key==pygame.K_a and (h!='D'or ap<1):
        h='A'
    elif eve.key==pygame.K_d and (h!='A'or ap<1) :
        h='D'
    return h


def aps ():
    xka=random.randrange(50,850,25)
    yka=random.randrange(50,650,25)
    f=0
    return xka,yka,f




gol=pygame.Surface((37,37))
gol.fill((1,7,54))
tel=pygame.Surface((37,37))
tel.fill((96,21,249))


xka,yka,f=aps()


while 1:

    for eve in pygame.event.get():
        if eve.type==pygame.QUIT:
            exit()
        if eve.type==pygame.KEYDOWN:
            h=go(eve,h,ap)
    if h=='W':
        ys-=25
    elif h=='S':
        ys+=25
    elif h=='A':
        xs-=25
    elif h=='D' :
        xs+=25
    if xs>=xe-10 or xs<0 or ys>=ye-10 or ys<0:
        exit()

    if 1:
        bxs = range(xs-28, xs + 28)
        bys = range(ys-28, ys + 28)




    ek.fill((60, 174, 11))
    pygame.draw.circle(ek, (255, 6, 6), (xka, yka), 12)
    ek.blit(gol, (xs, ys))
    ek.blit(text,(700,0))


    for i in range (0,ap):
        pkx[i]=pkx[i+1]
        pky[i] = pky[i + 1]
        ek.blit(tel,(pkx[i],pky[i]))
        if pkx[i]==xs and pky[i]==ys:
            exit()

        print(ap)

    pkx.insert(ap,xs)
    pky.insert(ap,ys)
    print(ap)




    if xka-10 in bxs and yka-10 in bys:
        pygame.time.delay(50)
        xka, yka,f = aps()
        for f in range (0,ap):
            while xka in range(pkx[f]-170,pkx[f]+170)and yka in range(pky[f]-170,pky[f]+170):
                xka, yka,f = aps()

        ap+=1
        text = shr.render('Счет: '+str(ap), 0, (0, 0, 0))



    pygame.display.update()
    pygame.time.delay(80)
