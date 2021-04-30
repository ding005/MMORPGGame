--hotfix 热补丁
--游戏启动时候，先执行热补丁的类
print("Test2")
Test2 = {}
GameObject = CS.UnityEngine.GameObject
callFunc
local a = 0
 function Test2.Init()
 	a = a + 1
 	print("Init = ",a)
 end

  function Test2.again()
  	a = a + 1
 	print("again = ",a)
 end

function Test2.CreateObj()
	local go = GameObject()
end

 return Test2
