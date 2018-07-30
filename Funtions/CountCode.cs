using System.IO;
using System.Collections.Generic;

namespace UseCSharp
{
    public interface Condition
    {
        bool IsOk(FileSystemInfo info);
    }

    public class CsFileTarget : Condition
    {
        public bool IsOk(FileSystemInfo info)
        {
            if (CountCode.IsDir(info)) return true;

            return info.Extension == ".cs";
        }
    }

    public class EasyFileUtils
    {
        public static bool IsDir(FileInfo fileInfo)
        {
            return (fileInfo.Attributes & FileAttributes.Directory) == FileAttributes.Directory;
        }
    }

    public class CountCode
    {
        public static void MainEx()
        {
            var countCode = new CountCode();
            countCode.AddCondition(new CsFileTarget());
            countCode.Add(Path.Combine("E:/projects/unity/slots.crazyletter/Assets", "_Common"));
            countCode.Add(Path.Combine("E:/projects/unity/slots.crazyletter/Assets", "_Dev"));
            countCode.Add(Path.Combine("E:/projects/unity/slots.crazyletter/Assets", "_GameBundles"));
            countCode.Add(Path.Combine("E:/projects/unity/slots.crazyletter/Assets", "_LuckyVegas"));
            countCode.Add(Path.Combine("E:/projects/unity/slots.crazyletter/Assets", "_SlotGameTookit"));
            countCode.Add(Path.Combine("E:/projects/unity/slots.crazyletter/Assets", "_Slots"));
            int sum = countCode.Count();
        }

        public static void MainEx2()
        {
            var countCode = new CountCode();
            countCode.AddCondition(new CsFileTarget());
            var dir = "E:/hpl_projects/unity_projects/voxel3dcolor/Assets";
            countCode.Add(Path.Combine(dir, "_Common"));
            countCode.Add(Path.Combine(dir, "_PiexlColorNumber"));
            int sum = countCode.Count();
            System.Console.WriteLine("sum: " + sum);
        }

        int sum;

        HashSet<string> paths = new HashSet<string>();

        HashSet<Condition> conditions = new HashSet<Condition>();

        public bool Target(FileSystemInfo info)
        {
            foreach (var con in conditions)
            {
                if (con.IsOk(info)) return true;
            }
            return false;
        }

        public void AddCondition(Condition con)
        {
            if (conditions.Contains(con)) return;

            conditions.Add(con);
        }


        public void Add(string path)
        {
            paths.Add(path);
        }

        public int Count()
        {
            sum = 0;
            foreach(var path in paths)
            {
                var file = new FileInfo(path);
                if (IsDir(file))
                {
                    sum += CountDir(new DirectoryInfo(path));
                }
                else
                {
                    sum += CountFile(file);
                }
            }
            return sum;
        }

        public int CountFile(FileInfo file)
        {
            if (!Target(file)) return 0;

            var reader = file.OpenText();
            var sum = 0;
            while (reader.ReadLine() != null)
                sum++;
            reader.Close();
            reader.Dispose();
            return sum;
        }

        public int CountDir(DirectoryInfo root)
        {
            if (!Target(root)) return 0;

            var sum = 0;
            var dirs = root.GetDirectories();
            foreach(var dir in dirs)
            {
                sum += CountDir(dir);
            }
            var files = root.GetFiles();
            foreach(var file in files)
            {
                sum += CountFile(file);
            }
            return sum;
        }

        public static bool IsDir(FileSystemInfo info)
        {
            return (info.Attributes & FileAttributes.Directory) == FileAttributes.Directory;
        }
    }
}
