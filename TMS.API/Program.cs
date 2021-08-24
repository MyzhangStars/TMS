using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TMS.API
{
    /// <summary>
    /// Program��
    /// </summary>
    public class Program
    {
        /// <summary>
        /// �����������̣߳�
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            IHostBuilder hostBuilder = CreateHostBuilder(args);//����һ��IHostBuilderʵ��hostBuilder ������ͨ������
            IHost host = hostBuilder.Build();//Build()���и��������Գ�ʼ�������� ��ֻ�ܵ���һ��
            host.Run();//����Ӧ�ó�����ֹ�����̣߳�ֱ�������رա� 
            //CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// IHostBuilder CreateHostBuilder
        /// </summary> 
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)

            ////Log4Net��־����
            //.ConfigureLogging(loggingBuilder=>
            //{
            //    //����ע�᷽ʽ�����⣬��������ķ�ʽ
            //    //loggingBuilder.AddLog4Net("log4net.config");
            //    //һ��Ҫע���ļ�·��
            //    loggingBuilder.AddLog4Net(Path.Combine(Directory.GetCurrentDirectory(),"log4net.config"));
            //})

            .UseServiceProviderFactory(new AutofacServiceProviderFactory())//����ע��

                .ConfigureWebHostDefaults(webBuilder => 
                {
                    webBuilder.UseStartup<Startup>();
                }).ConfigureAppConfiguration((h,c)=>//ָ�����õ������ṩ����
                {
                    c.AddJsonFile($"PersonConfig.Development.json", true, true);
                });
    }
}
