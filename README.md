# SREmulator 崩铁抽卡模拟器
可通过自定义玩家状态（如星琼数量、星轨专票数量）和卡池状态（如多少抽未出5星、有无大保底）来模拟崩铁抽卡流程

## 功能
- [x] 模拟所有角色活动跃迁
- [x] 模拟所有光锥活动跃迁
- [x] 模拟所有版本的群星跃迁
- [x] 模拟始发跃迁
- [x] 自定义跃迁
    - [x] API
    - [ ] CLI
- [x] 模拟跃迁完成后的副产物反馈（如星芒）
- [x] 模拟玩家拥有的角色状态（影响星芒个数）
    - [x] API
    - [ ] 允许在CLI自定义
- [x] 统计模拟结果
- [x] 计算实现目标所需抽数或可能性
    - [x] 可同时设置单个5星目标和单个4星目标
    - [ ] 可许同时设置多个5星目标和多个4星目标
    - [ ] 可同时设置不同卡池
- [x] 多语言支持
    - [x] 简体中文
    - [x] 英文
        - [x] 角色名、光锥名
        - [ ] 文档
    - [ ] 其它语言
- [ ] 更多CLI选项 
- [ ] GUI

## CLI
```
USAGE:
    sremulator.exe <COMMAND> [OPTIONS]

COMMANDS:
    result-statistics                   统计所有抽取结果
    achieve-average-warps               计算实现目标所需抽数
    achieve-chance                      计算实现目标的可能性

OPTIONS:
    --pause                             每次抽取后暂停（按任意键继续）
    --return                            前一次的抽取结果显示将被后一次的抽取结果覆盖
    --silent                            不显示每抽获取的物品

    --star-rail-pass <count>            设置星轨通票数量
    --star-rail-special-pass <count>    设置星轨专票数量
    --undying-starlight <count>         设置未熄的星芒数量
    --stellar-jade <count>              设置星琼数量
    --oneiric-shard <count>             设置古老梦华数量

    --counter5 <count>                  设置已多少抽未出5星
    --guarantee5                        设置为有大保底

    --warp-name <name>                  设置要抽取的卡池
    --warp-version <major> <minor>      设置卡池所在的版本（影响可抽取到的四星对象）

    --character-event-warp              设置卡池类型为角色活动跃迁（UP角色池）
    --light-cone-event-warp             设置卡池类型为光锥活动跃迁（UP光锥池）
    --stellar-warp                      设置卡池类型为群星跃迁（常驻池）
    --departure-warp                    设置卡池类型为始发跃迁（新手池）

    --target-count5 <count>             设置目标Up5星数量
    --target-count4 <count>             设置目标Up4星数量
    --attempts <count>                  设置计算抽数或可能性时的尝试次数
```

### 示例
> 我想在 v1.0 版本中将希儿从无抽取到2魂（抽 3 只希儿）
> 我现在 50 抽未出5星角色，有大保底。
> 我想知道我大概还需要多少抽才能实现目标
```
sremulator.exe achieve-average-warps --warp-name seele --warp-version 1 0 --character-event-warp --counter5 50 --target-count5 3 --guarantee5
```
[更多示例](Examples/)