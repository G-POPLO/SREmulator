# SREmulator 崩铁抽卡模拟器
可通过自定义玩家状态（如星琼数量、星轨专票数量）和卡池状态（如多少抽未出5星、有无大保底）来模拟崩铁抽卡流程

## 功能
- [x] 模拟所有角色活动跃迁
- [x] 模拟所有光锥活动跃迁
- [x] 模拟所有版本的群星跃迁
- [x] 模拟始发跃迁
- [x] 自定义跃迁
- [x] 模拟跃迁完成后的副产物反馈（如星芒）
- [x] 模拟玩家拥有的角色状态（影响星芒个数）
- [x] 模拟卡池状态（大小保底，未出5星角色/5星光锥/4星角色/4星光锥的抽数）
- [x] 模拟日常获取星琼/通票/专票
- [x] 统计模拟结果
- [x] 导出模拟结果
- [x] 计算实现目标所需抽数或可能性
    - [x] 可同时设置多个任意目标
    - [x] 可同时设置不同卡池
- [x] 多语言支持
    - [x] 简体中文
    - [x] 英文
        - [x] 角色名、光锥名
        - [ ] 文档
    - [ ] 其它语言
- [ ] 更多CLI选项 
- [x] GUI

## CLI
```
USAGE:
    sremulator.exe <COMMAND> [OPTIONS]

COMMANDS:
    result-statistics                   统计所有抽取结果
    achieve-average-warps               计算实现目标所需抽数
    achieve-chance                      计算实现目标的可能性
    help                                显示该帮助

OPTIONS:
    # 通用
    --export                            导出抽卡结果
    --output                            导出命令结果（.csv 或 .txt）
    --no-rewards                        不计算抽卡副产物
    --help                              显示该帮助
    --language <name>                   更改语言（目前仅支持 zh-Hans, en-US）

    --star-rail-pass <count>            设置星轨通票数量（下限为 0）
    --star-rail-special-pass <count>    设置星轨专票数量（下限为 0）
    --undying-starlight <count>         设置未熄的星芒数量（下限为 0）
    --stellar-jade <count>              设置星琼数量（下限为 0）
    --oneiric-shard <count>             设置古老梦华数量（下限为 0）
    --unlimited-resources               设置为拥有无限抽卡资源

    --eidolon <name> <count>            设置角色星魂（上限为 6，下限为 -1）
    --days <count>                      设置在多少天后抽卡（计算通过每日任务、小月卡、深渊、每月商店获得的抽卡资源）
    --express-supply-pass               设置有小月卡（影响日常星琼计算）
    --equilibrium-level                 设置均衡等级

    --new-warp <type>                   添加新的目标卡池类型（参见 WARP-TYPES）

    --warp-name <name>                  设置具体要抽取的卡池（参见 WARP-NAMES）（对UP角色/光锥池有效）
    --custom-warp <5> <41> <42> <43>    设置自定义卡池的UP对象
    --warp-version <major> <minor>      设置卡池所在的版本（影响可抽取到的四星对象）

    --counter5 <count>                  设置已多少抽未出5星
    --guarantee5                        设置为有5星大保底
    --counter4 <count>                  设置已多少抽未出4星
    --guarantee4                        设置为有4星大保底
    --counter5character <count>         设置已多少抽未出5星角色
    --counter5lightcone <count>         设置已多少抽未出5星光锥
    --counter4character <count>         设置已多少抽未出4星角色
    --counter4lightcone <count>         设置已多少抽未出4星光锥


    # result-statistics
    --pause                             每次抽取后暂停（按任意键继续）
    --return                            前一次的抽取结果显示将被后一次的抽取结果覆盖
    --silent                            不显示每抽获取的物品


    # achieve-average-warps / achieve-chance
    --target <name> <count>             设置目标及其数量（参见 TARGET-NAMES）
    --attempts <count>                  设置计算抽数或可能性时的尝试次数 


    # 已过时 / 已移除
    --character-event-warp              【已移除】设置卡池类型为角色活动跃迁（UP角色池）
    --light-cone-event-warp             【已移除】设置卡池类型为光锥活动跃迁（UP光锥池）
    --stellar-warp                      【已移除】设置卡池类型为群星跃迁（常驻池）
    --departure-warp                    【已移除】设置卡池类型为始发跃迁（新手池）
    --target-count5 <count>             【已移除】设置目标5星数量（限定池中表示UP5星角色，普池中表示特定5星角色）
    --target-count4 <count>             【已移除】设置目标4星数量（限定池中表示特定UP4星角色，普池中表示特定4星角色）

WARP-TYPES:
    角色活动跃迁（UP角色池）：character-event-warp, character
    光锥活动跃迁（UP光锥池）：light-cone-event-warp, light-cone, lightcone
    群星跃迁（常驻池）: stellar-warp, stellar
    始发跃迁（新手池）: departure-warp, departure

WARP-NAMES:
    （可直接使用对应角色的拼音，无论是角色池还是光锥池）
    希儿池: seele, xier
    景元池: jing-yuan, jingyuan
    银狼池: silver-wolf, silverwolf, yinlang
    罗刹池: luocha
    刃池: blade, ren
    卡芙卡池: kafka, kafuka
    丹恒•饮月池: dan-heng-imbibitor-lunae, dan-heng, danhengyinyue, yinyue, danheng
    符玄池: fu-xuan, fuxuan
    镜流池: jingliu
    托帕&账账池: topaz-numby, topaz, tuopa-zhangzhang, tuopa
    藿藿池: huohuo
    银枝池: argenti, yinzhi
    阮•梅池: ruan-mei, ruanmei
    真理医生池: dr-ratio, ratio, zhenliyisheng
    黑天鹅池: black-swan, heitiane
    花火池: sparkle, huahuo
    黄泉池: acheron, huangquan
    砂金池: aventurine, shajin
    知更鸟池: robin, zhigengniao
    波提欧池: boothill, botiou
    流萤池: firefly, liuying
    翡翠池: jade, feicui
    云璃池: yunli
    椒丘池: jiaoqiu
    飞霄池: feixiao
    灵砂池: lingsha
    乱破池: rappa, luanpo
    星期日池: sunday, xingqiri
    忘归人池: fugue, wangguiren
    参见 https://github.com/Silencersn/SREmulator/blob/master/SREmulator/Localizations/SREventWarpKeys.cs 中的 SRAliasesAttribute

TARGET-NAMES:
    （角色与光锥均可直接使用拼音）
    参见 https://github.com/Silencersn/SREmulator/blob/master/SREmulator/Localizations/SRCharacterKeys.cs 中的 SRAliasesAttribute
    参见 https://github.com/Silencersn/SREmulator/blob/master/SREmulator/Localizations/SRLightConeKeys.cs 中的 SRAliasesAttribute
```

### 示例
> 我想在 v1.0 版本中将希儿从无抽取到2魂（抽 3 只希儿）
> 我现在 50 抽未出5星角色，有大保底。
> 我想知道我大概还需要多少抽才能实现目标
```
sremulator.cli.exe achieve-average-warps --new-warp character --warp-name seele --warp-version 1 0 --counter5 50 --target seele 3 --guarantee5
```
[更多示例](Examples/)
