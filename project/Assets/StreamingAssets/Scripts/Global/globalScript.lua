--[[
    API Sba Mod Engine v0.3.0:
    Глобальные функции:
    Start - то, что происходит при создании уровня
    Update - обновление уровня
    FixedUpdate - фиксированное обновление уровня
    EverySecond - делайте что-либо раз в секунду
    OnWin - делайте что-либо при победе игрока
    OnDie - делайте что-либо при проигрыше игрока
    Функции:
    print("текст") - вывод текста в командную строку

    Типы:
    сolorSTR(цвет):
        red - красный
        green - зелёный
        blue - синий
        black - чёрный
        cyan - циановый
        grey - серый
        gray - серый
        magenta - фиолетовый
        random - случайный
        yellow - жёлтый
        любой иной - белый

    Модули:
    sa/sceneApi (SceneAPI):
        Описание:
        Управляйте сценой прямо из LUA скрипта. Вы можете создавать объекты с помощью этого модуля.
        Параметры модуля:
            time - время на сцене(в секундах)
        Функции модуля:
            createCube(x,y,z,scalex,scaley,scalez) - Возвращает объект LuaCUBE(параметры: float)
            createWinPart(x,y,z,scalex,scaley,scalez) - Возвращает объект LuaWINPART(параметры: float)
            createDiePart(x,y,z,scalex,scaley,scalez) - Возвращает объект LuaDIEPART(параметры: float)

    gui/guiApi (GuiAPI):
        Описание:
        Создавайте свой интерфейс для уровня.

        Параметры модуля:
            canvas - Canvas(UnityEngine)

        Функции модуля:
            createText(x,y,fontSize,scaleX,scaleY,text) - Возвращает LuaText
    Объекты:
    LuaCUBE:
        Описание:
        Куб.
        Свойства:
            GameObject gameObject;(UnityEngine.GameObject)
        Функции:
            destroy() - уничтожить объект
            changeColor(colorStr) - сменить цвет объекту
    LuaWINPART:
        Описание:
        Объект победы.
        Свойства:
            GameObject gameObject;(UnityEngine.GameObject)
        Функции:
            destroy() - уничтожить объект
            changeColor(colorStr) - сменить цвет объекту
    LuaDIEPART:
        Описание:
        Объект поражения.
        Свойства:
            GameObject gameObject;(UnityEngine.GameObject)
        Функции:
            destroy() - уничтожить объект
            changeColor(colorStr) - сменить цвет объекту
    ГУИ Объекты:
    LuaText:
        Описание:
        Объект текста.
        Свойства:
            float posX;
            float posY;
            float scaleX;
            float scaleY;
            int fontSize = 24;
            Text textComponent;
            GameObject gameObject;
        Функции:
            destroy() - уничтожить объект
            changeText(string text) - изменить текст
]]

local cubes = {}
local cube1
local dieParts = {}
local diePart

--Уведомления
local inNotify = false
local notifyTime = 0
local notifyMaxTime = 0
local hasMaxTime = false

local curNotify

--Дебаг
local isDebug = true

function notify(text, time)
    inNotify = true
    curNotify = gui.createText(100,350,24,300,100, text)
    notifyTime = 0
    notifyMaxTime = time
    if time == 0 then
        hasMaxTime = false
    end
end

function notifyClose()
    inNotify = false
    curNotify.destroy()
    notifyTime = 0
    notifyMaxTime = 0
end

function Start()
    print("hello from creating")
    cube1 = sa.createCube(10,0.8073,127.05,10,10,10)

    winPart = sa.createWinPart(-10,0.8073,127.05,10,10,10) -- объект на победу
    diePart = sa.createDiePart(0,0.8073,140,10,10,10) -- объект на поражение
    table.insert(cubes, cube1) --Вставляем куб в список
    table.insert(dieParts, diePart) --Вставляем объект поражения в список
    
    for i,v in pairs(dieParts) do
        diePart.changeColor("red")
    end
    winPart.changeColor("green")

    notify("Время сцены: "..sa.time, 0) -- замена print("Время сцены: "..sa.time)
end

function Update()
    
end

function EverySecond()
    if isDebug == true then
        curNotify.changeText("Время сцены: "..sa.time)
    end
    for i,v in pairs(cubes) do 
        v.changeColor("random")
    end

    if inNotify == true then
        notifyTime = notifyTime +  1
        if hasMaxTime then
            if notifyTime >= notifyMaxTime then
                notifyClose()
            end
        end
    end
end

function FixedUpdate()
    
end

function OnWin()
    print("Выигрыш")
end

function OnDie()
    print("Проигрыш")
end