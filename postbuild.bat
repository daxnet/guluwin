@echo on

del %1\guluwin\bin\%2\gulus\SunnyChen.Gulu.Gulus.dll
del %1\guluwin\bin\%2\zh-CN\SunnyChen.Gulu.Gulus.resources.dll

copy %1\SunnyChen.Gulu.Gulus\bin\%2\SunnyChen.Gulu.Gulus.dll %1\guluwin\bin\%2\gulus
copy %1\SunnyChen.Gulu.Gulus\bin\%2\zh-CN\SunnyChen.Gulu.Gulus.resources.dll %1\guluwin\bin\%2\zh-CN
