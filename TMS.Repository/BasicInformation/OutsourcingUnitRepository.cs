using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Common.DB;
using TMS.IRepository.BasicInformation;
using TMS.Model.Entity;

namespace TMS.Repository.BasicInformation
{
    public class OutsourcingUnitRepository: IOutsourcingUnitRepository
    {
        private readonly DapperClientHelper _SqlDB; //数据库连接

        public OutsourcingUnitRepository(IDapperFactory dapperFactory)
        {
            _SqlDB = dapperFactory.CreateClient("SqlDb");
        }


        /// <summary>
        /// 外协单位显示
        /// </summary>
        /// <param name="name">外协单位名称查询</param>
        /// <param name="phone">外协单位手机号查询</param>
        /// <returns></returns>
        public async Task<List<OutsourcingUnit>> GetOutsourcingUnits(string name, string phone)
        {
            StringBuilder sql = new StringBuilder("select OutsourcingUnitID,OutsourcingUnitName,OutsourcingUnitEmail,OutsourcingUnitTelephone,OutsourcingUnitPhone,OutsourcingUnitPlace,OutsourcingUnitCreateTime from OutsourcingUnit");
            List<OutsourcingUnit> data = await _SqlDB.QueryAsync<OutsourcingUnit>(sql);
            if (!string.IsNullOrEmpty(name))
            {
                data = data.Where(x => x.OutsourcingUnitName.Contains(name)).ToList();
            }
            if (!string.IsNullOrEmpty(phone))
            {
                data = data.Where(x => x.OutsourcingUnitPhone.Contains(phone)).ToList();
            }
            return data;
        }

        /// <summary>
        /// 反填外协单位
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public async Task<OutsourcingUnit> EditOutsourcingUnit(int id)
        {
            StringBuilder sql = new StringBuilder("select OutsourcingUnitID,OutsourcingUnitName,OutsourcingUnitEmail,OutsourcingUnitTelephone,OutsourcingUnitPhone,OutsourcingUnitPlace,OutsourcingUnitResponsibleName,OutsourcingUnitCreateTime from OutsourcingUnit where OutsourcingUnitID=@ID");
            return await _SqlDB.QueryFirstAsync<OutsourcingUnit>(sql.ToString(), new { @ID = id });
        }

        /// <summary>
        /// 删除外协单位(支持批删)
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public async Task<bool> DelOutsourcingUnit(string id)
        {
            int code = -1;
            string[] str = id.Split(',');
            StringBuilder sql = new StringBuilder("delete from OutsourcingUnit where OutsourcingUnitID in (@ID)");
            foreach (var item in str)
            {
                code = await _SqlDB.ExecuteAsync(sql.ToString(), new { @ID = item });
            }
            return code == 0 ? true : false;
        }

        /// <summary>
        /// 添加外协单位
        /// </summary>
        /// <param name="model">信息</param>
        /// <returns></returns>
        public async Task<bool> AddOutsourcingUnit(OutsourcingUnit model)
        {
            StringBuilder sql = new StringBuilder("insert into OutsourcingUnit values(@OutsourcingUnitName,@OutsourcingUnitEmail,@OutsourcingUnitTelephone,@OutsourcingUnitPhone,@OutsourcingUnitPlace,@OutsourcingUnitResponsibleName,@OutsourcingUnitCreateTime)");
            int code = await _SqlDB.ExecuteAsync(sql.ToString(), new
            {
                @OutsourcingUnitName = model.OutsourcingUnitName,
                @OutsourcingUnitEmail = model.OutsourcingUnitEmail,
                @OutsourcingUnitTelephone = model.OutsourcingUnitTelephone,
                @OutsourcingUnitPhone = model.OutsourcingUnitPhone,
                @OutsourcingUnitPlace = model.OutsourcingUnitPlace,
                @OutsourcingUnitResponsibleName=model.OutsourcingUnitResponsibleName,
                @OutsourcingUnitCreateTime = DateTime.Now
            });
            return code == 0 ? true : false;
        }

        /// <summary>
        /// 修改外协单位
        /// </summary>
        /// <param name="model">信息</param>
        /// <returns></returns>
        public async Task<bool> UpdOutsourcingUnit(OutsourcingUnit model)
        {
            StringBuilder sql = new StringBuilder("update OutsourcingUnit set OutsourcingUnitName=@OutsourcingUnitName,OutsourcingUnitEmail=@OutsourcingUnitEmail,OutsourcingUnitTelephone=@OutsourcingUnitTelephone,OutsourcingUnitPhone=@OutsourcingUnitPhone,OutsourcingUnitPlace=@OutsourcingUnitPlace,OutsourcingUnitResponsibleName=@OutsourcingUnitResponsibleName,OutsourcingUnitCreateTime=@OutsourcingUnitCreateTime where OutsourcingUnitID=@OutsourcingUnitID");
            int code = await _SqlDB.ExecuteAsync(sql.ToString(), new
            {
                @OutsourcingUnitID = model.OutsourcingUnitID,
                @OutsourcingUnitName = model.OutsourcingUnitName,
                @OutsourcingUnitEmail = model.OutsourcingUnitEmail,
                @OutsourcingUnitTelephone = model.OutsourcingUnitTelephone,
                @OutsourcingUnitPhone = model.OutsourcingUnitPhone,
                @OutsourcingUnitPlace = model.OutsourcingUnitPlace,
                @OutsourcingUnitResponsibleName = model.OutsourcingUnitResponsibleName,
                @OutsourcingUnitCreateTime = DateTime.Now
            });
            return code == 0 ? true : false;
        }
    }
}
