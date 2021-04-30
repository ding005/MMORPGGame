--hotfix 热补丁
--游戏启动时候，先执行热补丁的类
print("GameInit.Init()")
local t2 = require "PB/Test2"
local t3 = require "PB/Test3"
require "Test"
t2.Init()
t2.CreateObj()



