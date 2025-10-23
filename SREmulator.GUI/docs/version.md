## 版本号获取

应用程序的版本号通过[SRVersion.cs](SREmulator\SRVersion.cs)文件获取。

页面解析版本号的代码如下：
```csharp
  private void InitializeWarpVersions()
        {
            // 创建版本信息列表
            var versions = new List<WarpVersionInfo>();

            // 使用反射动态获取SRVersion枚举中所有以"Ver"开头的版本值
            var versionType = typeof(SRVersion);
            var versionValues = Enum.GetValues(versionType).Cast<SRVersion>()
                .Where(v => v.ToString().StartsWith("Ver") && v != SRVersion.VersionForWarps)
                .OrderBy(v => v); // 按枚举值排序

            // 为每个版本创建WarpVersionInfo对象
            foreach (var version in versionValues)
            {
                string versionName = version.ToString();
                // 从版本名称中提取主版本号和次版本号
                // 例如: Ver1p0 -> 主版本号: 1, 次版本号: 0
                string versionNumber = versionName.Substring(3); // 去掉"Ver"前缀
                string[] parts = versionNumber.Split('p');

                if (parts.Length == 2 &&
                    int.TryParse(parts[0], out int majorVersion) &&
                    int.TryParse(parts[1], out int minorVersion))
                {
                    string displayName = $"{majorVersion}.{minorVersion}";
                    versions.Add(new WarpVersionInfo(displayName, (int)version, majorVersion, minorVersion));
                }
            }
```

我不理解为什么要使用16进制存储版本号。不理解。