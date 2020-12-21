using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassCompileLoad
{
    class CodeDomExample
    {
        public static String dllorexeName = "TestComipleUnit";
        //生产代码一种方式
        public static CodeCompileUnit BuildHelloWorldGraph()
        {
            // 新建一个 CodeCompileUnit 来包含程序图纸
            CodeCompileUnit compileUnit = new CodeCompileUnit();

            // 声明一个名称为 Samples 的新命名空间
            CodeNamespace samples = new CodeNamespace("Samples");

            // 把新命名空间添加到程序编译单元中
            compileUnit.Namespaces.Add(samples);

            // 添加新的命名空间（System 命名空间）的引用
            samples.Imports.Add(new CodeNamespaceImport("System"));

            // 定义一个新类，取名为 Class1
            CodeTypeDeclaration TestComipleUnit = new CodeTypeDeclaration(dllorexeName);

            // 把 Class1 添加到 Samples 命名空间中
            samples.Types.Add(TestComipleUnit);

            // 定义新的代码入口点（Main 方法）
            CodeEntryPointMethod start = new CodeEntryPointMethod();

            // 为 System.Console 类创建一个类型引用
            CodeTypeReferenceExpression csSystemConsoleType = new CodeTypeReferenceExpression("System.Console");

            // 构建一个 Console.WriteLine 方法的声明
            CodeMethodInvokeExpression cs1 = new CodeMethodInvokeExpression(
                csSystemConsoleType,
                "WriteLine",
                new CodePrimitiveExpression("hello world")
                );
            //将 system.console.writeline("hello world")添加到Main方法中
            start.Statements.Add(cs1);

            CodeMethodInvokeExpression cs2 = new CodeMethodInvokeExpression(
                csSystemConsoleType,
                "WriteLine",
                new CodePrimitiveExpression("Press the Enter key to continue")
                );

            start.Statements.Add(cs2);
            // 构建 Console.ReadLine 方法的声明
            CodeMethodInvokeExpression csReadLine = new CodeMethodInvokeExpression(
                csSystemConsoleType,
                "ReadLine");

            // 把 ReadLine 方法添加到 Main 方法中
            start.Statements.Add(csReadLine);

            // 把 Main 方法添加 Class1 类中
            TestComipleUnit.Members.Add(start);

            return compileUnit;
        }

        //编译CodeCompileUnit方式的代码，生成代码源文件
        public static void GenerateCode(CodeDomProvider provider, CodeCompileUnit compileUnit)
        {
            string sourceFile = "";
            if (provider.FileExtension[0] == '.')
            {
                sourceFile = dllorexeName + provider.FileExtension;
            }
            else
            {
                sourceFile = dllorexeName + "." + provider.FileExtension;
            }
            IndentedTextWriter tw = new IndentedTextWriter(new StreamWriter(sourceFile, false), "");
            // 利用生成器生成源代码
            provider.GenerateCodeFromCompileUnit(compileUnit, tw, new CodeGeneratorOptions());
            // 关闭文件输出流
            tw.Close();

        }

        //将源文件编译成程序
        public static CompilerResults CompileCode(CodeDomProvider provider, string sourceFile, string exeFile)
        {
            string[] referenceAssemblies = { "System.dll" };
            CompilerParameters cp = new CompilerParameters(referenceAssemblies, exeFile, false);
            cp.GenerateExecutable = true;// 生成一个可执行文件，而不是一个 DLL 文件

            // 调用编译器
            CompilerResults cr = provider.CompileAssemblyFromFile(cp, sourceFile);
           
            // 返回编译结果
            return cr;
        }


    }
}
