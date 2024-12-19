namespace SREmulator.CLI
{
    partial class CLI
    {
        public const string Help =
            """
            USAGE:
                sremulator.exe <COMMAND> [OPTIONS]
            
            COMMANDS:
                result-statistics                   统计所有抽取结果
                achieve-average-warps               计算实现目标所需抽数
                achieve-chance                      计算实现目标的可能性
                help                                显示该帮助

            OPTIONS:
                --pause                             每次抽取后暂停（按任意键继续）（对 result-statistics 有效）
                --return                            前一次的抽取结果显示将被后一次的抽取结果覆盖（对 result-statistics 有效）
                --silent                            不显示每抽获取的物品（对 result-statistics 有效）
                --export                            导出抽卡结果
                --output                            导出命令结果（.csv 或 .txt）
                --no-rewards                        不计算抽卡副产物

                --star-rail-pass <count>            设置星轨通票数量（下限为 0）
                --star-rail-special-pass <count>    设置星轨专票数量（下限为 0）
                --undying-starlight <count>         设置未熄的星芒数量（下限为 0）
                --stellar-jade <count>              设置星琼数量（下限为 0）
                --oneiric-shard <count>             设置古老梦华数量（下限为 0）
                --eidolon <name> <count>            设置角色星魂（上限为 6，下限为 -1）
                --unlimited-resources               设置为拥有无限抽卡资源
            
                --counter5 <count>                  设置已多少抽未出5星
                --guarantee5                        设置为有5星大保底
                --counter4 <count>                  设置已多少抽未出4星
                --guarantee4                        设置为有4星大保底
                --counter5character <count>         设置已多少抽未出5星角色
                --counter5lightcone <count>         设置已多少抽未出5星光锥
                --counter4character <count>         设置已多少抽未出4星角色
                --counter4lightcone <count>         设置已多少抽未出4星光锥
            
                --warp-name <name>                  设置要抽取的卡池（参见 WARP-NAMES）（对UP角色/光锥池有效）
                --warp-version <major> <minor>      设置卡池所在的版本（影响可抽取到的四星对象）

                --character-event-warp              设置卡池类型为角色活动跃迁（UP角色池）
                --light-cone-event-warp             设置卡池类型为光锥活动跃迁（UP光锥池）
                --stellar-warp                      设置卡池类型为群星跃迁（常驻池）
                --departure-warp                    设置卡池类型为始发跃迁（新手池）

                --target <name> <count>             设置目标极其数量（参见 TARGET-NAMES）
                --target-count5 <count>             【已移除】设置目标5星数量（限定池中表示UP5星角色，普池中表示特定5星角色）
                --target-count4 <count>             【已移除】设置目标4星数量（限定池中表示特定UP4星角色，普池中表示特定4星角色）
                --attempts <count>                  设置计算抽数或可能性时的尝试次数

                --days <count>                      设置在多少天后抽卡（计算通过每日任务、小月卡、深渊、每月商店获得的抽卡资源）
                --express-supply-pass               设置有小月卡（影响日常星琼计算）

                --help                              显示该帮助
                --language <name>                   更改语言（目前仅支持 zh-Hans, en-US）

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
            """;
    }
}
