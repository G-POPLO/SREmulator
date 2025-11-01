## 卡片设计

应用程序主要采取卡片设计，样式代码如下：

```xaml

 <!-- 卡片样式 -->
                <Border Background="{DynamicResource SystemControlBackgroundChromeMediumBrush}" 
                        Padding="20" 
                        Margin="0,0,0,20"                    
                        BorderBrush="{DynamicResource SystemControlBackgroundChromeMediumBrush}">

                   <StackPanel>
                      <!-- StackPanel常用于多个元素Horizontal排列 -->

                        <!-- 应用名称 -->
                        <StackPanel Orientation="Horizontal" 
                                    Margin="0,0,0,15"
                                    VerticalAlignment="Center">
                           <!-- Content1 -->
                        </StackPanel>

                      
                        <StackPanel Orientation="Horizontal" 
                                    Margin="0,0,0,15"
                                    VerticalAlignment="Center">
                            <!-- Content2 -->
                        </StackPanel>

                        <!-- Border默认Vertical排列 -->
                        <!-- 若有更多内容，后续可以添加更多StackPanel -->
                        <!-- 若确认元素无需Horizontal排列无需添加 -->
                        

                      <!-- Content3 -->


                    </StackPanel>
                </Border>

```

主要按钮样式如下：

```xaml 

                        <Button Style="{DynamicResource AccentButtonStyle}">
                                 <!-- Content -->
                        </Button>
```
（仅限Windows）DynamicResource AccentButtonStyle 按钮的强调色与系统个性化设置的主题色相一致。