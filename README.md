# SREmulator

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