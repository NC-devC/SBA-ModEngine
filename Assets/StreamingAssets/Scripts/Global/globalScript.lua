--[[
    API Sba Mod Engine v0.2.0:
    Глобальные функции:
    Start - то, что происходит при создании уровня
    Update - обновление уровня
    FixedUpdate - фиксированное обновление уровня
    EverySecond - делайте что-либо раз в секунду
    OnWin - делайте что-либо при победе игрока
    OnDie - делайте что-либо при проигрыше игрока
    Функции:
    print("текст") - вывод текста в командную строку
    Модули:
    sa (SceneAPI):
        Описание:
        Управляйте сценой прямо из LUA скрипта. Вы можете создавать объекты с помощью этого модуля.
        Параметры модуля:
            time - время на сцене(в секундах)
        Функции модуля:
            createCube(x,y,z,scalex,scaley,scalez) - Возвращает объект LuaCUBE(параметры: float)

    Объекты:
    LuaCUBE:
        Описание:
        Куб.
        Свойства:
            GameObject gameObject;(UnityEngine.GameObject)
        Функции:
            destroy() - уничтожить объект
    LuaWINPART:
        Описание:
        Объект победы.
        Свойства:
            GameObject gameObject;(UnityEngine.GameObject)
        Функции:
            destroy() - уничтожить объект
]]

local cubes = {}
local cube1

function Start()
    print("hello from creating")
    cube1 = sa.createCube(10,0.8073,127.05,10,10,10)

    winPart = sa.createWinPart(-10,0.8073,127.05,10,10,10) -- объект на победу
    table.insert(cubes, cube1) --Вставляем куб в список
end

function Update()
    
end

function EverySecond()
    print("Время сцены: "..sa.time)
end

function FixedUpdate()
    
end

function OnWin()
    print("Выигрыш")
end

function OnDie()
    print("Проигрыш")
end