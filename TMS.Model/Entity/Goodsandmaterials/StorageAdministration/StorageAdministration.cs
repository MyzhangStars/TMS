﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Model.Entity.Goodsandmaterials.StorageAdministration
{
    /// <summary>
    /// 入库管理表
    /// </summary>
    public class StorageAdministration
    {
        /// <summary>
        /// 入库管理id
        /// </summary>
        public int StorageID { get; set; }
        /// <summary>
        /// 货物名称
        /// </summary>
        public string StorageName { get; set; }
        /// <summary>
        /// 类别外键
        /// </summary>
        public int TypeID { get; set; }
        /// <summary>
        /// 材质外键
        /// </summary>
        public int TextureID { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public string Specification { get; set; }
        /// <summary>
        /// 产地
        /// </summary>
        public string PlaceOfOrigin { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int StorageNumber { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public decimal StoragePrice { get; set; }
        /// <summary>
        /// 支付方式
        /// </summary>
        public string PayType { get; set; }
        /// <summary>
        /// 采购金额
        /// </summary>
        public decimal PurchasePrice { get; set; }
        /// <summary>
        /// 登记人
        /// </summary>
        public string Proposer { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 入库状态
        /// </summary>
        public int GoodsStatus { get; set; }
    }
}
