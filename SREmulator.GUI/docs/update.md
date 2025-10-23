## 自动更新

### 添加新的更新地址
该应用程序支持自动更新。当有新版本发布时，应用程序会自动下载并安装最新版本。需要注意的是，应用程序不支持添加直链下载，仅支持添加以JSON格式返回的更新地址。
若后续需要添加新的更新地址，需要在[Update.cs]和[Setting.xaml]中添加如下代码：

[Update.cs]
```csharp
   string apiUrl = Properties.Settings.Default.DownloadIndex
                 switch
                {
                    
                    // GitCode API 需要access_token才能访问，该仓库为私有镜像仓库   
                    1 => "https://api.gitcode.com/api/v5/repos/C-Poplo/SREmulator/releases/latest/?access_token=4RszX_1zdryXuvgwHbV-Edr7",  // Gitcode 
                    // 2 => "https://example.com/download",      // 新添加的下载链接，返回值必须为JSON，暂未添加直链下载           
                    _ => "https://api.github.com/repos/Silencersn/SREmulator/releases/latest", // Github，默认链接
                };

```
[Setting.xaml]
```csharp
                                <ComboBox x:Name="cmbUpdateSource" 
                                      Height="35"
                                      FontSize="14"
                                      Margin="10,0"
                                      SelectedIndex="0">
                                <ComboBoxItem Content="Github"/>
                                <ComboBoxItem Content="Gitcode"/>
                                // <ComboBoxItem Content="ExampleDownload"/>
```

### 发布格式
应用程序发行默认使用7z压缩包进行全量更新，当检测到当前应用程序版本低于最新版本(tag_name)时会提示更新，仅需将Tag设置为发布的版本名称即可：
```csharp
                var response = await client.GetAsync(apiUrl);// 从API获取最新版本信息

                release_info = JObject.Parse(await response.Content.ReadAsStringAsync());
                latestVersion = release_info["tag_name"]?.ToString();

                if (Version.Parse(latestVersion) > Version.Parse(currentVersion))
                {
                    string updateBody = release_info["body"]?.ToString() ?? "无更新内容";
                    bool? result = await ModernDialog.ShowMarkdownAsync($"发现新版本{latestVersion}\n\n更新内容:\n{updateBody}\n\n是否下载？", "提示");
                    if (result == true)
                    {
                        await DownloadAndUpdateAsync();
                    }
                    else
                    {
                        return;
                    }
```
具体更新逻辑请参考[update.cs](SREmulator.GUI\Model\Update.cs)

