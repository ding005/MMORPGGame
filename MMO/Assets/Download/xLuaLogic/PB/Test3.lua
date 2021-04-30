--hotfix 热补丁
--游戏启动时候，先执行热补丁的类
print("Test3")
local Test3 = {}
local t = require "PB/Test2"
function Test3.test()
	t.again()
end


return Test3
